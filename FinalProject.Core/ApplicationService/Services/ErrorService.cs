using FinalProject.Core.DomainService;
using FinalProject.Core.Entity;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public List<Error> GetFilteredErrors(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0 )
            {
                throw new InvalidDataException("Currentpage and itemsprpage cant be 0");
            }
            return _errorRepo.ReadAll(filter).ToList();
        }

        public List<Error> GetAllErrorsByDetail(string detail)
        {
            var list = _errorRepo.ReadAll();
            var query = list.Where(error => error.ErrorDetail.Equals(detail));

            return query.ToList();
        }

        public Error UpdateError(Error errorUpdate)
        {
            return _errorRepo.UpdateError(errorUpdate);
        }

        public Error DeleteError(int id)
        {
            return _errorRepo.DeleteError(id);
        }

        
    }
}
