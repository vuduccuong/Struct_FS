using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DA.Product;
using App.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet,Route("getname")]
        public string GetName()
        {
            var modal = _product.GetNameAuthor();
            return modal;
        }
    }
}