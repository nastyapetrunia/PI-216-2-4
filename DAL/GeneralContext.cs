using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DAL.Entities;
using DAL.Config;

namespace DAL
{
    public class GeneralContext : DbContext
    {
        public GeneralContext()
            : base("DbConnection")
        {
        }

        public GeneralContext(string conStr) : base(conStr)
        {
            Database.SetInitializer(new GeneralInitializer());
            var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LessonConfig());
            modelBuilder.Configurations.Add(new GroupConfig());
            modelBuilder.Configurations.Add(new TeacherConfig());
        }
    }
}
