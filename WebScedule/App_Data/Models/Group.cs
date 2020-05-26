using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSchedule.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public int CourseNumber { get; set; }
        public int GroupNumber { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
    public class GroupViewModel
    {
        public int GroupId { get; set; }

        public int CourseNumber { get; set; }
        public int GroupNumber { get; set; }

    }
}