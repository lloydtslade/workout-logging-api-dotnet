using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WorkoutLog_Onion.Application.Messages;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Api.App_Start
{
    public class MapperConfig
    {

        public static void Configure()
        {

            Mapper.CreateMap<NewWorkoutMessage, WorkoutDto>();
            Mapper.CreateMap<Workout, WorkoutDto>();
        }
    }
}