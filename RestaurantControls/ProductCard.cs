using System;
using System.Drawing;
using System.Windows.Forms;
using RestorauntClient;

namespace RestaurantControls
{
    public partial class ProductCard : UserControl
    {
        // Храним цену внутри карточки, чтобы можно было посчитать сумму заказа
        public float ItemPrice { get; private set; }
        public string ItemName { get; private set; }

       

        public event EventHandler OnCardChanged;

        // Поля для хранения состояния карточки
        private int _quantity;
        private float _pricePerUnit;
        private string _itemName;
        private string _itemDescription;
        private Image _itemImage;

        public int Quantity { get { return _quantity; } }

        public ProductCard()
        {
            InitializeComponent();

            // Подписываемся на события наведения мыши
            this.MouseEnter += (s, e) => this.BackColor = Color.LightGray;
            this.MouseLeave += (s, e) => this.BackColor = Color.White;
        }


        // Метод, которым мы будем заполнять карточку из главной формы
        public void SetData(FoodItem item, int quantity, Image image)
        {
            // Заполняем поля данными из объекта item
            _itemName = item.Name;
            _itemDescription = item.Description;
            _pricePerUnit = item.Price;
            _quantity = quantity;
            _itemImage = image;

            // Обновляем UI
            UpdateCardUI();
        }

        // Обновления текста на карточке
        private void UpdateCardUI()
        {
            // Отображаем Название и Описание в LblDescription
            LblDescription.Text = $"{_itemName}\n{_itemDescription}";

            // Отображаем Количество в ОТДЕЛЬНОЙ метке (lblQuantity)
            
            if (lblQuantity != null)
            {
                lblQuantity.Text = $"x{_quantity.ToString()}" ;
            }

            // Считаем и отображаем Общую Цену
            float total = _quantity * _pricePerUnit;
            lblPriceCard.Text = $"{total} руб.";

            // Обновляем публичные свойства, чтобы главная форма видела актуальные данные
            ItemName = _itemName;
            ItemPrice = total;

            OnCardChanged?.Invoke(this, EventArgs.Empty);
        }

        // Свойство для галочки
        public bool IsSelected
        {
            get { return ChkSelect.Checked; }
            set { ChkSelect.Checked = value; }
        }

        private void AddPortionButton_Click(object sender, EventArgs e)
        {
            _quantity++;
            UpdateCardUI();
        }

        private void DeleteCardButton_Click(object sender, EventArgs e)
        {
            OnCardChanged?.Invoke(this, EventArgs.Empty);

           if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);

                this.Dispose();
            }
        }

        private void ReducePortionButtom_Click(object sender, EventArgs e)
        {
            if (_quantity > 1)
            {
                _quantity--;
                UpdateCardUI();
            }
            else
            {
                MessageBox.Show("Минимальное количество порций - 1. Используйте кнопку удаления, если блюдо не нужно. ");
            }
        }

        private void NumberOfPortions_Click(object sender, EventArgs e)
        {

        }
    }
}