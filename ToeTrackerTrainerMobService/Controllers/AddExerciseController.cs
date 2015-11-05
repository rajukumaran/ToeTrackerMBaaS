using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using ToeTrackerTrainerMobService.Models;
using ToeTrackerTrainerMobService.DataObjects;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace ToeTrackerTrainerMobService.Controllers
{
    public class AddExerciseController : ApiController
    {
        public ApiServices Services { get; set; }

        public HttpResponseMessage Post(ExerciseDescRequest registrationRequest)
        {

            ToeTrackerTrainerMobContext context = new ToeTrackerTrainerMobContext();
            ExerciseDesc account = context.ExerciseDesc.Where(a => a.ExerciseName == registrationRequest.ExerciseName).SingleOrDefault();
            if (account != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "This exercise already exists");
            }
            else
            {
                byte[] salt = CustomLoginProviderUtils.generateSalt();
                ExerciseDesc newAccount = new ExerciseDesc
                {
                    Id = Guid.NewGuid().ToString(),
                    ExerciseName = registrationRequest.ExerciseName,
                    ExerciseDescID = registrationRequest.ExerciseId,
                    MuscleDescID = registrationRequest.MuscleId,
                    SecondaryMuslceId = registrationRequest.SecondaryMuslceId,
                    Unit1 = registrationRequest.Unit1,
                    Unit2 = registrationRequest.Unit2,
                    Unit3 = registrationRequest.Unit3

                };
                context.ExerciseDesc.Add(newAccount);
                context.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.Created);
            }
        }

    }
}
