using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class UserStatistic
    {
        [Key]
        public int Id { get; set; }

        public int TasksCount { get; set; }

        public int OverdueTasksCount { get; set; }

        public int TimelyCompletedTasksCount { get; set; }

        public int DeleteTasksCount { get; set; }

        [Range(0, 100)]
        public float AvgExecutionTime { get; set; }

        [Range(0, 100)]
        public float AvgDelayTime { get; set; }
    }
}
