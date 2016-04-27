using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CapacitacionMVC.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Plot { get; set; }

        [Required]
        public string CoverLink { get; set; }

        [Required]
        [Range(30, 300)]
        public int Runtime { get; set; }

        [Required]
        [DisplayName("Genre")]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
