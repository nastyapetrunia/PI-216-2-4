using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSchedule.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Post { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Post { get; set; }
    }
}
