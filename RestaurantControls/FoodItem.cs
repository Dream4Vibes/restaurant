using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestorauntClient
{
    // Модель данных (должна совпадать с Python)
    public class FoodItem
    {
        // Указываем имя поля как оно приходит от Python (в нижнем регистре)
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("portion")]
        public string Portion { get; set; }

        [JsonProperty("is_available")]
        public bool IsAvailable { get; set; }
    }
}
