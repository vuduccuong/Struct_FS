using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Base.MyAppModel;
using App.DA.Product;
using App.Model.Product;
using App.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace App.Api.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController : Controller
    {
        #region Initial
        private readonly IConfiguration _configuration;
        private readonly IViewRenderService _viewRenderService;
        private readonly ProductImplement _product;
        public ProductController(IConfiguration configuration, IViewRenderService viewRenderService, ProductImplement product)
        {
            this._configuration = configuration;
            this._viewRenderService = viewRenderService;
            this._product = product;
        }
        #endregion

        [HttpGet,Route("get-name")]
        public string GetName()
        {
            var modal = _product.GetNameAuthor();
            return modal;
        }

        [HttpPost, Route("get-product")]
        public IActionResult GetProducts(int PageIndex, int PageSize)
        {
            var modal = _product.GetPagingItems(PageIndex, PageSize);
            return Json(new
            {
                data = modal,
                errors = false
            });
        }
    }
}