using FluentValidation;

namespace CakeFinalApp.Areas.Manage.ViewModels.Agent
{
    public class CreateAgentVm
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int PositionId { get; set; }
        public IFormFile formFile { get; set; }
    }
    public class CreateAgentValidation : AbstractValidator<CreateAgentVm>
    {
        public CreateAgentValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ad bos ola bilmez")
               .MinimumLength(4).WithMessage("Adin uzunluqu en az 4 olmalidi");
            RuleFor(x => x.formFile).NotNull().NotEmpty().WithMessage("Sekil bos ola bilmez");
            RuleFor(x => x.PositionId).NotNull().NotEmpty().WithMessage("Position sec");

        }
    }
}