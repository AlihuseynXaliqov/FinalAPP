using FluentValidation;

namespace CakeFinalApp.Areas.Manage.ViewModels.Position
{
    public class CreatePositionVm
    {
        public string Name { get; set; }
    }
    public class CreatePositionValidation : AbstractValidator<CreatePositionVm>
    {
        public CreatePositionValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin uzunluqu en az 4 olmalidi");
        }
    }
}
