using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCalendar.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename="+ Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Schedules)
                .WithOne(s => s.Employer)
                .HasForeignKey(s => s.EmployerId);
            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Shifts)
                .WithOne(sh => sh.Schedule)
                .HasForeignKey(sh => sh.ScheduleId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Shifts)
                .WithOne(sh => sh.Worker)
                .HasForeignKey(sh => sh.WorkerId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Requests)
                .WithOne(r => r.Worker)
                .HasForeignKey(r => r.WorkerId);
            modelBuilder.Entity<Shift>()
                .HasOne(sh => sh.Request)
                .WithOne(r => r.Shift)
                .HasForeignKey<Request>(r => r.ShiftId);
        }
    }
}
