using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Web.Models;
using App.DA.Product;
using App.DA.Menu;
using Microsoft.AspNetCore.Routing;

namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductImplement _product;
        private readonly MenuImplement _menu;

        public HomeController(ProductImplement product, MenuImplement menu)
        {
            _product = product;
            _menu = menu;
        }
        public IActionResult Index()
        {
            var modal = _menu.Get_All_Sub_Menu();
            ViewBag.ListMenu = modal;
            ViewBag.CateID = 1;
            return View();
        }

        public IActionResult GetMenu(int parentID)
        {
            var modal = _menu.Get_All_Child_Menu(parentID);
            return PartialView("~/Views/Home/MenuView/ChildView.cshtml", modal);
        }

        public IActionResult Get_Hot_Sale_Product()
        {
            var productHotSale = _product.Get_Hot_Sale_Product();
            return PartialView(@"~/Views/Home/Products/HotSaleProduct.cshtml", productHotSale);
        }

        public IActionResult HomeOrDetail(string NameAscii)
        {
            var isCateProduct = false;
            var cateID = -1;

            var MenuCategories = _menu.Get_All_Menu_Category();
            foreach (var menuCategory in MenuCategories)
            {
                if (string.Concat("/", NameAscii.Trim()) == menuCategory.UrlString)
                {
                    isCateProduct = true;
                    cateID = menuCategory.ID;
                    break;
                }
            }

            if (isCateProduct == true)
            {
                var modal = _menu.Get_All_Sub_Menu();
                ViewBag.ListMenu = modal;
                ViewBag.CateID = cateID;
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }
}
