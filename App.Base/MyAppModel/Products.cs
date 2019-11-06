using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Base.MyAppModel
{
    public partial class Products
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string NameProduct { get; set; }
    }
}
