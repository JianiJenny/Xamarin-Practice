using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using Splat;

namespace FCBHXamarin.Kernel
{
    public class ViewModelBase : ReactiveObject, IRoutableViewModel, IDisposable
    {
        public IScreen HostScreen { get; set; }

        public string UrlPathSegment { get; }

        protected IObservable<IRoutableViewModel> NavigateTo(ViewModelBase vm)
        {
            return HostScreen.Router.Navigate.Execute(vm);
        }

        private IObservable<IRoutableViewModel> NavigateBack()
        {
            return HostScreen.Router.NavigateBack.Execute();
        }

        public ReactiveCommand<Unit, IRoutableViewModel> NavigateBackCommand;
        
        protected List<IDisposable> Disposables { get; } = new List<IDisposable>();

        protected ViewModelBase(string urlPathSegment, IScreen screen = null)
        {
            UrlPathSegment = urlPathSegment;
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            
            NavigateBackCommand = ReactiveCommand.CreateFromObservable(NavigateBack);
        }

        public virtual void Dispose()
        {
            foreach (var disposable in Disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
