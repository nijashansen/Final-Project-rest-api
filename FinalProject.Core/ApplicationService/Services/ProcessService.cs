using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FinalProject.Core.ApplicationService.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IProcessRepository _processRepo;

        public ProcessService(IProcessRepository processRepository)
        {
            _processRepo = processRepository;
        }
        public Process NewProcess(string processName, List<Error> errors)
        {
            var process = new Process()
            {
                ProcessName = processName,
                Errors = errors
            };

            return process;
        }

        public Process CreateProcess(Process process)
        {
            return _processRepo.CreateProcess(process);
        }

        public Process FindProcessById(int id)
        {
            return _processRepo.ReadById(id);
        }

        public Process ReadByIdIncludeErrors(int id)
        {
            return _processRepo.ReadByIdIncludeErrors(id);
        }

        public List<Process> GetAllProcesses()
        {
            return _processRepo.ReadAll().ToList();
        }

        public List<Process> GetFilteredProcesses(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("Currentpage and itemsprpage cant be 0");
            }
            return _processRepo.ReadAll(filter).ToList();
        }

        public Process UpdateProcess(Process processUpdate)
        {
            return _processRepo.UpdateProcess(processUpdate);
        }

        public Process DeleteProcess(int id)
        {
            return _processRepo.DeleteProcess(id);
        }

        public Process CheckProcess(Process processToCheck)
        {
            return _processRepo.checkIfProcessExists(processToCheck);
        }
    }
}
