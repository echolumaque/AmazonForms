//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmazonRest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> rating { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<decimal> shipping_price { get; set; }
        public Nullable<int> stocks { get; set; }
        public string description { get; set; }
        public string features { get; set; }
        public string brand { get; set; }
        public string series { get; set; }
        public string item_weight { get; set; }
        public string item_model { get; set; }
        public string prod_dimen { get; set; }
        public string item_dimen { get; set; }
    }
}
