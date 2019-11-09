using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model.Menu
{
    public class MenuItem
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string NameCategory { get; set; }
        public string UrlString { get; set; }
        public string Description { get; set; }
        public int MenuOrder { get; set; }
        public bool IsVisible { get; set; }
    }
}
