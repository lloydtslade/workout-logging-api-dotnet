using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkoutLog_Onion.Domain.Services;
using NSubstitute;
using WorkoutLog_Onion.Application.Messages;
using WorkoutLog_Onion.Domain.Models;
using WorkoutLog_Onion.Server.Services;
using AutoMapper;
using WorkoutLog_Onion.Server.Mappings;

namespace WorkoutLog_Onion.Test.Service_Tests
{
    [TestClass]
    public class WorkoutServiceTest
    {
        private WorkoutService _target;
        private IWorkoutRepository _workoutRepository;

        [TestInitialize]
        public void SetUp()
        {
             MappingConfiguration.Configure();
             _workoutRepository = Substitute.For<IWorkoutRepository>();
             _target= new WorkoutService(_workoutRepository);
        }

        [TestCleanup]
        public void TearDown()
        {
            _target = null;
        }


        [TestMethod]
        public void GetAllWorkoutsTest()
        {
            var mockworkouts = BuildMockWorkouts();

            _workoutRepository.GetAllWorkouts().Returns(mockworkouts);

            var mockDTOs = Mapper.Map<IList<WorkoutDto>>(mockworkouts);

            var actual = _target.GetAllWorkouts();           
            int actualIndex = 0;
            int mockIndex = 0;
            foreach (var m in actual)
            {
                
                foreach (var n in mockDTOs)
                {
                   
                    Console.WriteLine("actual [" + actualIndex + "]: " + m.WorkoutType + " ");
                    Console.WriteLine("mock [" + mockIndex + "]: " + n.WorkoutType + " ");
                    actualIndex++;
                    mockIndex++;
                }

            }

        }

        private IList<Workout> BuildMockWorkouts()
        {
            
            Workout workout1 = new Workout(
                
                new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "dumbbell bench",
                        NumberOfRepetitions = 60,
                        Resistance = 212

                    },
                    new Exercise
                    {
                        Name = "barbell row",
                        NumberOfRepetitions = 30,
                        Resistance = 245


                    }
                },
                DateTime.Today

                );
            workout1.WorkoutType = WorkoutType.UpperBodyStrength;
            workout1.DurationInMinutes = 60;

            Workout workout2 = new Workout(
                new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "zercher squat",
                        NumberOfRepetitions = 60,
                        Resistance = 255

                    },
                    new Exercise
                    {
                        Name = "romanian deadlift",
                        NumberOfRepetitions = 100,
                        Resistance = 245


                    }
                },
                DateTime.Today.AddDays(2)

                );
            workout2.WorkoutType = WorkoutType.LowerBodyStrength;
            workout2.DurationInMinutes = 60;

            Workout workout3 = new Workout(               
                new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "weighted pullups",
                        NumberOfRepetitions = 60,
                        Resistance = 285

                    },
                    new Exercise
                    {
                        Name = "ring dips",
                        NumberOfRepetitions = 100,
                        Resistance = 233


                    }
                },
                DateTime.Today.AddDays(4)

                );

            workout3.WorkoutType = WorkoutType.UpperBodyStrength;
            workout3.DurationInMinutes = 60;


            Workout workout4 = new Workout(
                
                new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "hex bar deadlifts",
                        NumberOfRepetitions = 60,
                        Resistance = 405

                    },
                    new Exercise
                    {
                        Name = "romanian deadlifts",
                        NumberOfRepetitions = 100,
                        Resistance = 245


                    }
                },
                DateTime.Today.AddDays(4)

                );

            workout4.WorkoutType = WorkoutType.LowerBodyStrength;
            workout4.DurationInMinutes = 60;

            Workout workout5 = new Workout(
                
                new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "weighted pullups",
                        NumberOfRepetitions = 60,
                        Resistance = 285

                    },
                    new Exercise
                    {
                        Name = "ring dips",
                        NumberOfRepetitions = 100,
                        Resistance = 233


                    }
                },
                DateTime.Today.AddDays(4)

                );
            workout5.WorkoutType = WorkoutType.UpperBodyStrength;
            workout5.DurationInMinutes = 60;

            Workout workout6 = new Workout(                
                new List<Exercise>
                {
                    new Exercise
                    {
                        Name = "romanian deadlift",
                        NumberOfRepetitions = 60,
                        Resistance = 255

                    },
                    new Exercise
                    {
                        Name = "hex bar deadlift",
                        NumberOfRepetitions = 100,
                        Resistance = 245


                    }
                },
                DateTime.Today.AddDays(6)

                );

            workout6.WorkoutType = WorkoutType.LowerBodyStrength;
            workout6.DurationInMinutes = 70;

            var mockWorkouts = new List<Workout>
            {
                workout1,
                workout2,
                workout3,
                workout4,
                workout5,
                workout6

                  
            };

            return mockWorkouts;
        }
}
}