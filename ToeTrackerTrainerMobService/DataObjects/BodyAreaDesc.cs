using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToeTrackerTrainerMobService.DataObjects
{
    public class BodyAreaDesc
    {
        public string BodyAreaDescID { get; set; }
        public string BodyAreaName { get; set; }
        public virtual ICollection<MuscleDesc> MuscleDesc { get; set; }
    }
}