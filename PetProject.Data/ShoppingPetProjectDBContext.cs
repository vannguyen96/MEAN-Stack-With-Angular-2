using Microsoft.AspNet.Identity.EntityFramework;
using PetProject.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetProject.Data
{
    public class ShoppingPetProjectDBContext : IdentityDbContext<ApplicationUser> 
    {
        public ShoppingPetProjectDBContext() : base("ShopProjectConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }
        public DbSet<MenuGroup> MenuGroups { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDetail> OrderDetails { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<PostTag> PostTags { set; get; }
        public DbSet<Product> Products { set; get; }

        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<SupportOnline> SupportOnlines { set; get; }
        public DbSet<SystemConfig> SystemConfigs { set; get; }
        public DbSet<Error> Errors { set; get; }

        public DbSet<Tag> Tags { set; get; }

        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }

        public static ShoppingPetProjectDBContext Create()
        {
            return new ShoppingPetProjectDBContext();
        }

        //chạy khi khởi tạo entity framework
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            //khi sử dụng cơ chế auth qua identity, chúng ta sẽ thực hiện add-migration và báo lỗi 
            //PetProject.Data.IdentityUserRole: : EntityType 'IdentityUserRole' has no key defined. Define the key for this EntityType.
            //PetProject.Data.IdentityUserLogin: : EntityType 'IdentityUserLogin' has no key defined. Define the key for this EntityType.

            //set key for table IdentityUserRole
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            //set key for table IdentityUserRole
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }

   
}
