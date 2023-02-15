using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
//using WPF.Reader.Model;
using Book = WPF.Reader.API.Book;
using WPF.Reader.Service;
using System;
using BookLight = WPF.Reader.API.BookLight;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public ICommand ReadCommand { get; set; }
        //public ReadBook()
        //{
        // ReadCommand = new RelayCommand(book => { Ioc.Default.GetRequiredService<INavigationService>().Navigate<ReadBook>(book); });
        // }
        public Book CurrentBook { get; init; }
        public ReadBook(Book book) 
        {
            CurrentBook = book;
        }

      
        // A vous de jouer maintenant

    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base(new Book())
        {
        }
    }
}
