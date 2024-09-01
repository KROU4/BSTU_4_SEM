using Lab_11.Models;
using System.Data.Entity;

namespace Lab_11.Database
{
    public class SpecializeContext : DbContext
    {
        public DbSet<Specialize> Specializes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        static SpecializeContext()
        {
        }

        public SpecializeContext() : base("name=Test")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialize>()
                .HasMany(c => c.Customers)
                .WithMany(s => s.Specializes)
                .Map(cs =>
                {
                    cs.MapLeftKey("SpecializeId");
                    cs.MapRightKey("CustomerId");
                    cs.ToTable("SpecializeCustomers");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
