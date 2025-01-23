using FluentValidation;

namespace CakeFinalApp.ViewModels.Account
{
    public class LoginVm
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginValidation : AbstractValidator<LoginVm>
    {
        public LoginValidation()
        {
            RuleFor(x => x.EmailOrUserName).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();

        }
    }
}
