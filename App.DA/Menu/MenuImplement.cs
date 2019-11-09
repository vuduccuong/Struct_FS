using App.Base.MyAppModel;
using App.Model.Menu;
using App.Model.Product;
using App.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DA.Menu
{
    public class MenuImplement : BaseDA
    { 
        public MenuImplement(MyAppContext context) : base(context) { }

        public IList<MenuItem> Get_All_Sub_Menu()
        {
            return LoadStoredProc("Get_Sub_Menu").ExecuteStoredProc<MenuItem>();
        }
        public IList<MenuItem> Get_All_Child_Menu(int parentID)
        {
            return LoadStoredProc("Get_Child_Menu")
                .WithSqlParam("@parentID", parentID)
                .ExecuteStoredProc<MenuItem>();
        }

        public IList<MenuItem> Get_All_Menu_Category()
        {
            return LoadStoredProc("[dbo].[Get_All_MenuCategory]").ExecuteStoredProc<MenuItem>();
        }
    }
}
