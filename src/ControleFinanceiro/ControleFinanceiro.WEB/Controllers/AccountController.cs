using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using Castle.Components.Validator;
using ControleFinanceiro.CORE.Models;
using ControleFinanceiro.CORE.Components;
using ControleFinanceiro.CORE.Resources;
using ControleFinanceiro.Helpers;
using ControleFinanceiro.WEB.Attributes;
using Autofac;

namespace ControleFinanceiro.WEB.Controllers
{
    public class AccountController : Controller
    {
        #region Propriedades de requisições

        private string UserName
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["UserName"]))
                    return HttpContext.Request["UserName"];

                return String.Empty;
            }
        }

        private string Password
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["Password"]))
                    return HttpContext.Request["Password"];

                return String.Empty;
            }
        }

        private string NewPassword
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["NewPassword"]))
                    return HttpContext.Request["NewPassword"];

                return String.Empty;
            }
        }

        private string OldPassword
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["OldPassword"]))
                    return HttpContext.Request["OldPassword"];

                return String.Empty;
            }
        }

        private string ConfirmPassword
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["ConfirmPassword"]))
                    return HttpContext.Request["ConfirmPassword"];

                return String.Empty;
            }
        }

        private bool RememberMe
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["RememberMe"]))
                    return bool.Parse(HttpContext.Request["RememberMe"].ToLower());

                return false;
            }
        }

        private string ReturnUrl
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["ReturnUrl"]))
                    return HttpContext.Request["ReturnUrl"].ToLower();

                return String.Empty;
            }
        }

        private string Email
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["Email"]))
                    return HttpContext.Request["Email"];

                return String.Empty;
            }
        }
        
        #endregion

        #region Atributos

        private readonly Feedback _feed;
        private readonly JsonResult _jResult;
        private readonly IValidatorRunner _validationRunner;

        #endregion

        public AccountController(JsonResult jResult, IValidatorRunner validationRunner, Feedback feed)
        {
            _validationRunner = validationRunner;
            _feed = feed;
            _jResult = jResult;
        }

        // GET: /Account/LogOn
        public ActionResult LogOn()
        {
            return View();
        }

        // GET: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        // GET: /Account/ChangePassword
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }


        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return ValidationsResource.DuplicateUserNameMessage;

                case MembershipCreateStatus.DuplicateEmail:
                    return ValidationsResource.DuplicateEmailMessage;

                case MembershipCreateStatus.InvalidPassword:
                    return ValidationsResource.InvalidPasswordMessage;

                case MembershipCreateStatus.InvalidEmail:
                    return ValidationsResource.InvalidEmailMessage;

                case MembershipCreateStatus.InvalidAnswer:
                    return ValidationsResource.InvalidAnswerMessage;

                case MembershipCreateStatus.InvalidQuestion:
                    return ValidationsResource.InvalidQuestionMessage;

                case MembershipCreateStatus.InvalidUserName:
                    return ValidationsResource.InvalidUserNameMessage;

                case MembershipCreateStatus.ProviderError:
                    return ValidationsResource.ProviderErrorMessage;

                case MembershipCreateStatus.UserRejected:
                    return ValidationsResource.UserRejectedMessage;

                default:
                    return MessagesResource.UnknownErrorMessage;
            }
        }
        #endregion


        public JsonResult LogOnAjax()
        {
            var model = new LogOnModel
                                    {
                                       UserName = UserName,
                                       Password = Password,
                                       RememberMe = RememberMe
                                    };
            try
            {
                if (_validationRunner.IsValid(model))
                {
                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        _feed.Status = Feedback.TypeFeedback.Success;
                    }
                    else
                    {
                        _feed.Status = Feedback.TypeFeedback.Success;
                        _feed.Message.Add(MessagesResource.CouldNotAuthenticateUser);
                    }
                }
                else
                {
                    var formatedErrorSummary = GetFormatedErrorSummary(model);
                    _feed.Status = Feedback.TypeFeedback.Success;
                    _feed.Message.Add(formatedErrorSummary);
                }
                
            }
            catch (Exception error)
            {
                _feed.Status = Feedback.TypeFeedback.Error;
                _feed.Message.Add(error.Message);
            }

            _jResult.Data = _feed;
            return _jResult;
        }

        public JsonResult RegisterUserAjax()
        {
            var model = new RegisterModel
            {
                UserName = UserName,
                Password = Password,
                Email = Email,
                ConfirmPassword = ConfirmPassword
            };

            try{

                if (_validationRunner.IsValid(model))
                {
                    MembershipCreateStatus createStatus;
                    Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                    if (createStatus == MembershipCreateStatus.Success)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    }
                    else
                    {
                        _feed.Status = Feedback.TypeFeedback.Success;
                        _feed.Message.Add(ErrorCodeToString(createStatus));
                    }
                }
                else
                {
                    var formatedErrorSummary = GetFormatedErrorSummary(model);
                    _feed.Status = Feedback.TypeFeedback.Success;
                    _feed.Message.Add(formatedErrorSummary);
                }

             }
            catch (Exception error)
            {
                _feed.Status = Feedback.TypeFeedback.Error;
                _feed.Message.Add(error.Message);
            }

            _jResult.Data = _feed;
            return _jResult;
        }

        [Authorize]
        public ActionResult ChangePasswordAjax()
        {
            var model = new ChangePasswordModel
            {
                OldPassword = OldPassword,
                NewPassword = NewPassword,
                ConfirmPassword = ConfirmPassword
            };

            try
            {

                if (_validationRunner.IsValid(model))
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    bool changePasswordSucceeded = currentUser != null && currentUser.ChangePassword(model.OldPassword, model.NewPassword);

                    if (changePasswordSucceeded)
                    {
                        _feed.Status = Feedback.TypeFeedback.Success;
                    }
                    else
                    {
                        _feed.Status = Feedback.TypeFeedback.Success;
                        _feed.Message.Add(MessagesResource.CouldNotAuthenticateUser);
                    }
                }
                else
                {
                    var formatedErrorSummary = GetFormatedErrorSummary(model);
                    _feed.Status = Feedback.TypeFeedback.Success;
                    _feed.Message.Add(formatedErrorSummary);
                }

            }
            catch (Exception error)
            {
                _feed.Status = Feedback.TypeFeedback.Error;
                _feed.Message.Add(error.Message);
            }

            _jResult.Data = _feed;
            return _jResult;

        }


        public JsonResult GetLogOnValidationRules()
        {
            try
            {
                var validationModel = ClientSideValidationHelper.ClientSideValidation(new LogOnModel());

                _feed.Status = Feedback.TypeFeedback.Success;
                _feed.Output = validationModel;
                  
            }
            catch (Exception error)
            {
                _feed.Status = Feedback.TypeFeedback.Error;
                _feed.Message.Add(error.Message);
            }

            _jResult.Data = _feed;
            return _jResult;
        }

        public JsonResult GetRegisterValidationRules()
        {

            try
            {
                var validationModel = ClientSideValidationHelper.ClientSideValidation(new RegisterModel());

                _feed.Status = Feedback.TypeFeedback.Success;
                _feed.Output = validationModel;
            }
            catch (Exception error)
            {
                _feed.Status = Feedback.TypeFeedback.Error;
                _feed.Message.Add(error.Message);
            }

            _jResult.Data = _feed;
            return _jResult;
        }

        [Authorize]
        public JsonResult GetChangePasswordValidationRules()
        {
            try
            {
                var validationModel = ClientSideValidationHelper.ClientSideValidation(new ChangePasswordModel());

                _feed.Status = Feedback.TypeFeedback.Success;
                _feed.Output = validationModel;
            }
            catch (Exception error)
            {
                _feed.Status = Feedback.TypeFeedback.Error;
                _feed.Message.Add(error.Message);
            }

            _jResult.Data = _feed;
            return _jResult;
        }



        private string GetFormatedErrorSummary(object model)
        {
            ErrorSummary errorSummary = _validationRunner.GetErrorSummary(model);
            var errorMessages = new StringBuilder();
            foreach (var error in errorSummary.ErrorMessages)
            {
                errorMessages.AppendLine(string.Format("-{0}", error));
            }
            return errorMessages.ToString();
        }
    }
}
