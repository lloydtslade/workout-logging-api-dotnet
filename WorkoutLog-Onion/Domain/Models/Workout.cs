using System;
using System.Collections.Generic;
using System.Linq;


namespace WorkoutLog_Onion.Domain.Models
{
    public class Workout
    {
        public Workout(IList<Exercise> exercisesPerformed, DateTime workoutDate)
        {

            Id = new Guid();

            ExercisesPerformed = exercisesPerformed;

            WorkoutDate = workoutDate;

        }

        public Workout()
        {
        }

        public WorkoutType WorkoutType { get; set; }

        public IList<Exercise> ExercisesPerformed { get; set; }

        public DateTime WorkoutDate { get; set; }

        public Guid Id { get; set; }

        public int DurationInMinutes { get; set; } 
        
        public string Comments { get; set; } 
          
        public int TotalVolume {
            get {

                return ExercisesPerformed.Sum(x => x.Volume);
            }
        }
    }
}