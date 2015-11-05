using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToeTrackerTrainerMobService.DataObjects
{
    public class ExcerciseInput:EntityData
    {
        public string User { get; set; }
        public string ExerciseName { get; set; }
        public int Unit1 { get; set; }
        public int Unit2 { get; set; }
        public int Unit3 { get; set; }

        // Foreign key 
        public string ExerciseDescID { get; set; }

        
    }
}