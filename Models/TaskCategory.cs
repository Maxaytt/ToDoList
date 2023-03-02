using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class TaskCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 20)]
        public string Description { get; set; }
        public string Color { get; set; }
        public string PictureUrl { get; set; }
    }
}
