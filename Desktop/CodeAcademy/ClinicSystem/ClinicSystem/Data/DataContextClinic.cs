using ClinicSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Data
{
    public  class DataContextClinic :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ALEZZ;Database=ClinicSystem;Integrated Security=true;TrustServerCertificate=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.Person_Id);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasMany(p => p.Appointment)
               .WithOne(a => a.person)
               .HasForeignKey(a => a.person_ID)
               .OnDelete(DeleteBehavior.Restrict);

            });
          
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasOne(p => p.person)
                .WithMany(Ap => Ap.Appointment)
               .HasForeignKey(p => p.person_ID);

                entity.HasOne(s => s.specialization)
                .WithMany(s => s.Appointment)
                .HasForeignKey(s => s.specialization_ID);

                
            });


        }


        public DbSet<Specialization> specialization { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
