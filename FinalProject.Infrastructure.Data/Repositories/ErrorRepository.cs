using FinalProject.Core.ApplicationService;
using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Infrastructure.Data.Repositories
{
    public class ErrorRepository : IErrorRepository
    {
        readonly ErrorContext _ctx;

        public ErrorRepository(ErrorContext ctx)
        {
            _ctx = ctx;
        }

        public Error Create(Error error)
        {
            _ctx.Attach(error).State = EntityState.Added;
            _ctx.SaveChanges();
            return error;
        }

        public IEnumerable<Error> ReadAll(Filter filter)
        {
            if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
            {
                return _ctx.Errors.Include(p => p.Process);
            }
            return _ctx.Errors
                .Include(p => p.Process.ProcessName)
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Error ReadById(int id)
        {
            return _ctx.Errors.Include(e => e.Process).FirstOrDefault(e => e.Id == id);
        }

        public Error UpdateError(Error errorUpdate)
        {
            _ctx.Attach(errorUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return errorUpdate;
        }

        public Error DeleteError(int id)
        {
            var error = _ctx.Remove<Error>(new Error { Id = id });
            _ctx.SaveChanges();
            return error.Entity;
        }

        public int Count()
        {
            return _ctx.Errors.Count();
        }
    }
}
