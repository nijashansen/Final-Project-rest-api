using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infrastructure.Static.Data.Repositories
{
    public class ErrorRepository : IErrorRepository
    {
        public ErrorRepository()
        {
            if (FakeDB.Errors.Count >= 1) return;

            var error1 = new Error()
            {
                Id = FakeDB.Id++,
                ErrorDetail = "Failed",
                ErrorType = "SystemError",
            };
            FakeDB.Errors.Add(error1);

            var error2 = new Error()
            {
                Id = FakeDB.Id++,
                ErrorType = "Failed",
                ErrorDetail = "Buisness Exception",
            };
            FakeDB.Errors.Add(error2);
        }

        public Error Create(Error error)
        {
            error.Id = FakeDB.Id++;
            FakeDB.Errors.Add(error);
            return error;
        }

        public IEnumerable<Error> ReadAll()
        {
            return FakeDB.Errors;
        }

        public Error ReadById(int id)
        {
            foreach (var item in FakeDB.Errors)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public Error UpdateError(Error errorUpdate)
        {
            var errorFromDB = this.ReadById(errorUpdate.Id);
            if (errorFromDB != null)
            {
                errorFromDB.ErrorDetail = errorUpdate.ErrorDetail;
                errorFromDB.ErrorType = errorUpdate.ErrorType;
                return errorFromDB;
            }
            return null;
        }

        public Error DeleteError(int id)
        {
            var errorFound = this.ReadById(id);
            if (errorFound != null)
            {
                FakeDB.Errors.Remove(errorFound);
                return errorFound;
            }
            return null;
        }
    }
}
