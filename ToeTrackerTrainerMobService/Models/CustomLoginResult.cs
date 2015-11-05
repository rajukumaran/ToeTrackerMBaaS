using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToeTrackerTrainerMobService.Models
{
    public class CustomLoginResult
    {
        public string UserId { get; set; }
        public string MobileServiceAuthenticationToken { get; set; }

        public string UserType { get; set; }

    }
}