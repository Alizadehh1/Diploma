using Diploma.WebUI.Models.Entities;
using Diploma.WebUI.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.WebUI.Models.DataContexts
{
    public class DiplomaDbContext : IdentityDbContext<DiplomaUser, DiplomaRole, int, DiplomaUserClaim, DiplomaUserRole, DiplomaUserLogin, DiplomaRoleClaim, DiplomaUserToken>
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
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DiplomaUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });
            builder.Entity<DiplomaRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });
            builder.Entity<DiplomaUserRole>(e =>
            {
                e.ToTable("UserRoles", "Membership");
            });
            builder.Entity<DiplomaUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });
            builder.Entity<DiplomaRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });
            builder.Entity<DiplomaUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Membership");
            });
            builder.Entity<DiplomaUserToken>(e =>
            {
                e.ToTable("UserTokens", "Membership");
            });
        }

    }
}
