using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WorkoutLog_Onion.Api.Controllers
{
    [RoutePrefix("api/workoutTypes")]
    public class WorkoutTypesController : ApiController
    {
        // used to hydrate the dropdown on the front end. 
        [HttpGet]
        public IHttpActionResult Get()
        {
            

            throw new NotImplementedException();
        }
    }
}
