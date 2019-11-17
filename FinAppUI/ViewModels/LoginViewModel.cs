using Caliburn.Micro;
using FinAppUi.Library.Api;
using System;
using System.Threading.Tasks;

namespace FinAppUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private string _userName;
        private string _password;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;

            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }


        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }
        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authenticate(UserName, Password);
                
                 await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
