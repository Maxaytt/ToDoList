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

        public TaskCategory(string? userId, string name, string color, string pictureUrl)
        {
            UserId = userId;
            Name = name;
            Color = color;
            PictureUrl = pictureUrl;
        }

        public static List<TaskCategory> GetDefaultObjects(string userId)
        {
            var objList = new List<TaskCategory>();
            objList.Add(new TaskCategory( userId, "Work", "0000FF",  "File" ));
            objList.Add(new TaskCategory( userId, "Rest", "FFFF00", "Beach" ));
            objList.Add(new TaskCategory( userId, "Hobby", "FF0000", "Ball" ));

            return objList;
        }
    }

}
