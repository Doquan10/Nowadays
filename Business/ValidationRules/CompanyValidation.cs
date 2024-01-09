using FluentValidation;
using Nowadays.DTO.Company;
using Nowadays.Entity.Concrete;

namespace CreditRequest.BLL.ValidationRules
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {

            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket adı boş olamaz !");
            RuleFor(x => x.CompanyName).MaximumLength(50).WithMessage("Şirket adı maximum 50 karakter olabilir !");
            RuleFor(x => x.CompanyName).MinimumLength(5).WithMessage("Şirket adı minimum 5 karakter olmalıdır !");
        }
        public class EditCompanyValidation : AbstractValidator<CompanyEditViewModel>
        {
            public EditCompanyValidation()
            {

                RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket adı boş olamaz !");
                RuleFor(x => x.CompanyName).MaximumLength(50).WithMessage("Şirket adı maximum 50 karakter olabilir !");
                RuleFor(x => x.CompanyName).MinimumLength(5).WithMessage("Şirket adı minimum 5 karakter olmalıdır !");
            }

        }
        public class AddCompanyValidation : AbstractValidator<AddCompanyViewModel>
        {
            public AddCompanyValidation()
            {

                RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket adı boş olamaz !");
                RuleFor(x => x.CompanyName).MaximumLength(50).WithMessage("Şirket adı maximum 50 karakter olabilir !");
                RuleFor(x => x.CompanyName).MinimumLength(5).WithMessage("Şirket adı minimum 5 karakter olmalıdır !");
            }

        }
    }
}
