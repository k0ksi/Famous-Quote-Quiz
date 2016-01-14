namespace QuoteQuiz.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Models.ViewModels;
    using QuoteQuiz.Models;
    
    [RoutePrefix("api")]
    public class PeopleController : BaseApiController
    {
        private const int MinPersonId = 1;
        
        // GET api/people/person
        [HttpGet]
        [Route("people/person")]
        public IHttpActionResult GetRandomPerson()
        {
            var random = new Random();
            var lastPersonId = GetLastPersonId();
            var randomId = random.Next(MinPersonId, lastPersonId);
            var person = this.Data.People
                .All()
                .Select(PersonViewModel.Create)
                .FirstOrDefault(p => p.Id == randomId);

            return this.Ok(person);
        }

        // GET api/people/author/{quoteId}
        [HttpGet]
        [Route("people/author/{quoteId}")]
        public IHttpActionResult GetQuoteAuthor(int quoteId)
        {
            var quote = GetQuoteById(quoteId);
            var authorName = quote.Person.Name;
            var author = this.Data.People
                .All()
                .Select(PersonViewModel.Create)
                .FirstOrDefault(a => a.Name == authorName);

            return this.Ok(author);
        }

        // GET api/people/person/{quoteId}/{secondPersonNotAuthorId}
        [HttpGet]
        [Route("people/person/{quoteId}/{secondPersonNotAuthorId}")]
        public IHttpActionResult GetRandomPersonNotAuthorOfQuote(int quoteId, int? secondPersonNotAuthorId = 0)
        {
            var quote = GetQuoteById(quoteId);
            var authorId = quote.PersonId;
            var lastPersonId = GetLastPersonId();

            Random random = new Random();
            var randomPersonId = int.MinValue;
            while (true)
            {
                if ((randomPersonId != authorId &&
                    randomPersonId != secondPersonNotAuthorId) &&
                    randomPersonId != int.MinValue)
                {
                    break;
                }

                randomPersonId = random.Next(MinPersonId, lastPersonId);
            }

            var person = this.Data.People
                .All()
                .Select(PersonViewModel.Create)
                .FirstOrDefault(a => a.Id == randomPersonId);

            return this.Ok(person);
        }

        private int GetLastPersonId()
        {
            var lastPersonId = this.Data.People
                .All()
                .Max(p => p.Id);

            return lastPersonId;
        }

        private Quote GetQuoteById(int quoteId)
        {
            var quote = this.Data.Quotes
                .All()
                .FirstOrDefault(q => q.Id == quoteId);

            return quote;
        }
    }
}