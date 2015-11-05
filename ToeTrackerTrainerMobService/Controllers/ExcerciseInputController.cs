using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using ToeTrackerTrainerMobService.DataObjects;
using ToeTrackerTrainerMobService.Models;
using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace ToeTrackerTrainerMobService.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.User)]
    public class ExcerciseInputController : TableController<ExcerciseInput>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ToeTrackerTrainerMobContext context = new ToeTrackerTrainerMobContext();
            DomainManager = new EntityDomainManager<ExcerciseInput>(context, Request, Services);
        }

        // GET tables/ExcerciseInput
        public IQueryable<ExcerciseInput> GetAllExcerciseInput()
        {
            return Query(); 
        }

        // GET tables/ExcerciseInput/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ExcerciseInput> GetExcerciseInput(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ExcerciseInput/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ExcerciseInput> PatchExcerciseInput(string id, Delta<ExcerciseInput> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ExcerciseInput
        [AuthorizeLevel(AuthorizationLevel.User)]
        public async Task<IHttpActionResult> PostExcerciseInput(ExcerciseInput item)
        {
            ExcerciseInput current = await InsertAsync(item);
            item.Id = System.Guid.NewGuid().ToString();
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ExcerciseInput/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteExcerciseInput(string id)
        {
             return DeleteAsync(id);
        }

    }
}