using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using BLL.Objects;
using BLL.Interfaces;

namespace BLL.Tests
{
    public class GroupTests
    {
        [Test]
        public void Get_AddGroups_expect_Get2NotEqualToTeachers2()
        {
            //Arrange
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = null,
                    Teacher = null
                }
            };
            Group[] groups =
             {
                new Group
                {
                    CourseNumber = 1,
                    GroupNumber = 19,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 2,
                    GroupNumber = 16,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 3,
                    GroupNumber = 21,
                    Lessons = lessons
                },
            };
            Mock<IGroupService> service = new Mock<IGroupService>();
            service.Setup(mock => mock.Get(1)).Returns(groups[0]);
            service.Setup(mock => mock.Get(2)).Returns(groups[1]);
            service.Setup(mock => mock.Get(3)).Returns(groups[2]);
            Group expected = groups[2];
            int id = 2;

            //Act
            IGroupService Service = service.Object;
            Group actual = Service.Get(id);

            //Assert
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void GetAll_AddGroups_Expect_GetAllEqualToGroups()
        {
            //Arrange
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = null,
                    Teacher = null
                }
            };
            Group[] groups =
             {
                new Group
                {
                    CourseNumber = 1,
                    GroupNumber = 19,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 2,
                    GroupNumber = 16,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 3,
                    GroupNumber = 21,
                    Lessons = lessons
                },
            };
            List<Group> expected = new List<Group> { groups[0], groups[1], groups[2] };
            Mock<IGroupService> service = new Mock<IGroupService>();
            service.Setup(mock => mock.GetAll()).Returns(expected);

            //Act
            IGroupService Service = service.Object;
            List<Group> actual = Service.GetAll();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_AddGroups_Verify_MethodCalled()
        {
            //Arrange
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = null,
                    Teacher = null
                }
            };
            Group[] groups =
             {
                new Group
                {
                    CourseNumber = 1,
                    GroupNumber = 19,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 2,
                    GroupNumber = 16,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 3,
                    GroupNumber = 21,
                    Lessons = lessons
                },
            };
            Mock<IGroupService> service = new Mock<IGroupService>();
            service.Setup(mock => mock.Add(groups[0])).Verifiable();
            service.Setup(mock => mock.Add(groups[1])).Verifiable();
            service.Setup(mock => mock.Add(groups[2])).Verifiable();

            //Act
            IGroupService Service = service.Object;
            Service.Add(groups[0]);
            Service.Add(groups[1]);
            Service.Add(groups[2]);

            //Assert
            service.VerifyAll();
        }

        [Test]
        public void Remove_RemoveGroups_Verify_MethodCalled()
        {
            //Arrange
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = null,
                    Teacher = null
                }
            };
            Group[] groups =
             {
                new Group
                {
                    CourseNumber = 1,
                    GroupNumber = 19,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 2,
                    GroupNumber = 16,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 3,
                    GroupNumber = 21,
                    Lessons = lessons
                },
            };
            Mock<IGroupService> service = new Mock<IGroupService>();
            service.Setup(mock => mock.Remove(groups[0])).Verifiable();
            service.Setup(mock => mock.Remove(groups[1])).Verifiable();

            //Act
            IGroupService Service = service.Object;
            Service.Remove(groups[0]);
            Service.Remove(groups[1]);

            //Assert
            service.VerifyAll();
        }

        [Test]
        public void Update_ChangeGroups1_Verify_MethodCalled()
        {
            //Arrange
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = null,
                    Teacher = null
                }
            };
            Group[] groups =
             {
                new Group
                {
                    CourseNumber = 1,
                    GroupNumber = 19,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 2,
                    GroupNumber = 16,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 3,
                    GroupNumber = 21,
                    Lessons = lessons
                },
            };
            Mock<IGroupService> service = new Mock<IGroupService>();
            service.Setup(mock => mock.Update(1, groups[2])).Verifiable();

            //Act
            IGroupService Service = service.Object;
            Service.Update(1, groups[2]);

            //Assert
            service.VerifyAll();
        }

        [Test]
        public void GetLessons_AddGroups_Expect_GetLessons1EqualToGroups()
        {
            //Arrange
            List<Lesson> lessons = new List<Lesson>()
            {
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Thursday,
                    LessonNumber = 1,
                    LessonName = "Programming",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.SecondWeek,
                    DayOfTheWeek = Day.Monday,
                    LessonNumber = 3,
                    LessonName = "Math",
                    Group = null,
                    Teacher = null
                },
                new Lesson
                {
                    WeekNumber = Week.FirstWeek,
                    DayOfTheWeek = Day.Tuesday,
                    LessonNumber = 3,
                    LessonName = "Philosophy",
                    Group = null,
                    Teacher = null
                }
            };
            Group[] groups =
             {
                new Group
                {
                    CourseNumber = 1,
                    GroupNumber = 19,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 2,
                    GroupNumber = 16,
                    Lessons = lessons
                },
                new Group
                {
                    CourseNumber = 3,
                    GroupNumber = 21,
                    Lessons = lessons
                },
            };
            Mock<IGroupService> service = new Mock<IGroupService>();
            service.Setup(mock => mock.GetLessons(1)).Returns(lessons);
            IEnumerable<Lesson> expected = lessons;

            //Act
            IGroupService Service = service.Object;
            IEnumerable<Lesson> actual = Service.GetLessons(1);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
