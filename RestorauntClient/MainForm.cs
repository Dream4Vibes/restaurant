using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json; // Подключаем работу с json файлами
using RestaurantControls;
using RestorauntClient.Models;

namespace RestorauntClient
{
    
    public partial class MainForm : Form
    {
        private List<FoodItem> menuItems = new List<FoodItem>();
        private BindingList<CartItem> cartItems = new BindingList<CartItem>();
        private Dictionary<string, Image> dishImages = new Dictionary<string, Image>();
        private FoodHttpClientModel _apiModel = new FoodHttpClientModel();

        public MainForm()
        {
            
            InitializeComponent();
         
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Настройка таблицы меню
            MenuGridView.AutoGenerateColumns = true;
            MenuGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MenuGridView.ReadOnly = true;
            MenuGridView.AllowUserToAddRows = false;

            await LoadMenuAsync();
        }

        private async System.Threading.Tasks.Task LoadMenuAsync()
        {
            try
            {
                // 1. Запрашиваем данные у модели
                menuItems = await _apiModel.GetMenuAsync();

                // 2. Отображаем данные (это ответственность UI, а не модели)
                MenuGridView.DataSource = menuItems;

                // 3. Настраиваем внешний вид таблицы
                if (MenuGridView.Columns["Description"] != null)
                    MenuGridView.Columns["Description"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки меню: {ex.Message}");
            }
        }

        private void MenuGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (MenuGridView.SelectedRows.Count > 0)
            {
                var selectedItem = MenuGridView.SelectedRows[0].DataBoundItem as FoodItem;

                if (selectedItem != null)
                {
                    // Форматируем цену, чтобы убирать 0 после запятой
                    string formattedPrice = selectedItem.Price.ToString("0.##");

                 
                    // \r\n — это перенос строки в Windows
                    DescriptionText.Text = $"Категория: {selectedItem.Category}\r\n\r\n" +
                                           $"Описание:\r\n{selectedItem.Description}\r\n\r\n" +
                                           $"Цена: {formattedPrice} руб.\r\n\r\n" +
                                           $"Порция: {selectedItem.Portion}";

                
                }
            }
        }

        private void AddToCartButtom_Click(object sender, EventArgs e)
        {
            

            if (MenuGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите блюдо из списка!");
                return;
            }

            var selectedItem = MenuGridView.SelectedRows[0].DataBoundItem as FoodItem;

            if (selectedItem != null)
            {
                if (!selectedItem.IsAvailable)
                {
                    MessageBox.Show("Это блюдо сейчас недоступно!");
                    return;
                }

                int quantity = 1;
               
                
                RestaurantControls.ProductCard existingCard = null;
                foreach (Control ctrl in CartFlowPanel.Controls)
                {
                    if (ctrl is RestaurantControls.ProductCard card && card.ItemName == selectedItem.Name)
                    {
                        existingCard = card;
                        break;
                    }
                }

                
                Image dishImg = PictureDishes.Image;

                if (existingCard != null)
                {
                    
                    CartFlowPanel.Controls.Remove(existingCard);
                    existingCard.Dispose();
                }

                // Создаем новую карточку из нашей библиотеки
                var newCard = new RestaurantControls.ProductCard();

                // Заполняем данными
                float total = quantity * selectedItem.Price;
                newCard.SetData(selectedItem, quantity, PictureDishes.Image);

                newCard.OnCardChanged += (s, d) => UpdateTotalOrderAmount();

                CartFlowPanel.Controls.Add(newCard);
                MessageBox.Show($"Добавлено в корзину!");
            }
        }

        private void DeleteFromCart_Click(object sender, EventArgs e)
        {
            // Создаем список для удаления
            List<Control> toRemove = new List<Control>();

            foreach (Control ctrl in CartFlowPanel.Controls)
            {
                if (ctrl is RestaurantControls.ProductCard card)
                {
                    if (card.IsSelected) // Проверяем свойство галочки
                    {
                        toRemove.Add(card);
                    }
                }
            }

            foreach (var item in toRemove)
            {
                CartFlowPanel.Controls.Remove(item);
                item.Dispose();
            }
        }

        private void PlaceAnOrder_Click(object sender, EventArgs e)
        {
            if (CartFlowPanel.Controls.Count == 0)
            {
                MessageBox.Show("Ваша корзина пуста!");
                return;
            }

            // Собираем список товаров в одну строку
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            float total = 0;

            foreach (Control ctrl in CartFlowPanel.Controls)
            {
                if (ctrl is RestaurantControls.ProductCard card)
                {
                    // Формируем строку для каждого блюда
                    // Если quantity > 1, добавляем "x2"
                    string quantityText = card.Quantity > 1 ? $" x{card.Quantity}" : "";

                    sb.AppendLine($"{card.ItemName}{quantityText} - {card.ItemPrice} руб.");
                    total += card.ItemPrice;
                }
            }

            // Добавляем разделитель и итог
            sb.AppendLine(new string('-', 26)); // Линия из 30 черточек
            sb.AppendLine($"Итого: {total.ToString("0.##")} руб.");

            // Дата
            sb.AppendLine($"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}");

            // Создаем и открываем форму чека
            Check checkForm = new Check();
            checkForm.SetReceiptText(sb.ToString());
            checkForm.ShowDialog(); // ShowDialog блокирует главную форму, пока чек открыт

            // После закрытия чека очищаем корзину
            CartFlowPanel.Controls.Clear();
            MainControl.SelectedTab = MainPage;
        }

        private void UpdateTotalOrderAmount()
        {
            float total = 0;

            foreach (Control ctrl in CartFlowPanel.Controls)
            {
                if (ctrl is RestaurantControls.ProductCard card)
                {
                    total += card.ItemPrice;
                }
            }

            TotalOrderAmountLabel.Text = $"Итого: {total.ToString("0.##")} руб.";
        }

        private async void AddFoodToDB_Click(object sender, EventArgs e)
        {
            // Открываем форму добавления
            using (FormAddDB addForm = new FormAddDB())
            {
                // ShowDialog возвращает результат, который мы задали в FormAddDB 
                DialogResult result = addForm.ShowDialog();

                // Если форма закрылась с успехом
                if (result == DialogResult.OK)
                {
                    try
                    {
                        
                        await LoadMenuAsync();
                        MenuGridView.Refresh();

                        MessageBox.Show("Меню успешно обновлено!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось обновить меню: {ex.Message}");
                    }
                }
            }
        }

        private void DeleteFoodFromDB_Click(object sender, EventArgs e)
        {

        }
    }
}