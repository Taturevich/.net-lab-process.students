using System.Windows;
using Caliburn.Micro;
using WPFDemo.GridExample;
using WPFDemo.Triggers;

namespace WPFDemo
{
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<PanelExampleViewModel>();
            var wm = new WindowManager();
        }
    }
}