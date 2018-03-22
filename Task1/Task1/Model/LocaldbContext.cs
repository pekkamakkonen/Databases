using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task1.Model
{
    public partial class LocaldbContext : DbContext
    {
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-RT1ABEOL\SQLEXPRESS;Initial Catalog=LocalDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Phone_Person1");
            });
        }
    }
}
