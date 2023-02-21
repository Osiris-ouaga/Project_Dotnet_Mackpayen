using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
   
    class Navigator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Frame Frame => Ioc.Default.GetRequiredService<INavigationService>().Frame;

        public ICommand GoBack { get; init; } = new RelayCommand(x => { Ioc.Default.GetRequiredService<INavigationService>().Frame.GoBack(); });
               
        public ICommand GoToHome { get; init; } = new RelayCommand(x => {
            var service = Ioc.Default.GetRequiredService<INavigationService>();
            if (service.Frame.CanGoBack)
            {
                service.Frame.RemoveBackEntry();
                var entry = service.Frame.RemoveBackEntry();
                while (entry != null)
                {
                    entry = service.Frame.RemoveBackEntry();
                }
            }
            service.Navigate<ListBook>();
        });
    }
}
