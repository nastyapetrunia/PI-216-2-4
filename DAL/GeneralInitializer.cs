using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL
{
    class GeneralInitializer : DropCreateDatabaseIfModelChanges<GeneralContext>
    {
        protected override void Seed(GeneralContext context)
        {
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


            context.Lessons.Add(lesson1);
            context.Lessons.Add(lesson2);
            context.Teachers.Add(teacher1);
            context.Teachers.Add(teacher2);
            context.Groups.Add(group1);
            context.Groups.Add(group2);

            context.SaveChanges();
        }
    }
}


