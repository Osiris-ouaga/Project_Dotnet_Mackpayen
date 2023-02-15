using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.Server.Database
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext)
        {

            if (bookDbContext.Books.Any())
                return;

            Genre SF, Classic, Romance, Thriller, RC, RH, RE, RM, RA, RI, Novella, NF;
            String placeholder = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
           
            bookDbContext.Genre.AddRange(
                SF = new Genre() { Name = "Science Fiction" },
                Classic = new Genre() { Name = "Classic" },
                Romance = new Genre() { Name = "Romance" },
                Thriller = new Genre() { Name = "Thriller" },
                RC = new Genre() { Name = "Roman courtoi" },
                RH = new Genre() { Name = "Roman historique" },
                RE = new Genre() { Name = "Roman épistolaire" },
                RM = new Genre() { Name = "Roman-mémoires" },
                RA = new Genre() { Name = "Roman d'amour" },
                RI = new Genre() { Name = "Roman industriel" },
                Novella = new Genre() { Name = "Novella" },
                NF = new Genre() { Name = "Nouvelle fiction" }
            );

            // Une fois les moèles complété Vous pouvez faire directement
            // new Book() { Author = "xxx", Name = "yyy", Price = n.nnf, Content = "ccc", Genres = new() { Romance, Thriller } }
            bookDbContext.Books.AddRange(
                new Book() { Author = "Albert Camus", Name = "L'etranger", Price = 80, Content = placeholder, Genres = new List<Genre>() { SF, Thriller } }, 
                new Book() { Author = "Marc Levy", Name = "Mes amis, mes amours", Price = 90, Content = placeholder, Genres = new List<Genre>() { Romance, SF } },
                new Book() { Author = "Eric Kastner", Name = "Le 35 mai", Price = 100, Content = placeholder, Genres = new List<Genre>() { SF, Classic } },
                new Book() { Author = "Brian Mealer", Name = "Le garcon qui dompta le vent", Price = 140, Content = placeholder, Genres = new List<Genre>() { Romance, Thriller } },
                new Book() { Author = "Albert Camus", Name = "L'etranger", Price = 80, Content = placeholder, Genres = new List<Genre>() { RC, RH } },
                new Book() { Author = "Marc Levy", Name = "Mes amis, mes amours", Price = 90, Content = placeholder, Genres = new List<Genre>() { RE, RM } },
                new Book() { Author = "Eric Kastner", Name = "Le 35 mai", Price = 100, Content = placeholder, Genres = new List<Genre>() { RI, Classic, RA } },
                new Book() { Author = "Brian Mealer", Name = "Le garcon qui dompta le vent", Price = 140, Content = placeholder, Genres = new List<Genre>() { Novella, NF } },
                new Book() { Author = "Albert Camus", Name = "L'etranger", Price = 80, Content = placeholder, Genres = new List<Genre>() { SF, Thriller } },
                new Book() { Author = "Marc Levy", Name = "Mes amis, mes amours", Price = 90, Content = placeholder, Genres = new List<Genre>() { Romance, SF } },
                new Book() { Author = "Eric Kastner", Name = "Le 35 mai", Price = 100, Content = placeholder, Genres = new List<Genre>() { SF, Classic } },
                new Book() { Author = "Brian Mealer", Name = "Le garcon qui dompta le vent", Price = 140, Content = placeholder, Genres = new List<Genre>() { Romance, Thriller } },
                new Book() { Author = "Albert Camus", Name = "L'etranger", Price = 80, Content = placeholder, Genres = new List<Genre>() { RC, RH } },
                new Book() { Author = "Marc Levy", Name = "Mes amis, mes amours", Price = 90, Content = placeholder, Genres = new List<Genre>() { RE, RM } },
                new Book() { Author = "Eric Kastner", Name = "Le 35 mai", Price = 100, Content = placeholder, Genres = new List<Genre>() { RI, Classic, RA } }
           );
            // Vous pouvez initialiser la BDD ici
            bookDbContext.SaveChanges();
        }
    }
}