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

        public static List<TaskCategory> GetDefaultObjects(string userId)
        {
            var objList = new List<TaskCategory>();
            objList.Add(new TaskCategory { Id = 1, UserId = userId, Name = "Work", Color = "0000FF", PictureUrl = "File" });
            objList.Add(new TaskCategory { Id = 2, UserId = userId, Name = "Rest", Color = "FFFF00", PictureUrl = "Beach" });
            objList.Add(new TaskCategory { Id = 3, UserId = userId, Name = "Hobby", Color = "FF0000", PictureUrl = "Ball" });

            return objList;
        }
    }

}
