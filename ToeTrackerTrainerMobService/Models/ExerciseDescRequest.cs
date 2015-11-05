using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToeTrackerTrainerMobService.Models
{
    public class ExerciseDescRequest
    {
        public string ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string MuscleId { get; set; }
        public string SecondaryMuslceId { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }
    }
}