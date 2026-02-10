using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantControls;

namespace RestorauntClient.Models 
{
    public class FoodHttpClientModel
    {
        
        private static readonly HttpClient client = new HttpClient();

        // Метод теперь возвращает данные (List<FoodItem>)
        public async Task<List<FoodItem>> GetMenuAsync()
        {
            try
            {
                string url = "http://127.0.0.1:8000/menu";

                // Выполняем запрос
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Парсим и возвращаем список
                var items = JsonConvert.DeserializeObject<List<FoodItem>>(responseBody);

                // Возвращаем данные форме, которая вызвала этот метод 
                return items;
            }
            catch (Exception)
            {
              
                throw;
            }
        }
    }
}