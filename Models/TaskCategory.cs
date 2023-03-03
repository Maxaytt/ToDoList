using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class TaskCategory
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        [Required]
        [Range(1, 20)]
        public string Name { get; set; }
        public string Color { get; set; }
        public string PictureUrl { get; set; }

        
    }

}
