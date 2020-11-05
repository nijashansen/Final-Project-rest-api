using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.ApplicationService
{
    public interface IErrorService
    {
        Error NewError(string errorDetail, string errorType);

        Error CreateError(Error error);

        Error FindErrorById(int id);

        List<Error> GetAllErrorsByDetail(string detail);

        List<Error> GetAllErrors();

        Error UpdateError(Error errorUpdate);

        Error DeleteError(int id);
    }
}
