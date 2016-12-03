using AutoMapper;
using WorkoutLog_Onion.Application.Messages;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Server.Mappings
{
    public class MappingConfiguration
    {

        public static void Configure() {

            Mapper.CreateMap<Workout, WorkoutDto>();
            Mapper.CreateMap<NewWorkoutMessage, WorkoutDto>();
        }
    }
}