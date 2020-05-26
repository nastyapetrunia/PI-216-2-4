using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Ratings")]
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        public int CourseNumber { get; set; }
        public int GroupNumber { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
