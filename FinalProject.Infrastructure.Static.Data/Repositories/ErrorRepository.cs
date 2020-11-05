using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Infrastructure.Static.Data.Repositories
{
    public class ErrorRepository : IErrorRepository
    {
        private List<Error> _errors = new List<Error>();
        static int id = 1;

        public ErrorRepository()
        {

        }

        public Error Create(Error error)
        {
            error.Id = id++;
            _errors.Add(error);
            return error;
        }

        public IEnumerable<Error> ReadAll()
        {
            return _errors;
        }

        public Error ReadById(int id)
        {
            foreach (var item in _errors)
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
                _errors.Remove(errorFound);
                return errorFound;
            }
            return null;
        }
    }
}
