using FinalProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infrastructure.Data
{
    public class ErrorContext: DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<User> Users { get; set; }

        public ErrorContext(DbContextOptions<ErrorContext> opt): base(opt)
        {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Process>()
                .HasMany(e => e.Errors)
                .WithOne(p => p.Process) 
                .OnDelete(DeleteBehavior.Cascade) ;
            
        }
    }
}
