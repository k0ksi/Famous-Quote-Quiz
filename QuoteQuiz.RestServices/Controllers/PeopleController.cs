namespace QuoteQuiz.RestServices.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Models.ViewModels;
    
    [RoutePrefix("api")]
    public class PeopleController : BaseApiController
    {
        // GET api/people/all
        [HttpGet]
        [Route("people/all")]
        public IHttpActionResult ListAllPeople()
        {
            var people = this.Data.People
                .All()
                .OrderBy(p => p.Name)
                .Select(PersonViewModel.Create);

            return this.Ok(people);
        }
    }
}