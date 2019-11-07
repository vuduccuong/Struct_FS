using App.Base.MyAppModel;
using App.Model;
using App.Model.Product;
using App.Utils.Extensions;
using System;
using System.Data;
using System.Data.SqlClient;

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
            return new PagingItems<ProductItem>()
            {
                ListItems = ListProduct,
                TotalRecord = totalRecord,
                TotalRecordRest = totalRecord > 0 ? totalRecord - (PageIndex * PageSize) : 0,
                CurrentPage = PageIndex,
                RecordPerPage = PageSize
            };
        }
    }
}
