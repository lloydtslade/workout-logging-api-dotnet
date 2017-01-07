using System;
using System.Collections.Generic;
using System.Linq;


namespace WorkoutLog_Onion.Domain.Models
{
    public class Workout
    {
        // currently, no workout objects are created with the constructor, but mapped from a request body. 
        public Workout(IList<Exercise> exercisesPerformed, DateTime workoutDate)
        {           

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