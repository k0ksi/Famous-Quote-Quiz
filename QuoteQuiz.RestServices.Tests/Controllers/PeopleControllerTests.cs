using System.Net;
using System.Net.Http;
using QuoteQuiz.RestServices.Tests.Models;

namespace QuoteQuiz.RestServices.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PeopleControllerTests
    {
        [TestMethod]
        public void CreateQuote_GetQuoteAuthor_ShouldReturnCorrectAuthorName()
        {
            TestingEngine.CleanDatabase();
            var quote = new QuoteModel()
            {
                Text = "If we knew what it was we were doing, it would not be called research, would it?"
            };

            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/quotes").Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            var quoteFromService = httpResponse.Content.ReadAsAsync<QuoteModel>().Result;
            Assert.IsTrue(quoteFromService.Id != 0);
        }         
    }
}