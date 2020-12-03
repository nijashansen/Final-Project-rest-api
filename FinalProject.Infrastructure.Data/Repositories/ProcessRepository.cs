using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Infrastructure.Data.Repositories
{
    public class ProcessRepository : IProcessRepository
    {
        readonly ErrorContext _ctx;

        public ProcessRepository(ErrorContext ctx)
        {
            _ctx = ctx;
        }

        public Process CreateProcess(Process process)
        {
            var madeProcess = new Process { ProcessName = process.ProcessName, Errors = new List<Error>() };
            _ctx.Processes.Add(madeProcess);
            _ctx.SaveChanges();
            return madeProcess;
        }
        public IEnumerable<Process> ReadAll(Filter filter = null)
        {
            if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
            {
                return _ctx.Processes.Include(p => p.Errors);
            }
            return _ctx.Processes
                .Include(p => p.Errors)
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Process ReadById(int id)
        {
            return _ctx.Processes.FirstOrDefault(p => p.Id == id);
        }

        private Process ReadByName(string processName)
        {
            return _ctx.Processes.FirstOrDefault(p => p.ProcessName == processName);
        }

        public Process checkIfProcessExists(Process process)
        {
            var processFound = ReadByName(process.ProcessName);
            if (processFound == null)
            {
                return null;
            }
            return processFound;
        }

        public Process ReadByIdIncludeErrors(int id)
        {
            var processToReturn = _ctx.Processes
                .Include(p => p.Errors)
                .FirstOrDefault(p => p.Id == id);
            return processToReturn;
        }

        public Process UpdateProcess(Process processUpdate)
        {
            _ctx.Attach(processUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return processUpdate;
        }

        public Process DeleteProcess(int id)
        {
            var error = _ctx.Remove<Process>(new Process { Id = id });
            _ctx.SaveChanges();
            return error.Entity;
        }

        public int Count()
        {
            return _ctx.Processes.Count();
        }
    }
}
