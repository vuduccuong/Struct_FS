using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class PagingItems<T>
    {
        public int CurrentPage { get; set; }
        public int RecordPerPage { get; set; }
        public int TotalRecordRest { get; set; }
        public int TotalRecord { get; set; }
        public IList<T> ListItems { get; set; }
    }
}
