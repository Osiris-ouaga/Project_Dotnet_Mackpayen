using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ASP.Server.Controllers
{
    public class CreateBookModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }

        // Ajouter ici tous les champ que l'utilisateur devra remplir pour ajouter un livre
        [Required]
        [Display(Name = "Auteur")]
        public String Author { get; set; }
        [Required]
        [Display(Name = "Contenu")]
        public String Content { get; set; }
        [Required]
        [Display(Name = "Prix")]
        public Double Price { get; set; }
        public DateTime Created { get; set; }

        // public Genre Genres { get; set; }

        // Liste des genres séléctionné par l'utilisateur
        [Required]
        [Display(Name = "Catégories")]
        public List<int> Genres { get; set; }
        //public ICollection<Genre> Genres { get; set; }

        // Liste des genres a afficher à l'utilisateur
        public IEnumerable<Genre> AllGenres { get; init;  }
    }

    public class EditBookModel 
    {
      /*   
       public int Id { get; set; }

       
       [Display(Name = "Nom")]
        public String Name { get; set; }
        
        [Display(Name = "Auteur")]
        public String Author { get; set; }
        
        [Display(Name = "Contenu")]
        public String Content { get; set; }
       
        [Display(Name = "Prix")]
        public Double Price { get; set; }
*/
        // Liste des genres séléctionné par l'utilisateur
       
        [Display(Name = "Catégories")]
        public List<int> Genres { get; set; }
        //public ICollection<Genre> Genres { get; set; }
        public IEnumerable<Genre> AllGenres { get; init; }

        public Book Book { get; set; }
    }

    public class BookController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        public ActionResult<IEnumerable<Book>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Book> ListBooks = libraryDbContext.Books.ToList();
            return View(ListBooks);
        }

        public ActionResult<CreateBookModel> Create(CreateBookModel book)
        {
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            if (ModelState.IsValid)
            {
                // Il faut intéroger la base pour récupérer l'ensemble des objets genre qui correspond aux id dans CreateBookModel.Genres
                var genresOfTheBook = new List<Genre>(); ;
                foreach (var id in book.Genres)
                {
                    Genre existedGenre = libraryDbContext.Genre.Find(id);
                    if(existedGenre != null)
                    {
                        genresOfTheBook.Add(existedGenre);
                    }
                   
                }
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Book() {
                    Name = book.Name, 
                    Author = book.Author, 
                    Content = book.Content,
                    Price = book.Price,
                    Genres = genresOfTheBook
                });
                libraryDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            List<Genre> genres = libraryDbContext.Genre.ToList();

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new CreateBookModel() { AllGenres = genres } );
        }
        public ActionResult<Book> Details(int id)
        {
            Book book = libraryDbContext.Books.Include(book => book.Genres).First(x => x.Id == id);
            if(book != null)
            {
                return View(book );
            }

            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return RedirectToAction("List");
        }
        public ActionResult<EditBookModel> Edit(int id)
        {
            Book book = libraryDbContext.Books.Include(book => book.Genres).First(x => x.Id == id);
            List<Genre> genres = libraryDbContext.Genre.ToList();
            // Il faut interoger la base pour récupérer tous les genres, pour que l'utilisateur puisse les slécétionné
            return View(new EditBookModel() { Book=book,  AllGenres = genres });
        }

        public ActionResult<EditBookModel> Update(EditBookModel bookParam)
        {
            
            // Le IsValid est True uniquement si tous les champs de CreateBookModel marqués Required sont remplis
            //if (ModelState.IsValid)
            {
                Book existingBook = libraryDbContext.Books.Include(book => book.Genres).First(x => x.Id == bookParam.Book.Id);
              
                var genresOfTheBook = new List<Genre>(); 
                foreach (var id in bookParam.Genres)
                {
                    Genre existedGenre = libraryDbContext.Genre.Find(id);
                    if (existedGenre != null)
                    {
                        genresOfTheBook.Add(existedGenre);
                    }
                }
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi

                existingBook.Name = bookParam.Book.Name;
                existingBook.Author = bookParam.Book.Author;
                existingBook.Content = bookParam.Book.Content;
                existingBook.Price = bookParam.Book.Price;
                existingBook.Genres = genresOfTheBook;

                libraryDbContext.Update<Book>(existingBook);
                libraryDbContext.SaveChanges();
                return RedirectToAction("List");
            }
           // return RedirectToAction("List");

        }

        public ActionResult Delete(int id)
        {
            try
            {
                Book book = libraryDbContext.Books.First(g => g.Id == id);
                if (book != null)
                {

                    libraryDbContext.Books.Remove(book);
                    libraryDbContext.SaveChanges();
                    return RedirectToAction("List");
                }
                else
                {
                    ///Todo
                    return RedirectToAction("List");
                }
            }
            catch
            {
                ///Todo
                return RedirectToAction("List");
            }
        }
    }
}