using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Config
{
    public class LessonConfig : EntityTypeConfiguration<Lesson>
    {
        public LessonConfig()
        {
            this.ToTable("Lessons");
        }
    }
}
