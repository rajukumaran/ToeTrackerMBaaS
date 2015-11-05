using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToeTrackerTrainerMobService.DataObjects
{
    public class MuscleDesc
    {
        public string MuscleDescID { get; set; }
        public string MuscleDescName { get; set; }
        public virtual ICollection<ExerciseDesc> ExerciseDesc { get; set; }
        public string BodyAreaDescID { get; set; }

        // Navigation properties 
        public virtual BodyAreaDesc BodyAreaDesc { get; set; }
    }
}