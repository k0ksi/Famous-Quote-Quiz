namespace QuoteQuiz.RestServices.Controllers
{
    using System.Web.Http;
    using Data;
    using Data.UnitOfWork;

    public class BaseApiController : ApiController
    {
        protected BaseApiController()
            : this(new QuoteQuizData(new QuoteQuizDbContext()))
        {
        }

        protected BaseApiController(IQuoteQuizData data)
        {
            this.Data = data;
        }

        protected IQuoteQuizData Data { get; private set; }
    }
}