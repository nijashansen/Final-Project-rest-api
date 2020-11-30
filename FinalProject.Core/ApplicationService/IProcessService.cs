using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.ApplicationService.Services
{
    public interface IProcessService
    {
        Process NewProcess(string processName, List<Error> errors);

        Process CreateProcess(Process process);

        Process FindProcessById(int id);

        Process ReadByIdIncludeErrors(int id);

        List<Process> GetAllProcesses();

        List<Process> GetFilteredProcesses(Filter filter);

        Process UpdateProcess(Process processUpdate);

        Process DeleteProcess(int id);

        Process CheckProcess(Process processToCheck);
    }
}
