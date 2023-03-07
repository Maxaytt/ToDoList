using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class UserStatistic
    {
        [Key]
        public int Id { get; set; }

        public string? UserId { get; set; }

        public int TasksCount { get; set; }

        public int OverdueTasksCount { get; set; }

        public int TimelyCompletedTasksCount { get; set; }

        public int DeleteTasksCount { get; set; }

        [Range(0, 100)]
        public float AvgExecutionTime { get; set; }

        [Range(0, 100)]
        public float AvgDelayTime { get; set; }

        public UserStatistic(string userId)
        {
            UserId = userId;
            TasksCount = 0;
            OverdueTasksCount = 0;
            TimelyCompletedTasksCount = 0;
            DeleteTasksCount = 0;
            AvgDelayTime = 0;
            AvgExecutionTime = 0;
        }
        public async void SummingUp(string? userId, AppDbContext context)
        {
            TasksCount = context.TodoTasks
                .Where(t => t.IsCompleted == true && t.UserId == userId)
                .Count();

            if (TasksCount > 0)
            {
                this.SetDelayTime(userId, context);
                this.SetExecutionTime(userId, context);
            }

            OverdueTasksCount = context.TodoTasks
                .Where(t => t.IsCompleted == true && t.UserId == userId && t.CompletedAt > t.Deadline)
                .Count();
            TimelyCompletedTasksCount = TasksCount - OverdueTasksCount;
        }
        private async void SetExecutionTime(string? userId, AppDbContext context)
        {
            var group = context.TodoTasks.Where(t => t.CompletedAt < t.Deadline && t.UserId == userId && t.IsCompleted == true);

            var fullTime = (float)group.Average(t => EF.Functions.DateDiffMinute(t.CreatedAt, t.Deadline));
            var resultTime = (float)group.Average(t => EF.Functions.DateDiffMinute(t.CreatedAt, t.CompletedAt));

            var averageExecutionTime = 100f - (resultTime / fullTime) * 100;

            AvgExecutionTime = averageExecutionTime;
        }
        private async void SetDelayTime(string? userId, AppDbContext context)
        { 
            var group1 = context.TodoTasks.Where(t => t.CompletedAt >= t.Deadline && t.UserId == userId && t.IsCompleted == true);

            var fullTime1 = (float)group1.Average(t => EF.Functions.DateDiffMinute(t.CreatedAt, t.Deadline));
            var resultTime1 = (float)group1.Average(t => EF.Functions.DateDiffMinute(t.CreatedAt, t.CompletedAt));

            var averageDelayTime = (resultTime1 / fullTime1) * 100;

            AvgDelayTime = averageDelayTime;
        }

        public int TotalPoints()
        {
            int totalScore = 100;

            // Distribution of points between different metrics
            int avgExecutionTimeScore = 25;
            int timelyCompletedTasksScore = 25;
            int overdueTasksScore = 25;
            int avgDelayTimeScore = 25;

            // Calculate points for each metric
            int avgExecutionTimePoints = (int)Math.Round((1 - AvgExecutionTime / 100) * avgExecutionTimeScore);
            int timelyCompletedTasksPoints = (int)Math.Round((double)TimelyCompletedTasksCount / TasksCount * timelyCompletedTasksScore);
            int overdueTasksPoints = (int)Math.Round((1 - (double)OverdueTasksCount / TasksCount) * overdueTasksScore);
            int avgDelayTimePoints = (int)Math.Round((1 - AvgDelayTime / 100) * avgDelayTimeScore);

            // Sum up points and return the result
            return avgExecutionTimePoints + timelyCompletedTasksPoints + overdueTasksPoints + avgDelayTimePoints;
        }
    }
}
