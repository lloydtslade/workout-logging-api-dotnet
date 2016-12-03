using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLog_Onion.Application.Services
{
    public interface IWorkoutTypeService
    {

        IList<string> GetWorkoutTypes();

    }
}
