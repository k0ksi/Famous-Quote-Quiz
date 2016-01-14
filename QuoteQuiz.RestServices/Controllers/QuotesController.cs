namespace QuoteQuiz.RestServices.Controllers
{
    using System;
    using System.Linq;
    using Models.ViewModels;
    using System.Web.Http;
    using Models.BindingModels;
    using QuoteQuiz.Models;
    
    [RoutePrefix("api")]
    public class QuotesController : BaseApiController
    {
        private const int MinQuoteId = 1;

        // GET api/quotes/randomQuote
        [HttpGet]
        [Route("quotes/randomQuote")]
        public IHttpActionResult GetRandomQuote()
        {
            var random = new Random();
            var lastQuoteId = this.Data.Quotes
                .All()
                .Max(q => q.Id);
            var randomId = random.Next(MinQuoteId, lastQuoteId);
            var quote = this.Data.Quotes
                .All()
                .Select(QuoteViewModel.Create)
                .FirstOrDefault(q => q.Id == randomId);

            return this.Ok(quote);
        }

        // GET api/quotes/{quoteId}
        [HttpGet]
        [Route("quotes/{quoteId}")]
        public IHttpActionResult GetQuote(int quoteId)
        {
            var quote = this.Data.Quotes
                .All()
                .Select(QuoteViewModel.Create)
                .FirstOrDefault(q => q.Id == quoteId);

            return this.Ok(quote);
        }

        // GET api/quotes/all
        [HttpGet]
        [Route("quotes/all")]
        public IHttpActionResult ListAllQuotes()
        {
            var quotes = this.Data.Quotes
                .All()
                .Select(QuoteViewModel.Create);

            return this.Ok(quotes);
        }

        // POST api/quotes
        [HttpPost]
        [Route("quotes")]
        public IHttpActionResult CreateQuote(QuoteBindingModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Missing person data.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var personInDb = this.Data.People
                .All()
                .FirstOrDefault(p => p.Name == model.PersonName);

            if (personInDb == null)
            {
                return this.NotFound();
            }

            var personId = personInDb.Id;

            var quote = new Quote()
            {
                Text = model.Text,
                PersonId = personId
            };
            this.Data.Quotes.Add(quote);
            this.Data.SaveChanges();

            return this.CreatedAtRoute(
                "DefaultApi",
                new {controller = "quotes", id = quote.Id},
                new {quote.Id, QuoteText = quote.Text, Message = "Quote created."});
        }
    }
}