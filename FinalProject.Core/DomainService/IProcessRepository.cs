using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DomainService
{
    public interface IProcessRepository
    {
        #region C.R.U.D

        Process CreateProcess(Process process);

        Process ReadById(int id);

        Process ReadByIdIncludeErrors(int id); 

        IEnumerable<Process> ReadAll(Filter filter = null);

        Process UpdateProcess(Process errorUpdate);

        Process DeleteProcess(int id);

        int Count();

        Process checkIfProcessExists(Process process);

        #endregion
    }
}
