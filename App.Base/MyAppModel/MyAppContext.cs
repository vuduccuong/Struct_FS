using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App.Base.MyAppModel
{
    public partial class MyAppContext : DbContext
    {
        public MyAppContext()
        {
        }

        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-93OTMBQ\\SQLSERVER;Initial Catalog=MyApp;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.NameProduct).HasDefaultValueSql("(N'Sản phẩm chưa có tên')");
            });
        }
    }
}
