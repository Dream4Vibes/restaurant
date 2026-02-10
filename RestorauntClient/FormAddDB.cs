using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json; 

namespace RestorauntClient
{
    public partial class FormAddDB : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public FormAddDB()
        {
            InitializeComponent();
            
        }

        private async void AddFoodButton_Click(object sender, EventArgs e)
        {
            // Валидация (проверка на пустые поля)
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PriceTextBox.Text) ||
                string.IsNullOrWhiteSpace(CategoryTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните Название, Цену и Категорию!");
                return;
            }

            // Парсинг цены
            float price;
            if (!float.TryParse(PriceTextBox.Text, out price))
            {
                MessageBox.Show("Цена должна быть числом!");
                return;
            }

            // Формируем объект для отправки
            
            var newFood = new
            {
                name = NameTextBox.Text,
                description = DescriptionTextBox.Text,
                price = price,
                category = CategoryTextBox.Text,
                portion = PortionTextBox.Text, 
                is_available = IsAvalibleCheckBox.Checked
            };

            try
            {
                // Сериализация в JSON
                string jsonContent = JsonConvert.SerializeObject(newFood);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Отправка POST запроса
                string url = "http://127.0.0.1:8000/menu";
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Блюдо успешно добавлено!");
                    this.DialogResult = DialogResult.OK; // Сигнал для главной формы, что все ок
                    this.Close();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Ошибка сервера: {errorMsg}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка связи: {ex.Message}");
            }
        }
    }
}