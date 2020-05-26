using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace DAL.Config
{
    public class GroupConfig : EntityTypeConfiguration<Group>
    {
        public GroupConfig()
        {
            this.ToTable("Groups");

            this.HasMany<Lesson>(g => g.Lessons)
                .WithRequired(s => s.Group)
                .HasForeignKey<int>(s => s.GroupId)
                .WillCascadeOnDelete();
        }
    }
}
