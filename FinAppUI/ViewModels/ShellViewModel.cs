using Caliburn.Micro;
using System.Threading;

namespace FinAppUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }
        public void ExitApplication()
        {
            TryCloseAsync();
        }
    }
}
