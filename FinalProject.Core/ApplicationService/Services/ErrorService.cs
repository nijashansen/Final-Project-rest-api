using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Core.ApplicationService.Services
{
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _errorRepo;

        public ErrorService(IErrorRepository errorRepository)
        {
            _errorRepo = errorRepository;
        }

        public Error NewError(string errorDetail, string errorType)
        {
            var error = new Error()
            {
                ErrorDetail = errorDetail,
                ErrorType = errorType
            };

            return error;
        }

        public Error CreateError(Error error)
        {
            return _errorRepo.Create(error);
        }

        public Error FindErrorById(int id)
        {
            return _errorRepo.ReadById(id);
        }

        public List<Error> GetAllErrors()
        {
            return _errorRepo.ReadAll().ToList();
        }

        public List<Error> GetAllErrorsByDetail(string detail)
        {
            var list = _errorRepo.ReadAll();
            var query = list.Where(error => error.ErrorDetail.Equals(detail));

            return query.ToList();
        }

        public Error UpdateError(Error errorUpdate)
        {
            var error = FindErrorById(errorUpdate.Id);
            error.ErrorDetail = errorUpdate.ErrorDetail;
            error.ErrorType = errorUpdate.ErrorType;
            return error;
        }

        public Error DeleteError(int id)
        {
            return _errorRepo.DeleteError(id);
        }
    }
}
