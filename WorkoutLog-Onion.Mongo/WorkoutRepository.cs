using AutoMapper;
using MongoDB.Driver;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Microsoft.Practices.Unity;
using WorkoutLog_Onion.Domain.Models;
using WorkoutLog_Onion.Domain.Services;

namespace WorkoutLog_Onion.Mongo
{
    public class WorkoutRepository : MongoRepository<MongoWorkout, Guid>, IWorkoutRepository
    {

        public WorkoutRepository(MongoUrl Url) : base(Url)
        {
            MongoMapper.Configure();
        }

        [InjectionConstructor]
        public WorkoutRepository(string connectionString) : base (connectionString)
        {
            MongoMapper.Configure();

        }
        public IList<Workout> GetAllWorkouts()
        {
            return Mapper.Map<IList<Workout>>(this.ToList());
        }

        public Workout GetWorkout(Guid id)
        {
            var mongoWorkout= this.FirstOrDefault(x => x.Id == id);
            return mongoWorkout == null ? null : Mapper.Map<Workout>(mongoWorkout);
        }

        public IList<Workout> GetWorkoutsByDate(DateTime date)
        {
            var workoutsByDate = this.Where(x => x.WorkoutDate == date);

            return Mapper.Map<IList<Workout>>(workoutsByDate);
        }

        public IList<Workout> GetWorkoutsByType(WorkoutType type)
        {
            var workoutsByType = this.Where(x => x.WorkoutType == type);

            return Mapper.Map<IList<Workout>>(workoutsByType);
        }

        public IList<Workout> GetWorkoutsByTypeWithinDateRange(WorkoutType type, DateTime begin, DateTime end)
        {
            var workoutsByTypeAndDateRange = this.Where(x => x.WorkoutType == type 
                                                        && x.WorkoutDate >= begin
                                                        && x.WorkoutDate <= end);

            return Mapper.Map<IList<Workout>>(workoutsByTypeAndDateRange);

        }

        public Workout SaveWorkout(Workout workout)
        {
            var mongoWorkout = Mapper.Map<MongoWorkout>(workout);
           
            var added = Add(mongoWorkout);

            Workout savedWorkout = Mapper.Map<Workout>(added); 
                
            return savedWorkout;
           
        }

        public IList<Workout> FindWorkoutsContainingName(string name)
        {
            var exercises = this.Where(x => x.ExercisesPerformed.Any(n => n.Name.Contains(name)));

            IList<Workout> workoutsFound = Mapper.Map<IList<Workout>>(exercises);

            return workoutsFound;
        }
    }
}