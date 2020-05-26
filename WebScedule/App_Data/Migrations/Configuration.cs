namespace WebSchedule.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebSchedule.Infrastructure;
    using WebSchedule.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebSchedule.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebSchedule.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var admin = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "admin@mail.com",
                EmailConfirmed = true
            };
            var teacher = new ApplicationUser()
            {
                UserName = "Teacher",
                Email = "teacher@mail.com",
                EmailConfirmed = true
            };
            var student = new ApplicationUser()
            {
                UserName = "Student",
                Email = "student@mail.com",
                EmailConfirmed = true
            };
            if (roleManager.Roles.Count() == 0)
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "Teacher" });
                roleManager.Create(new IdentityRole { Name = "Student" });
            }
            manager.Create(admin, "1234567890");
            manager.Create(teacher, "1234567890");
            manager.Create(student, "1234567890");

            var adminUser = manager.FindByName("Admin");
            var teacherUser = manager.FindByName("Teacher");
            var studentUser = manager.FindByName("Student");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin" });
            manager.AddToRoles(teacherUser.Id, new string[] { "Teacher" });
            manager.AddToRoles(studentUser.Id, new string[] { "Student" });
        }
    }
}
