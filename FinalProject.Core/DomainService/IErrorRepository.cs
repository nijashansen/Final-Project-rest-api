using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Core.DomainService
{
    public interface IErrorRepository
    {
        #region C.R.U.D

        Error Create(Error error);

        Error ReadById(int id);

        IEnumerable<Error> ReadAll();

        Error UpdateError(Error errorUpdate);

        Error DeleteError(int id);

        #endregion
    }
}
