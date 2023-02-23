using Dealership_Domain;
using Microsoft.EntityFrameworkCore;



namespace Dealership_Infrastructure.EntityFramework
{
    public class DealershipDbContext: DbContext
    {
        public DbSet<Advisor>? Advisors { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Bill>? Bills { get; set; }

        public DealershipDbContext(DbContextOptions<DealershipDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advisor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Id);
                entity.HasMany(d=>d.Bills).WithOne(p=>p.Advisor)
                .HasForeignKey(d=>d.IdAsvisor);

            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Id);
                entity.HasMany(d => d.Bills).WithOne(p => p.Customer)
                .HasForeignKey(d => d.IdCustomer);

            });
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Id);
                entity.HasMany(d => d.Bills).WithOne(p =>p.Car)
                .HasForeignKey(d => d.IdCar);

            });
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(x => x.Id);
                entity.HasOne(d => d.Car).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdCar);

                entity.HasOne(d => d.Advisor).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdAsvisor);

                entity.HasOne(d => d.Customer).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdCustomer);
            });

        }
        public DbSet<T> GetDbSet<T, TId>() where T : Entity<TId>
             where TId : IComparable, IComparable<TId>
        {
            return (DbSet<T>)this.GetType().GetProperties().FirstOrDefault(it =>
            typeof(DbSet<>).MakeGenericType(typeof(T)) == it.PropertyType)!.GetValue(this)!;
        }
    }
}
