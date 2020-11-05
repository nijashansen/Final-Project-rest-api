using FinalProject.Core.ApplicationService;
using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using FinalProject.Infrastructure.Static.Data.Repositories;
using System;

namespace consoleapp
{
    class Printer: IPrinter
    {
        private IErrorService _errorService;

        public Printer(IErrorService errorService)
        {
            _errorService = errorService;
        }

        public void start()
        {
            var error = new Error()
            {
                ErrorDetail = "dead",
                ErrorType = "system"
            };

            var error1 = new Error()
            {
                ErrorDetail = "dead",
                ErrorType = "system"
            };

            _errorService.CreateError(error);
            _errorService.CreateError(error1);

            foreach (var item in _errorService.GetAllErrors())
            {
                Console.WriteLine("id: " + item.Id + ", Error Detail: " + item.ErrorDetail + ", Error Type: " + item.ErrorType );
            }


        }
    }
}
