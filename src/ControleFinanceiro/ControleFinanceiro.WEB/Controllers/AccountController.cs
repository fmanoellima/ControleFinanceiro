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
    [CompressFilter]
    public class AccountController : Controller
    {
        #region Propriedades de requisições

        private string UserName
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["UserName"]))
                    return HttpContext.Request["UserName"].ToString();

                return String.Empty;
            }
        }

        private string Password
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["Password"]))
                    return HttpContext.Request["Password"].ToString();

                return String.Empty;
            }
        }

        private string NewPassword
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["NewPassword"]))
                    return HttpContext.Request["NewPassword"].ToString();

                return String.Empty;
            }
        }

        private string OldPassword
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["OldPassword"]))
                    return HttpContext.Request["OldPassword"].ToString();

                return String.Empty;
            }
        }

        private string ConfirmPassword
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["ConfirmPassword"]))
                    return HttpContext.Request["ConfirmPassword"].ToString();

                return String.Empty;
            }
        }

        private bool RememberMe
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["RememberMe"]))
                    return bool.Parse(HttpContext.Request["RememberMe"].ToString().ToLower());

                return false;
            }
        }

        private string ReturnUrl
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["ReturnUrl"]))
                    return HttpContext.Request["ReturnUrl"].ToString().ToLower();

                return String.Empty;
            }
        }

        private string Email
        {
            get
            {
                if (!String.IsNullOrEmpty(HttpContext.Request["Email"]))
                    return HttpContext.Request["Email"].ToString();

                return String.Empty;
            }
        }
        
        #endregion

        #region Atributos

        private Feedback _feed;
        private JsonResult _jresult { get { return _context.Resolve<JsonResult>();}}
        private IValidatorRunner _validationRunner;
        private IComponentContext _context;

        #endregion

        public AccountController(IComponentContext context)
        {
            _context = context;
            _validationRunner = context.Resolve<IValidatorRunner>();
            _feed = new Feedback();
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

            _jresult.Data = _feed;
            return _jresult;
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

            _jresult.Data = _feed;
            return _jresult;
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
                    bool changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);

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

            _jresult.Data = _feed;
            return _jresult;

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

            _jresult.Data = _feed;
            return _jresult;
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

            _jresult.Data = _feed;
            return _jresult;
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

            _jresult.Data = _feed;
            return _jresult;
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
