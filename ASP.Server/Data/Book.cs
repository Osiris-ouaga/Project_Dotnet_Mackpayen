using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ASP.Server.Model
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        // Mettez ici les propriété de votre livre: Nom, Autheur, Prix, Contenu et Genres associés
        // N'oublier pas qu'un livre peut avoir plusieur genres
        [Required]
        public string Author { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Content { get; set; }
        [Required] 
        public double Price { get; set; }

        [Required]
        public ICollection<Genre> Genres { get; set; }
    }

    public class BookLight
    {
        public Book Book { init; private get; }
        public int Id { get { return Book.Id; } }

        public string Author { get { return Book.Author;  } }
        public string Name { get { return Book.Name;  } }
        public double Price { get { return Book.Price; } }

        public ICollection<Genre> Genres { get { return Book.Genres; } }
     
    }
}
