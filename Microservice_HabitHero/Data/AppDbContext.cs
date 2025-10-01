﻿using Microservice_HabitHero.Model;
using Microsoft.EntityFrameworkCore;

namespace Microservice_HabitHero.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<Habit> Habits { get; set; }


        // Necessário para os retornos, com enfase nos verbos http GET.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habit>()
                .Property(h => h.goalType)
                .HasConversion<string>(); // Converte o enum para string

        }
    }
}
