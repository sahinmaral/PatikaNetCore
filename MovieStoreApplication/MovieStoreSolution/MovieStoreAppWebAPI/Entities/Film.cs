using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace MovieStoreAppWebAPI.Entities
{
    public class Film : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishedDate { get; set; }
        public decimal Price { get; set; }
        public string About { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        public Director Director { get; set; }
        public int DirectorId { get; set; }
        

        [JsonIgnore]
        public ICollection<FilmAndPlayerRelation> FilmAndPlayerRelations { get; set; }
    }
}
