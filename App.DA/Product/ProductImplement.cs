using App.Base.MyAppModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DA.Product
{
    public class ProductImplement : BaseDA
    {
        public ProductImplement(MyAppContext dbcontext) : base(dbcontext)
        {
        }

        public string GetNameAuthor()
        {
            return "Vũ Đức Cường";
        }
    }
}
