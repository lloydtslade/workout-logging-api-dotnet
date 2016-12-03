using MongoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutLog_Onion.Domain.Models;

namespace WorkoutLog_Onion.Mongo
{
    [CollectionName("Workouts")]
    public class MongoWorkout: Workout, IEntity<Guid>
    {
    }
}