﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToeTrackerTrainerMobService.Models
{
    public class RegistrationRequest
    {
        public String username { get; set; }
        public String password { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public Boolean Trainer { get; set; }
    }
}