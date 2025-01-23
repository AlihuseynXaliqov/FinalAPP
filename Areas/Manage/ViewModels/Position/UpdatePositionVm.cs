using FluentValidation;

namespace CakeFinalApp.Areas.Manage.ViewModels.Position
{
    public class UpdatePositionVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdatePositionValidation : AbstractValidator<UpdatePositionVm>
    {
        public UpdatePositionValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin uzunluqu en az 4 olmalidi");
        }
    }
}
