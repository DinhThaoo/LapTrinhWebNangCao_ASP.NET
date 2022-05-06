using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebMypham.Areas.Admin.Model;
using WebMypham.Models;

namespace WebMypham.Areas.Admin.Context
{
    public class Mypham : DbContext
    {
        public Mypham() : base("MyPhamDB") { }

        public DbSet<Khachhang> Khachhangs { get; set; }
        public DbSet<Loaisanpham> Loaisanphams { get; set; }
        public DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public DbSet<Sanpham> Sanphams { get; set; }
        public DbSet<Phieunhap>Phieunhaps { get; set; }
        public DbSet<Hoadon> Hoadons { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


        }
        public DbSet<Nguoidung> Nguoidungs { get; set; }
    }
}