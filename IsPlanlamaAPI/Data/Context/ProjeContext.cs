using IsPlanlamaAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IsPlanlamaAPI.Data.Context
{
    public class ProjeContext : DbContext
    {
        public ProjeContext(DbContextOptions<ProjeContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=KUBRA;Initial Catalog=IsPlanlama2;Integrated Security=True;TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Plan> Plans { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Plan>()
        //        .Property(p => p.Status)
        //        .HasConversion<string>()   // enum → string
        //        .HasMaxLength(50);         // nvarchar(50)
        //}

    }

}

