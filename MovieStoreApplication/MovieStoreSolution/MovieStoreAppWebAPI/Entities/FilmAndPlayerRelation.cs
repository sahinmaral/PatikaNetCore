using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreAppWebAPI.Entities
{
    public class FilmAndPlayerRelation:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Film Film { get; set; }
        public int FilmId { get; set; }

        public Player Player { get; set; }
        public int PlayerId { get; set; }

        
    }
}
