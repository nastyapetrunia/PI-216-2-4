using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("Ratings")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Post { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
