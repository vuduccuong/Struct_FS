using App.Base.MyAppModel;
using App.Model;
using App.Model.Product;
using App.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        public IEnumerable<ProductDetailItem> GetProductDetailByID(int productID)
        {
            return LoadStoredProc("[dbo].[Get_ProductDetail_ByID]")
                .WithSqlParam("@productID", productID)
                .ExecuteStoredProc<ProductDetailItem>();
        }
        public PagingItems<ProductItem> GetPagingItems(int PageIndex, int PageSize)
        {
            var paramTotal = new SqlParameter
            {
                ParameterName = "@total",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var ListProduct = LoadStoredProc("PROC_GetAllProduct")
                .WithSqlParam("@PageIndex", PageIndex)
                .WithSqlParam("@NumberRecord", PageSize)
                .WithSqlParam("@total", paramTotal)
                .ExecuteStoredProc<ProductItem>();

            var totalRecord = Convert.ToInt32(paramTotal.Value);
            if (ListProduct != null && ListProduct.Count > 0)
            {
                foreach (var product in ListProduct)
                {
                    var detail = GetProductDetailByID(product.ID);
                    var listdetail = new List<ProductDetailItem>
                    {
                        detail.FirstOrDefault()
                    };
                    product.ProductDetails = listdetail;
                }
            }

            return new PagingItems<ProductItem>()
            {
                ListItems = ListProduct,
                TotalRecord = totalRecord,
                TotalRecordRest = totalRecord > 0 ? totalRecord - (PageIndex * PageSize) : 0,
                CurrentPage = PageIndex,
                RecordPerPage = PageSize
            };
        }

        public ProductItem Get_ProductDetail_By_Name(string productNameascii)
        {
            var product = LoadStoredProc("[dbo].[Get_ProductDetail_By_NameAscii]")
                .WithSqlParam("@nameAscii", productNameascii)
                .ExecuteStoredProc<ProductItem>();

            return product.FirstOrDefault();
        }

        public IList<ProductItem> Get_Hot_Sale_Product()
        {
            var ListProductHot = LoadStoredProc("[dbo].[Get_Product_Hot_Sale]").ExecuteStoredProc<ProductItem>();

            if (ListProductHot != null && ListProductHot.Count > 0)
            {
                foreach (var product in ListProductHot)
                {
                    var detail = GetProductDetailByID(product.ID);
                    var listdetail = new List<ProductDetailItem>
                    {
                        detail.FirstOrDefault()
                    };
                    product.ProductDetails = listdetail;
                }
            }
            return ListProductHot;
        }

    }
}
