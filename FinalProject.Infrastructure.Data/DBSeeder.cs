using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infrastructure.Data
{
    public class DBSeeder
    {
        public static void SeedDB(ErrorContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            ctx.Errors.Add(new Error()
            {
                ErrorDetail = "failed to do stuff",
                ErrorType = "my kind of error"
            });
            ctx.Errors.Add(new Error()
            {
                ErrorDetail = "Something went wrong",
                ErrorType = "Fejl 40"
            });
            ctx.Errors.Add(new Error()
            {
                ErrorDetail = "i died trying to execute some code",
                ErrorType = "youre just stupid"
            });
            ctx.SaveChanges();
        }

    }
}
