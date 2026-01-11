using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Biblioteka.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var fk in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e.Library)
            //    .WithMany(l => l.Employees)
            //    .HasForeignKey(e => e.LibraryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Employee>()
            //    .HasOne(e => e.Address)
            //    .WithMany(a => a.Employees)
            //    .HasForeignKey(e => e.AddressId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Rent>()
            //    .HasOne(r => r.Employee)
            //    .WithMany(e => e.Rents)
            //    .HasForeignKey(r => r.EmpId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Rent>()
            //    .HasOne(r => r.Library)
            //    .WithMany(l => l.Rents)
            //    .HasForeignKey(r => r.LibraryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Rent>()
            //    .HasOne(r => r.Library)
            //    .WithMany(bc => bc.Rents)
            //    .HasForeignKey(r => r.CopyId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
