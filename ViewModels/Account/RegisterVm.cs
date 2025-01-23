using FluentValidation;

namespace CakeFinalApp.ViewModels.Account
{
    public record RegisterVm
    {
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
    public class RegisterValidation : AbstractValidator<RegisterVm>
    {
        public RegisterValidation()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin uzunluqu en az 4 olmalidi");

            RuleFor(x=>x.UserName).NotNull().NotEmpty().WithMessage("Ad bos ola bilmez")
                .MinimumLength(4).WithMessage("Adin uzunluqu en az 4 olmalidi");

            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email bos ola bilmez")
                .EmailAddress().WithMessage("Email duzgun deyil");

            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Parol bos ola bilmez")
                .Matches("[A-Z]").WithMessage("Parolda en az 1 boyuk herf olmaidi")
                .Matches("[a-z]").WithMessage("Parolda en az 1 kicik herf olmaidi")
                .Matches("[0-9]").WithMessage("Parolda en az 1 reqem olmaidi")
                .Matches("^[A-Za-z0-9]").WithMessage("Parolda en az 1 simvol olmaidi");

            RuleFor(x=>x).Must(x=>x.Password==x.ConfirmPassword).WithMessage("Parol eyni deyil");





        }
    }
}
