using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using ToeTrackerTrainerMobService.DataObjects;
using ToeTrackerTrainerMobService.Models;
using Microsoft.WindowsAzure.Mobile.Service.Security;
using System;
using System.Collections.Generic;

namespace ToeTrackerTrainerMobService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class TrainerAssociationController : TableController<TrainerAssociation>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ToeTrackerTrainerMobContext context = new ToeTrackerTrainerMobContext();
            DomainManager = new EntityDomainManager<TrainerAssociation>(context, Request, Services);
        }

        // GET tables/TrainerAssociation
        public IQueryable<TrainerAssociation> GetAllTrainerAssociation()
        {
            var currentUser = User as ServiceUser;

            return Query().Where(todo => todo.TrainerID == currentUser.Id);
        }

        // GET tables/TrainerAssociation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TrainerAssociation> GetTrainerAssociation(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TrainerAssociation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TrainerAssociation> PatchTrainerAssociation(string id, Delta<TrainerAssociation> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TrainerAssociation
        public async Task<IHttpActionResult> PostTrainerAssociation(TrainerAssociation item)
        {
            ToeTrackerTrainerMobContext context = new ToeTrackerTrainerMobContext();
            var currentUser = User as ServiceUser;
            item.TrainerID = currentUser.Id;
            item.Id = System.Guid.NewGuid().ToString();
            item.Active = true;
            item.StartDate = DateTime.Now;
            item.EndDate = DateTime.Now.AddYears(100);
            if (context.Accounts.Where(x => x.Username == item.TraineeID).Count() > 0)
            {
                TrainerAssociation current = await InsertAsync(item);
                return CreatedAtRoute("Tables", new { id = current.Id }, current);
            }
            else
                throw new Exception("The trainee is not registered, please register the trainee");
        }

        // DELETE tables/TrainerAssociation/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTrainerAssociation(string id)
        {
             return DeleteAsync(id);
        }

    }
}