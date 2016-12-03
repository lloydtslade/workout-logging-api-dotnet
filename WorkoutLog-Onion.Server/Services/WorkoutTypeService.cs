using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutLog_Onion.Application.Messages;
using WorkoutLog_Onion.Application.Services;

namespace WorkoutLog_Onion.Server.Services
{
    public class WorkoutTypeService : IWorkoutTypeService
    {

        public WorkoutTypeService(WorkoutTypeDto type)
        {

        }

        public IList<string> GetWorkoutTypes()
        {



            throw new NotImplementedException();
        }
    }
}