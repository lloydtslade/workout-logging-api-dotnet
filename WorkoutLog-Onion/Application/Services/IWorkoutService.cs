using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog_Onion.Application.Messages;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Application.Services
{
    public interface IWorkoutService
    {
        WorkoutDto GetWorkout(Guid id);
        //use case: I suspect I am not hitting legs enough, I can look up how many leg sessions I've had.
        IList<WorkoutDto> GetWorkoutsByType(WorkoutType type);

        IList<WorkoutDto> GetWorkoutsByTypeWithinDateRange(WorkoutType type, DateTime begin, DateTime end);

        IList<WorkoutDto> GetWorkoutsByDate(DateTime date);

        IList<WorkoutDto> GetAllWorkouts();

        WorkoutDto AddWorkout(WorkoutDto workout);

        IList<WorkoutDto> SearchWorkouts(string name);

    }
}
