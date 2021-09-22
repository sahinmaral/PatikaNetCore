using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreAppWebAPI.Entities
{
    public class Book
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }
        public int WriterId { get; set; }

        public Genre Genre { get; set; }
        public Writer Writer { get; set; }
    }
}