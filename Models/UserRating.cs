using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; }

        public int TotalPoints { get; set; }
    }
}
