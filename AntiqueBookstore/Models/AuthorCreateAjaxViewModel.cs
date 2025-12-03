using System.ComponentModel.DataAnnotations;

namespace AntiqueBookstore.Models
{
    public class AuthorCreateAjaxViewModel
    {
        // Properties for AuthorCreateAjaxViewModel class corresponding to Author entity

        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // TODO: any annotations ??
        public int? BirthYear { get; set; }

        public int? DeathYear { get; set; }

        public string? Bio { get; set; }

        // TODO: BookAuthors many-to-many mapping
    }
}
