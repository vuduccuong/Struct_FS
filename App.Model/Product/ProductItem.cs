using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Product
{
    public class ProductItem
    {
        public int ID { get; set; }

        public string NameProduct { get; set; }
        public string NameAscii { get; set; }
        public int? LabelID { get; set; }
        public string Descriptin { get; set; }
        public List<ProductDetailItem> ProductDetails { get; set; }
        public string IncludeInfo { get; set; }
        public bool? IsComingSoon { get; set; }
        public bool? IsNotBusiness { get; set; }
        public bool? IsHotSale { get; set; }
    }
}
