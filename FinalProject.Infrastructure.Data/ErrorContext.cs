using FinalProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infrastructure.Data
{
    public class ErrorContext: DbContext
    {
        public ErrorContext(DbContextOptions<ErrorContext> opt): base(opt)
        {

        }

        public DbSet<Error> Errors { get; set; }
    }
}
