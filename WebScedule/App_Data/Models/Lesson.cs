using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSchedule.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }

        public Week WeekNumber { get; set; }
        public Day DayOfTheWeek { get; set; }
        public int LessonNumber { get; set; }
        public string LessonName { get; set; }

        public virtual int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

    public class LessonViewModel
    {
        public int LessonId { get; set; }

        public Week WeekNumber { get; set; }
        public Day DayOfTheWeek { get; set; }
        public int LessonNumber { get; set; }
        public string LessonName { get; set; }

        public virtual int GroupId { get; set; }

        public virtual int TeacherId { get; set; }
    }

    public enum Day
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public enum Week
    {
        FirstWeek = 1,
        SecondWeek
    }
}