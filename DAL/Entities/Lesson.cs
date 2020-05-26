using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Lessons")]
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LessonId { get; set; }

        public Week WeekNumber { get; set; }
        public Day DayOfTheWeek { get; set; }
        public int LessonNumber { get; set; }
        public string LessonName { get; set; }

        [ForeignKey("Group")]
        public virtual int GroupId { get; set; }
        public virtual Group Group { get; set; }

        [ForeignKey("Teacher")]
        public virtual int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
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
