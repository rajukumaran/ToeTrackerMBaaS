using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using ToeTrackerTrainerMobService.DataObjects;
using ToeTrackerTrainerMobService.Models;

namespace ToeTrackerTrainerMobService.Controllers
{
    public class EnterExerciseActivityController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/EnterExerciseActivity
        public HttpResponseMessage Post(ExcerciseInput execInput)
        {
            ToeTrackerTrainerMobContext context = new ToeTrackerTrainerMobContext();
            execInput.Id = Guid.NewGuid().ToString(); context.ExcerciseInputs.Add(execInput);
            context.SaveChanges();
            return this.Request.CreateResponse(HttpStatusCode.Created, "Success");
        }
    }

}

