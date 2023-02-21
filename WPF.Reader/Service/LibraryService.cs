using System;
using System.Collections.ObjectModel;
using WPF.Reader.API;
using WPF.Reader.Model;
using Book = WPF.Reader.API.Book;
using BookLight = WPF.Reader.API.BookLight;
using System.Collections.Generic;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        public LibraryService()
        {
            getBooks();
            getGenres();
        }
        String URL = "https://localhost:5001/swagger/v1/swagger.json";

        public ObservableCollection<BookLight> Books { get; set; } = new ObservableCollection<BookLight>() {
            //new BookLight(),
            //new BookLight()
        };
        public ObservableCollection<Genre> Genres { get; set; } = new ObservableCollection<Genre>() { };


        public async void getBooks()
        {
           var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
           var books = await client.ApiBookGetBooksAsync(null, null, null);
              Books.Clear();
            foreach(BookLight book in books)
            {
                Books.Add(book);
            }
        }

        public async void getBooksOfGenre(int? id)
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var books = await client.ApiBookGetBooksAsync(id, null, null);
            //Books.Clear();
            foreach (BookLight book in books)
            {
                Books.Add(book);
            }
        }

        public async void getGenres()
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var genres = await client.ApiBookGetGenresAsync();
            //Genres.Clear();
            foreach (Genre genre in genres)
            {
                Genres.Add(genre);
            }
        }

        /*        public ObservableCollection<Book> Book { get; set; } = new ObservableCollection<Book>() {
                    new Book(),
                    new Book(),
                    new Book()

                };
        */
        public  Book getBook(int id)
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var book =  client.ApiBookGetBookByIdAsync(id);
            return book.Result;

        }
    }
}
