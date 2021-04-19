using System;

namespace AmazonCMS.Model
{
    public class ProductModel
    {
        public string prod_name { get; set; }
        public Nullable<int> rating { get; set; }
        public string thumbanil { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> shipping_fee { get; set; }
        public Nullable<int> stocks { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public string features { get; set; }
        public string series { get; set; }
        public string model_number { get; set; }
        public string weight { get; set; }
        public string product_dimen { get; set; }
        public string item_dimen { get; set; }
        public int Id { get; set; }
    }
}
