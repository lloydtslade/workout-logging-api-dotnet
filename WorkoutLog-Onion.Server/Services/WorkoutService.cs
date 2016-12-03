using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutLog_Onion.Application.Messages;
using WorkoutLog_Onion.Application.Services;
using WorkoutLog_Onion.Domain.Models;
using WorkoutLog_Onion.Domain.Services;

namespace WorkoutLog_Onion.Server.Services
{
    
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository workoutRepository;
        

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            this.workoutRepository = workoutRepository;           
        }
        public IList<WorkoutDto> GetAllWorkouts()
        {
            var workouts = this.workoutRepository.GetAllWorkouts();

            return Mapper.Map<IList<WorkoutDto>>(workouts);
            
        }

        public WorkoutDto GetWorkout(Guid id)
        {
            var workout = this.workoutRepository.GetWorkout(id);

            return Mapper.Map<WorkoutDto>(workout);
        }

        public IList<WorkoutDto> GetWorkoutsByDate(DateTime date)
        {
            var workouts = this.workoutRepository.GetWorkoutsByDate(date);

            return Mapper.Map<IList<WorkoutDto>>(workouts);
        }

        public IList<WorkoutDto> GetWorkoutsByType(WorkoutType type)
        {
            var workouts = this.workoutRepository.GetWorkoutsByType(type);

            return Mapper.Map<IList<WorkoutDto>>(workouts);
        }
        public IList<WorkoutDto> GetWorkoutsByTypeWithinDateRange(WorkoutType type, DateTime begin, DateTime end) {

            var workouts = this.workoutRepository.GetWorkoutsByTypeWithinDateRange(type, begin, end);

            return Mapper.Map<IList<WorkoutDto>>(workouts);

        }
        public WorkoutDto AddWorkout(WorkoutDto workout)
        {
            Workout w = Mapper.Map<Workout>(workout);
            var savedWorkout= this.workoutRepository.SaveWorkout(w);

            return Mapper.Map<WorkoutDto>(savedWorkout);
        }

        public IList<WorkoutDto> SearchWorkouts(string name)
        {
            var results = workoutRepository.FindWorkoutsContainingName(name);

            var mapped = Mapper.Map<IList<WorkoutDto>>(results);

            return mapped ?? new List<WorkoutDto>();

        }
    }
}