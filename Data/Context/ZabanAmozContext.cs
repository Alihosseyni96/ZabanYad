using Domain.Models.Admin;
using Domain.Models.AdminMessage;
using Domain.Models.Cart;
using Domain.Models.Comment;
using Domain.Models.Course;
using Domain.Models.Users;
using Domain.Models.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ZabanAmozContext : DbContext
    {
        public ZabanAmozContext(DbContextOptions<ZabanAmozContext> options) : base(options)
        {

        }

        #region Dbset<> Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletToType> WalletToTypes { get; set; }
        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CourseToGroup> CourseToGroups { get; set; }
        public DbSet<AdminMessage> AdminMessages { get; set; }
        public DbSet<AdminMessageToUser> AdminMessageToUsers { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReplyComment> ReplyComments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<DirectBuy> DirectBuys { get; set; }
        public DbSet<RateCourse> RateCourses { get; set; }
        public DbSet<SiteRate> SiteRates { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region CasCade Problem
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                             .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion
            #region Query Filter

            #endregion
            //#region Seed Data For AdminUser
            //modelBuilder.Entity<User>().HasData(new User()
            //{
            //    UserId = 1,
            //    ActiveCode = Guid.NewGuid().ToString().Replace("-", ""),
            //    Email = "seyedalilatifhosseyni@gmail.com",
            //    ImageName = "0c508f1b71e8452490487f9d4d9f4263.ico",
            //    IsActive = true,
            //    IsDelete = false,
            //    PassWord = "1234",
            //    PhoneNumber = "09386562888",
            //    RegisterDate = DateTime.Now,
            //    UserName = "admin",
            //});
            //modelBuilder.Entity<Role>().HasData(new Role()
            //{
            //    RoleId = 1,
            //    RoleTitle = "مدیر سایت",
            //},
            //new Role()
            //{
            //    RoleId = 2,
            //    RoleTitle = "استاد"
            //},
            //new Role()
            //{
            //    RoleId = 3,
            //    RoleTitle = "مدیریت کاربران"
            //});
            //modelBuilder.Entity<UserRole>().HasData(new UserRole()
            //{
            //    UR_Id = 1,
            //    UserId = 1,
            //    RoleId = 1
            //},
            //new UserRole()
            //{
            //    UR_Id = 2,
            //    UserId = 1,
            //    RoleId = 2
            //});

            //#endregion

        }

    }
}
