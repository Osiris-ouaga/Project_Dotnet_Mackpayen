using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Database;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASP.Server.Controllers
{
    public class CreateGenreModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }
        public int Id { get; }

        public IEnumerable<Genre> Genre { get; init; }
    }
    public class EditGenreModel
    {
        [Required]
        [Display(Name = "Nom")]
        public String Name { get; set; }
        public int Id { get; set; }

        public Genre genre { get; init; }
    }
    public class GenreController : Controller
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }

        // A vous de faire comme BookController.List mais pour les genres !
        public ActionResult<IEnumerable<Genre>> List()
        {
            // récupérer les livres dans la base de donées pour qu'elle puisse être affiché
            List<Genre> ListGenres = libraryDbContext.Genre.ToList();
            return View(ListGenres);
        }

        public ActionResult<CreateGenreModel> Create(CreateGenreModel genre)
        {
            if (ModelState.IsValid)
            {
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Add(new Genre()
                {
                    Name = genre.Name
                }
                );
                libraryDbContext.SaveChanges();

                return RedirectToAction("List");
            }
            return View(new CreateGenreModel());
        }

        public ActionResult<CreateGenreModel> Edit(int id)
        {
            Genre genre = libraryDbContext.Genre.First(g => g.Id == id);
            return View(new EditGenreModel() { Id = genre.Id, Name = genre.Name });
        }

        public ActionResult<CreateGenreModel> Update(EditGenreModel genre)
        {
            if (ModelState.IsValid)
            {
                Genre existedGenre = libraryDbContext.Genre.First(g => g.Id == genre.Id);
                existedGenre.Name = genre.Name;
                // Completer la création du livre avec toute les information nécéssaire que vous aurez ajoutez, et metter la liste des gener récupéré de la base aussi
                libraryDbContext.Update<Genre>(existedGenre);
                libraryDbContext.SaveChanges();

                return RedirectToAction("List");
            }
            return View(new CreateGenreModel());
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Genre genre = libraryDbContext.Genre.First(g => g.Id == id);
                if (genre != null)
                {

                    libraryDbContext.Genre.Remove(genre);
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