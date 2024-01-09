using Nowadays.BLL.Abstract;
using Nowadays.DAL.UnitOfWork.Abstract;
using Nowadays.DTO.Company;
using Nowadays.Entity.Concrete;

namespace Nowadays.BLL.Concrete
{
    public class CompanyService : ICompanyService
    {
        public IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CompanyAdd(AddCompanyViewModel company)
        {
            var newCompany = new Company{

                CompanyName = company.CompanyName,
            };
            await _unitOfWork.CompanyRepository.InsertAsync(newCompany);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> CompanyRemove(int entityId)
        {
            var item = await _unitOfWork.CompanyRepository.GetByIdAsync(entityId);

             await _unitOfWork.CompanyRepository.Delete(item);
             await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> CompanyUpdate(CompanyEditViewModel company)
        {
            var item = await GetByIdAsync(company.Id);

            if (item is null)
            {
                throw new Exception("Şirket Bulunamadı");
            }

            item.CompanyName = company.CompanyName;


            await _unitOfWork.CompanyRepository.UpdateAsync(item);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public IEnumerable<CompanyListViewModel> GetAll()
        {
            var companyList =  _unitOfWork.CompanyRepository.GetAll().Select(x => new CompanyListViewModel
            {
                CompanyName = x.CompanyName,
            }).ToList();

            return companyList;
        }
        public async Task<Company> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.CompanyRepository.GetByIdAsync(entityId);
        }

    }
}
