using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using ToeTrackerTrainerMobService.Models;
using ToeTrackerTrainerMobService.DataObjects;

namespace ToeTrackerTrainerMobService.Controllers
{
    public class GetMusclesController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/GetMuscles
        public string Get()
        {
            ToeTrackerTrainerMobContext context = new ToeTrackerTrainerMobContext();
            List<MuscleDesc> muscles = context.MuscleDesc.ToList<MuscleDesc>() ;
            List<BodyAreaDesc> bdArea = context.BodyAreaDesc.ToList<BodyAreaDesc>();
            string strJson = "{";
            foreach (BodyAreaDesc ba in bdArea)
            {
                strJson += "\""+ ba.BodyAreaName + "\":";
                string [] ms = muscles.Where(x => x.BodyAreaDescID == ba.BodyAreaDescID).Select(x => x.MuscleDescName).ToArray();
                strJson += "\"" + String.Join(",", ms) + "\",";


            }

            strJson = strJson.Substring(0, strJson.Length - 1);
            strJson += "}";
            return strJson;
        }

    }
}
