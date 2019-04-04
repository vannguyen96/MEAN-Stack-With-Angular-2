﻿namespace PetProject.Data.Migrations
{
    //using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetProject.Data.ShoppingPetProjectDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetProject.Data.ShoppingPetProjectDBContext context)
        {
            CreateProductCategorySample(context);
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShoppingPetProjectDBContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShoppingPetProjectDBContext()));

            var user = new ApplicationUser()
            {
                UserName = "tedu",
                Email = "tedu.international@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Technology Education"

            };

            manager.Create(user, "123654$");

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(PetProject.Data.ShoppingPetProjectDBContext context)
        {
            if (context.ProductCategories.Count() == 0) 
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {   
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung",Status=true },
                new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
    }
}
