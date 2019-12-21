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
        private ILoggedInUserModel _user;
        private IAPIHelper _apiHelper;

        public ShellViewModel(IEventAggregator events,
           ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            _events = events;
            _user = user;
            _apiHelper = apiHelper;
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
        public async Task AddArticleAsync()
        {
            NotifyOfPropertyChange(() => IsLoggedIn);
            await ActivateItemAsync(IoC.Get<ArticleViewModel>(), new CancellationToken());
        }
        public async Task ShowWalletsAsync()
        {
            NotifyOfPropertyChange(() => IsLoggedIn);
            await ActivateItemAsync(IoC.Get<WalletViewModel>(), new CancellationToken());
        }
        public async Task AddWalletAsync()
        {
            NotifyOfPropertyChange(() => IsLoggedIn);
            await ActivateItemAsync(IoC.Get<AddWalletViewModel>(), new CancellationToken());
        }
        public async Task LogOutAsync()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            NotifyOfPropertyChange(() => IsLoggedIn);
            await ActivateItemAsync(IoC.Get<WalletViewModel>(), cancellationToken);
        }
    }
}
