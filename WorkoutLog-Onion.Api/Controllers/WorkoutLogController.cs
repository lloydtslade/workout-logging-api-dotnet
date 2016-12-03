using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WorkoutLog_Onion.Application.Messages;
using WorkoutLog_Onion.Application.Services;
using AutoMapper;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Api.Controllers
{
    [System.Web.Http.RoutePrefix("api/Workouts")]
    public class WorkoutLogController : ApiController
    {
        private readonly IWorkoutService _workoutService;
        // GET: WorkoutLog
        public WorkoutLogController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        /// <summary>
        /// add a new workout
        /// </summary>
        /// <param name="workoutToAdd"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost, System.Web.Http.Route("")]
        public IHttpActionResult Post(NewWorkoutMessage workoutToAdd)
        {
            var newWorkout = Mapper.Map<WorkoutDto>(workoutToAdd);
            try
            {
                var workoutAdded = _workoutService.AddWorkout(newWorkout);
                var location = $"{Request.RequestUri}/{workoutAdded.Id}";

                return Created<object>(location, new {});
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                
            }

        }

        /// <summary>
        /// get all workouts
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("")]
        public IHttpActionResult Get()
        {
            try
            {               
                var workouts = _workoutService.GetAllWorkouts().OrderBy(w => w.WorkoutDate);
                return Ok(workouts.ToList());
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// get by date only
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>

        [System.Web.Http.HttpGet, System.Web.Http.Route("ByDate/{date?}")]
        public IHttpActionResult Get(DateTime date)
        {
            try
            {
                var workoutsByDate = _workoutService.GetWorkoutsByDate(date);
                return Ok(workoutsByDate);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// get by type within date range
        /// </summary>
        /// <param name="type"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [System.Web.Http.Route("workouts/{type}/{date1}/{date2}")]
        public IHttpActionResult Get(WorkoutType type, DateTime begin, DateTime end)
        {
            try
            {
                var workoutsByDate = _workoutService.GetWorkoutsByTypeWithinDateRange(type, begin, end);
                return Ok(workoutsByDate);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        /// <summary>
        /// get workouts by type only
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Web.Http.Route("ByType/{type}")]
        public IHttpActionResult Get(WorkoutType type)
        {
            try
            {
                var workoutsByDate = _workoutService.GetWorkoutsByType(type);
                return Ok(workoutsByDate);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [System.Web.Http.Route("")]
        [System.Web.Http.Route("search/{name?}")]
        public IHttpActionResult Search(string name ="")
        {
            try
            {
                var results = _workoutService.SearchWorkouts(name);

                return Ok(results);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }




    }
}