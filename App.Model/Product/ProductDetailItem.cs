using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Product
{
    public class ProductDetailItem
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Sku { get; set; }
        public int ProductVarianID { get; set; }
        public int StockQuantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceOnline { get; set; }
        public bool? IsPublic { get; set; }

    }
}
