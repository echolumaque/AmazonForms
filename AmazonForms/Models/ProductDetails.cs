using Newtonsoft.Json;
using Prism.Commands;

namespace AmazonForms.Models
{
    public class ProductDetails
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("prod_name")]
        public string Prod_Name { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("thumbanil")]
        public string Thumbanil { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("shipping_fee")]
        public double Shipping_Fee { get; set; }

        [JsonProperty("stocks")]
        public int Stocks { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("features")]
        public string Features { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("model_number")]
        public string ModelNumber { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("product_dimen")]
        public string Product_Dimen { get; set; }

        [JsonProperty("item_dimen")]
        public string Item_Dimen { get; set; }

        public DelegateCommand<int?> GotoProductDetailPage { get; set; }
    }
}
