using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Config
{
    public class TeacherConfig : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfig()
        {
            this.ToTable("Teachers");

            this.HasMany<Lesson>(t => t.Lessons)
                .WithRequired(s => s.Teacher)
                .HasForeignKey<int>(s => s.TeacherId)
                .WillCascadeOnDelete();
        }
    }
}