using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.API;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        public ICommand GoToGenres { get; set; }
        public ICommand GenreSelectedCommand { get; set; }
        public ICommand ClearBooks { get; set; }
        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<BookLight> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;

        public ListBook()
        {
            ItemSelectedCommand = new RelayCommand(book => {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book);
                /* the livre devrais etre dans la variable book */ });

            GoToGenres = new RelayCommand(book =>
            {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListGenres>();
            });

            String URL = "https://127.0.0.1:5001";
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });

            GenreSelectedCommand = new RelayCommand(id => {
                 Ioc.Default.GetService<LibraryService>().getBooksOfGenre((int)id);
            });

            ClearBooks = new RelayCommand(book =>
            {
                Ioc.Default.GetService<LibraryService>().getBooksOfGenre(null);
                /*  List<BookLight> listbooks =  client.ApiBookGetBooksAsync(null, null, null);
                  Books.Clear();
                  foreach (BookLight booki in listbooks)
                  {
                      Books.Add(booki);
                  }*/
            });

        }



    }
}
