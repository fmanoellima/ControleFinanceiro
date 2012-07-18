using Castle.Components.Validator;
using ControleFinanceiro.CORE.Resources;

namespace ControleFinanceiro.CORE.Models
{
    
    public class ChangePasswordModel
    {
        [ValidateNonEmpty(ErrorMessageKey = "RequiredOldPasswordMessage", ResourceType = typeof(ValidationsResource))]
        public string OldPassword { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredNewPasswordMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
        [ValidateLength(6, 100,null, ErrorMessageKey = "PasswordLengthValidationMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string NewPassword { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredConfirmPasswordMessage", ResourceType = typeof(ValidationsResource))]
        [ValidateSameAs("NewPassword", ErrorMessageKey = "InvalidConfirmPasswordMssage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string ConfirmPassword { get; set; }
        
    }

    public class LogOnModel
    {
        [ValidateNonEmpty(ErrorMessageKey = "RequiredUserNameMessage", ResourceType = typeof(ValidationsResource))]
        public string UserName { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredPasswordMessage", ResourceType = typeof(ValidationsResource))]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [ValidateNonEmpty(ErrorMessageKey = "RequiredUserNameMessage", ResourceType = typeof(ValidationsResource))]
        public string UserName { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredEmailMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
        [ValidateEmail(ErrorMessageKey = "InvalidEmailMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string Email { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredPasswordMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
        [ValidateLength(6, 100, null, ErrorMessageKey = "InvalidPasswordLengthMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string Password { get; set; }

        [ValidateNonEmpty(ErrorMessageKey = "RequiredConfirmPasswordMessage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 1)]
        [ValidateSameAs("Password", ErrorMessageKey = "InvalidConfirmPasswordMssage", ResourceType = typeof(ValidationsResource), ExecutionOrder = 2)]
        public string ConfirmPassword { get; set; }
    }
}
