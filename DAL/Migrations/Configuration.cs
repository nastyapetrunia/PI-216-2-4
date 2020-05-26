namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.GeneralContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }
        }

        protected override void Seed(DAL.GeneralContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            Group group1 = new Group()
            {
                CourseNumber = 2,
                GroupNumber = 216,
                Lessons = new List<Lesson>()
            };
            Group group2 = new Group()
            {
                CourseNumber = 3,
                GroupNumber = 313,
                Lessons = new List<Lesson>()
            };

            Teacher teacher1 = new Teacher()
            {
                Name = "Ivan",
                Surname = "Ivanov",
                Post = "Teacher",
                Lessons = new List<Lesson>()
            };
            Teacher teacher2 = new Teacher()
            {
                Name = "Petr",
                Surname = "Petrov",
                Post = "Teacher",
                Lessons = new List<Lesson>()
            };

            Lesson lesson1 = new Lesson()
            {
                WeekNumber = Week.SecondWeek,
                DayOfTheWeek = Day.Saturday,
                LessonNumber = 1,
                LessonName = "Programming",
                Group = group1,
                Teacher = teacher1
            };
            Lesson lesson2 = new Lesson()
            {
                WeekNumber = Week.FirstWeek,
                DayOfTheWeek = Day.Tuesday,
                LessonNumber = 4,
                LessonName = "Philosophy",
                Group = group2,
                Teacher = teacher2
            };

            group1.Lessons.Add(lesson1);
            group2.Lessons.Add(lesson2);
            teacher1.Lessons.Add(lesson1);
            teacher2.Lessons.Add(lesson2);


            context.Lessons.AddOrUpdate(lesson1);
            context.Lessons.AddOrUpdate(lesson2);
            context.Teachers.AddOrUpdate(teacher1);
            context.Teachers.AddOrUpdate(teacher2);
            context.Groups.AddOrUpdate(group1);
            context.Groups.AddOrUpdate(group2);

            context.SaveChanges();
        }
    }
}
