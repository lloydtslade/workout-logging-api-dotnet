using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Application.Messages
{
    public class NewWorkoutMessage
    {
        public WorkoutType WorkoutType { get; set; }

        public IList<Exercise> ExercisesPerformed { get; set; }

        public DateTime WorkoutDate { get; set; }

        public Guid Id { get; set; }

        public int DurationInMinutes { get; set; }

        public string Comments { get; set; }

    }
}