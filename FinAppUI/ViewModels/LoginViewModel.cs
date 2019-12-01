using Caliburn.Micro;
using FinAppUi.Library.Api;
using FinAppUI.EventModels;
using System;
using System.Threading.Tasks;

namespace FinAppUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private IEventAggregator _events;
        private string _userName = "aliibbeekk2@gmail.com";
        private string _password = "Alibek+1";

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _events = events;
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
                ErrorMessage = string.Empty;
                var result = await _apiHelper.Authenticate(UserName, Password);
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
                await _events.PublishOnUIThreadAsync(new LogOnEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
