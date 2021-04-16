using Newtonsoft.Json;

namespace AmazonCMS.Model
{
    public class ProductsModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("prod_name")]
        public string prod_name { get; set; }
        [JsonProperty("rating")]
        public int? rating { get; set; }
        [JsonProperty("thumbanil")]
        public string thumbanil { get; set; }
        [JsonProperty("price")]
        public decimal? price { get; set; }
        [JsonProperty("shipping_fee")]
        public decimal? shipping_fee { get; set; }
        [JsonProperty("stocks")]
        public int? stocks { get; set; }
        [JsonProperty("brand")]
        public string brand { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("features")]
        public string features { get; set; }
        [JsonProperty("series")]
        public string series { get; set; }
        [JsonProperty("model_number")]
        public string model_number { get; set; }
        [JsonProperty("weight")]
        public string weight { get; set; }
        [JsonProperty("product_dimen")]
        public string product_dimen { get; set; }
        [JsonProperty("item_dimen")]
        public string item_dimen { get; set; }
    }
}
