namespace QuoteQuiz.RestServices.Controllers
{
    using System;
    using System.Linq;
    using Models.ViewModels;
    using System.Web.Http;

    [RoutePrefix("api")]
    public class QuotesController : BaseApiController
    {
        private const int MinQuoteId = 1;

        // GET api/quotes/quote
        [HttpGet]
        [Route("quotes/quote")]
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
    }
}