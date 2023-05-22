using Diploma.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.DataContexts
{
    public class DiplomaDbContext : DbContext
    {
        public DiplomaDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<University> Universities { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<ScientificWork> ScientificWorks { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
    }
}
