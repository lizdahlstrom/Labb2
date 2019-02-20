using System.Windows;
using Caliburn.Micro;
using Uppgift2.ViewModels;

namespace Uppgift2
{
    public class Bootstrapper: BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<BankViewModel>();
        }
    }
}