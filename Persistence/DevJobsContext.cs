using DevJobs.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevJobs.API.Persistence
{
    public class DevJobsContext : DbContext
    {
        public DevJobsContext(DbContextOptions<DevJobsContext> context) : base(context)
        {

        }
        public DbSet<JobVacancy> JobVacancies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<JobVacancy>(e => {
                e.HasKey(jv => jv.Id);

                e.HasMany(jv => jv.Applications)
                    .WithOne()
                    .HasForeignKey(ja => ja.IdJob)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<JobApplication>(e => {
                e.HasKey(ja => ja.Id);
            });
        }
    }
}