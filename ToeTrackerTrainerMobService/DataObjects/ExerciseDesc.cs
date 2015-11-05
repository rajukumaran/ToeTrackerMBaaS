using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToeTrackerTrainerMobService.DataObjects
{
    public class ExerciseDesc:EntityData
    {
        public string ExerciseDescID { get; set; }
        public string ExerciseName { get; set; }
       
        public string SecondaryMuslceId { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }
        
        // Foreign key 
        public string MuscleDescID { get; set; }

        // Navigation properties 
        public virtual MuscleDesc MuscleDesc { get; set; }



    }
}