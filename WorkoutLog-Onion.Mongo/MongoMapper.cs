using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Mongo
{
    public class MongoMapper
    {

        public static void Configure()
        {
            Mapper.CreateMap<MongoWorkout, Workout>();
            Mapper.CreateMap<Workout, MongoWorkout>();
        }
    }
}