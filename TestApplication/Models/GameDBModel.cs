using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class GameDBModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Name should contains max 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Name of developer is required")]
        public string? Developer { get; set; }

        [Required(ErrorMessage = "Name of developer is required")]
        public string? Genres { get; set; }
    }
}
