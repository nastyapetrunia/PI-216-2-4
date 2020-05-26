using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using BLL.Objects;
using BLL.Interfaces;

namespace BLL.Tests
{
    public class LessonTests
    {
        [Test]
        public void Get_AddLessons_expect_Get2EqualToLessons1()
        {
            //Arrange
            Teacher teacher = new Teacher
            {
                Name = "Roman",
                Surname = "Kutsenko",
                Post = "Teacher",
                Lessons = new List<Lesson>()
            };
            Group group = new Group
            {
                CourseNumber = 1,
                GroupNumber = 19,
                Lessons = new List<Lesson>()
            };
            Lesson[] lessons =
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = group,
                    Teacher = teacher
                }
            };
            Mock<ILessonService> service = new Mock<ILessonService>();
            service.Setup(mock => mock.Get(1)).Returns(lessons[0]);
            service.Setup(mock => mock.Get(2)).Returns(lessons[1]);
            service.Setup(mock => mock.Get(3)).Returns(lessons[2]);
            Lesson expected = lessons[1];
            int id = 2;

            //Act
            ILessonService Service = service.Object;
            Lesson actual = Service.Get(id);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAll_AddLessons_Expect_GetAllEqualToLessons()
        {
            //Arrange
            Teacher teacher = new Teacher
            {
                Name = "Roman",
                Surname = "Kutsenko",
                Post = "Teacher",
                Lessons = new List<Lesson>()
            };
            Group group = new Group
            {
                CourseNumber = 1,
                GroupNumber = 19,
                Lessons = new List<Lesson>()
            };
            Lesson[] lessons =
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = group,
                    Teacher = teacher
                }
            };
            List<Lesson> expected = new List<Lesson> { lessons[0], lessons[1], lessons[2] };
            Mock<ILessonService> service = new Mock<ILessonService>();
            service.Setup(mock => mock.GetAll()).Returns(expected);

            //Act
            ILessonService Service = service.Object;
            List<Lesson> actual = Service.GetAll();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_AddLesson_Verify_MethodCalled()
        {
            //Arrange
            Teacher teacher = new Teacher
            {
                Name = "Roman",
                Surname = "Kutsenko",
                Post = "Teacher",
                Lessons = new List<Lesson>()
            };
            Group group = new Group
            {
                CourseNumber = 1,
                GroupNumber = 19,
                Lessons = new List<Lesson>()
            };
            Lesson[] lessons =
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = group,
                    Teacher = teacher
                }
            };
            Mock<ILessonService> service = new Mock<ILessonService>();
            service.Setup(mock => mock.Add(lessons[0])).Verifiable();
            service.Setup(mock => mock.Add(lessons[1])).Verifiable();
            service.Setup(mock => mock.Add(lessons[2])).Verifiable();

            //Act
            ILessonService Service = service.Object;
            Service.Add(lessons[0]);
            Service.Add(lessons[1]);
            Service.Add(lessons[2]);

            //Assert
            service.VerifyAll();
        }

        [Test]
        public void Remove_RemoveLesson_Verify_MethodCalled()
        {
            //Arrange
            Teacher teacher = new Teacher
            {
                Name = "Roman",
                Surname = "Kutsenko",
                Post = "Teacher",
                Lessons = new List<Lesson>()
            };
            Group group = new Group
            {
                CourseNumber = 1,
                GroupNumber = 19,
                Lessons = new List<Lesson>()
            };
            Lesson[] lessons =
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = group,
                    Teacher = teacher
                }
            };
            Mock<ILessonService> service = new Mock<ILessonService>();
            service.Setup(mock => mock.Remove(lessons[0])).Verifiable();
            service.Setup(mock => mock.Remove(lessons[1])).Verifiable();

            //Act
            ILessonService Service = service.Object;
            Service.Remove(lessons[0]);
            Service.Remove(lessons[1]);

            //Assert
            service.VerifyAll();
        }

        [Test]
        public void Update_ChangeLessons1_Verify_MethodCalled()
        {
            //Arrange
            Teacher teacher = new Teacher
            {
                Name = "Roman",
                Surname = "Kutsenko",
                Post = "Teacher",
                Lessons = new List<Lesson>()
            };
            Group group = new Group
            {
                CourseNumber = 1,
                GroupNumber = 19,
                Lessons = new List<Lesson>()
            };
            Lesson[] lessons =
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = group,
                    Teacher = teacher
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = group,
                    Teacher = teacher
                }
            };
            Mock<ILessonService> service = new Mock<ILessonService>();
            service.Setup(mock => mock.Update(1, lessons[2])).Verifiable();

            //Act
            ILessonService Service = service.Object;
            Service.Update(1, lessons[2]);

            //Assert
            service.VerifyAll();
        }
    }
}