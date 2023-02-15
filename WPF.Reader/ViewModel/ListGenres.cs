using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.API;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListGenres : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;

     
    }
}
