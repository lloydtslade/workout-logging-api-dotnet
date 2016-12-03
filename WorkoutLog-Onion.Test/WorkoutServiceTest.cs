using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkoutLog_Onion.Application.Services;
using NSubstitute;
using WorkoutLog_Onion.Domain.Services;

namespace WorkoutLog_Onion.Test
{
    [TestClass]
    public class WorkoutServiceTest
    {
        private  readonly IWorkoutService target;
        [TestInitialize]
        public void Initialize()
        {
            var mockRepository = Substitute.For<IWorkoutRepository>();
        }
        
        
    }
}