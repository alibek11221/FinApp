using Caliburn.Micro;

namespace FinAppUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItem(IoC.Get<LoginViewModel>());
        }
    }
}
