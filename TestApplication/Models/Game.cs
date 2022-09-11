using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Name should contains max 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Name of developer is required")]
        public string? Developer { get; set; }

        [Required(ErrorMessage = "Minimum one genre is required")]
        public string? Genres { get; set; }
    }
}
