﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using System.Text.RegularExpressions;
using ToeTrackerTrainerMobService.DataObjects;
using ToeTrackerTrainerMobService.Models;

namespace ToeTrackerTrainerMobService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    public class CustomRegistrationController : ApiController
    {
        public ApiServices Services { get; set; }

        // POST api/CustomRegistration
        public HttpResponseMessage Post(RegistrationRequest registrationRequest)
        {
            if (!Regex.IsMatch(registrationRequest.username, "^[a-zA-Z0-9]{4,}$"))
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid username (at least 4 chars, alphanumeric only)");
            }
            else if (registrationRequest.password.Length < 8)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid password (at least 8 chars required)");
            }

            ToeTrackerTrainerMobContext context = new ToeTrackerTrainerMobContext();
            Account account = context.Accounts.Where(a => a.Username == registrationRequest.username).SingleOrDefault();
            if (account != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "That username already exists.");
            }
            else
            {
                byte[] salt = CustomLoginProviderUtils.generateSalt();
                Account newAccount = new Account
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = registrationRequest.username,
                    Salt = salt,
                    SaltedAndHashedPassword = CustomLoginProviderUtils.hash(registrationRequest.password, salt),
                    FirstName = registrationRequest.FirstName,
                    LastName = registrationRequest.LastName,
                    Phone = registrationRequest.Phone,
                    Address = registrationRequest.Address,
                    Email = registrationRequest.Email,
                    Trainer= registrationRequest.Trainer
                };
                context.Accounts.Add(newAccount);
                context.SaveChanges();
                return this.Request.CreateResponse(HttpStatusCode.Created,"{\"UserCreation\":\"Success\"}");
            }
        }
    }
}
