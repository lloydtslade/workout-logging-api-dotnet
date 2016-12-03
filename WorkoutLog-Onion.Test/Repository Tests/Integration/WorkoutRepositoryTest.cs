//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NSubstitute;
using MongoDB;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using WorkoutLog_Onion.Domain.Models;
using WorkoutLog_Onion.Domain.Services;
using WorkoutLog_Onion.Mongo;
using NSubstitute;
namespace WorkoutLog_Onion.Test.Repository_Tests
{
    [TestClass]
    public class WorkoutRepositoryTest
    {
        private WorkoutRepository target;
        private MongoUrl mongoUrl;
        private string mongoConnectionString = "mongodb://localhost/Workouts";
        private IList<Workout> testList;
        public WorkoutRepositoryTest()
        {
           // target = Substitute.For<IWorkoutRepository>(mongoUrl.ToString());
        }

        [TestInitialize]
        public void SetUp()
        {
            MongoMapper.Configure();

            mongoUrl = new MongoUrl(mongoConnectionString);
            // target = new WorkoutRepository(mongoUrl.ToString());
            target = Substitute.For<WorkoutRepository>(mongoConnectionString);
            testList = BuildTestWorkoutList();

        }

        [TestCleanup]
        public void TearDown()
        {
            target = null;
        }

        [TestMethod]
        public void CanConstructWithConnnectionString()
        {
            // ACT
            var alternatelyConstructedSubject = new WorkoutRepository(mongoConnectionString);

            // ASSERT
            Assert.IsNotNull(alternatelyConstructedSubject);
        }

        [TestMethod]
        public void SaveWorkoutTest()
        {
            // ARRANGE
            Guid guid = Guid.NewGuid();
            List <Exercise> mockExercises= new List<Exercise>
            {
                new Exercise
                {
                    Name= "Squats",
                    NumberOfRepetitions = 100,
                    Resistance= 255,

                },

                  new Exercise
                {
                    Name= "Pullups",
                    NumberOfRepetitions = 60,
                    Resistance= 280,

                }

            };

            DateTime workoutDate = DateTime.Today;

            Workout workout = new Workout(mockExercises, workoutDate);
            workout.WorkoutType = WorkoutType.Other;
            workout.DurationInMinutes = 80;
            workout.Comments = "this was upper and lower";
            // var vol= workout.TotalVolume;
            
            var mongoworkout = Mapper.Map<MongoWorkout>(workout);
            // ACT
            var workoutAdded = target.SaveWorkout(mongoworkout);

            // ASSERT
            Assert.AreNotEqual(workoutAdded.Id, Guid.Empty);//.That(workoutAdded.Id, Is.Not.EqualTo(Guid.Empty));
            // Assert.AreNotEqual(vol, 0);
            Assert.IsNotNull(workoutAdded.ExercisesPerformed);
        }

        [TestMethod]
        public void GetAllWorkoutsTest()
        {
            // ACT
            var persistedWorkouts= target.GetAllWorkouts();

            // ASSERT
            Assert.IsTrue(persistedWorkouts.Count > 0);//NOTE: every time CanAddWorkout() runs this number goes up
        }


        [TestMethod]
        public void TestGetWorkoutsByType()
        {
            var workouts = target.GetWorkoutsByType(WorkoutType.Other);

            var mongoworkouts = Mapper.Map<IList<MongoWorkout>>(workouts);

            Assert.IsNotNull(mongoworkouts);
        }

        [TestMethod]
        public void TestGetWorkoutByGuid()
        {
            var workoutsByGUid = target.GetWorkout(Guid.Parse("{752ff9bb-af47-4282-995e-5ee9a1572f48}"));

            Assert.IsNotNull(workoutsByGUid);
        }

        [TestMethod]
        public void GetWorkoutsByTypeWithinDateRangeTest()
        {
            DateTime d1 = DateTime.Today.Subtract(new TimeSpan(3));
            DateTime d2= DateTime.Today.AddDays(3);

            var workouts= target.GetWorkoutsByTypeWithinDateRange(WorkoutType.Other, d1, d2);

            Assert.IsNotNull(workouts);
        }

        [TestMethod]
        public void GetWorkoutsByDateTest()
        {
            var workoutsByDate = target.GetWorkoutsByDate(DateTime.Today);

            Assert.IsNotNull(workoutsByDate);

        }

        [TestMethod]
        public void TestFindWorkoutsContainingName()
        {
            string failCase = "pizza";

            string passCase = "Squats";


            var a = target.FindWorkoutsContainingName(failCase);
            Assert.IsNotNull(a);

        }

        private IList<Workout> BuildTestWorkoutList()
        {
            IList<Workout> testWorkouts = new List<Workout>
            {
                new Workout
                {
                    Comments = "made gainz",
                    DurationInMinutes = 90,
                    ExercisesPerformed = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "pullups"
                        }
                    }
                },

                new Workout
                {
                    Comments = "made mo gainz",
                    DurationInMinutes = 80,
                    ExercisesPerformed = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "squats"
                        }
                    }
                },

                new Workout
                {
                    Comments = "made all kindz of gainz",
                    DurationInMinutes = 90,
                    ExercisesPerformed = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "dips"
                        }
                    }
                },

                new Workout
                {
                    Comments = "made all kindz of gainz",
                    DurationInMinutes = 90,
                    ExercisesPerformed = new List<Exercise>
                    {
                        new Exercise
                        {
                            Name = "romanian deadlift",
                            NumberOfRepetitions = 100
                        }
                    }
                }
            };

            return testWorkouts;
        }
    }
}