using Nowadays.DTO.Company;
using Nowadays.Entity.Concrete;

namespace Nowadays.BLL.Abstract
{
    public interface ICompanyService
    {
        Task<bool> CompanyAdd(AddCompanyViewModel company);

        Task<bool> CompanyRemove(int entityId);

        Task<bool> CompanyUpdate(CompanyEditViewModel company);

        IEnumerable<CompanyListViewModel> GetAll();


        Task<Company> GetByIdAsync(int entityId);

    }
}
