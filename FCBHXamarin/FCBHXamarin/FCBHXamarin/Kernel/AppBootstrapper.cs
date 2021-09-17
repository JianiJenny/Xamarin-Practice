using System;
using System.Reflection;
using FCBHXamarin.Pages.MainPage;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FCBHXamarin.Kernel
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public RoutingState Router { get; }
        public AppBootstrapper()
        {
            Router = new RoutingState();
            
            //Register all viewmodels and views
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));
            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());
            
            // Initial starting point for the app
            var mainPageViewModel = new MainPageViewModel();
            Router.Navigate.Execute(mainPageViewModel);
        }

        public Page CreateMainPage()
            => new RoutedViewHost();
    }
}
