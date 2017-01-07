using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Domain.Services
{
    public interface IWorkoutRepository
    {
        Workout GetWorkout(Guid id);
        //use case: I suspect I am not hitting legs enough, I can look up how many leg sessions I've had.
        IList<Workout> GetWorkoutsByType(WorkoutType type);
        IList<Workout> GetWorkoutsByTypeWithinDateRange(WorkoutType type, DateTime begin, DateTime end);
        IList<Workout> GetWorkoutsByDate(DateTime date);
        IList<Workout> GetAllWorkouts();
        bool SaveWorkout(Workout workout);
        IList<Workout> FindWorkoutsContainingName(string name);

    }
}
