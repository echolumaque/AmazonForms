using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AmazonForms.Models
{
    public class UsersCarts
    {
        public List<Carts> UsersCart { get; set; }
    }

    public class Carts
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("OrderID")]
        public int OrderID { get; set; }

        [JsonProperty("prod_name")]
        public string ProductName { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("ProductID")]
        public int ProductID { get; set; }

        [JsonProperty("thumbanil")]
        public string Thumbnail { get; set; }
    }
}
