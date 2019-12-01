using Caliburn.Micro;
using FinAppUi.Library.Api;
using FinAppUi.Library.Models;
using FinAppUI.EventModels;
using System.Threading;
using System.Threading.Tasks;

namespace FinAppUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private WalletViewModel _walletVM;
        private ILoggedInUserModel _user;
        private IAPIHelper _apiHelper;
        public ShellViewModel(LoginViewModel loginViewModel, IEventAggregator events, WalletViewModel walletVM,
           ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            _events = events;
            _user = user;
            _apiHelper = apiHelper;
            _walletVM = walletVM;
            events.SubscribeOnPublishedThread(this);
            ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }
        public void ExitApplication()
        {
            TryCloseAsync();
        }
        public bool IsLoggedIn
        {
            get
            {
                bool output = true;
                if (string.IsNullOrWhiteSpace(_user.Token))
                {
                    output = false;
                }
                return output;
            }
        }
        public async Task LogOutAsync()
        {
            _user.ResetUserModel();
            _walletVM.Refresh();
            _apiHelper.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_walletVM, cancellationToken);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
