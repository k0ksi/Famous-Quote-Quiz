namespace QuoteQuiz.RestServices.Tests.Controllers
{
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PeopleControllerTests
    {
        [TestMethod]
        public void CreateQuoteAndPerson_GetQuoteAuthor_ShouldReturnCorrectAuthorName()
        {
            TestingEngine.CleanDatabase();
            var text = "Quiet people have the loudest minds.";
            var personName = "Stephen Hawking";

            var createPersonHttpPostResponse = TestingEngine.SubmitPersonHttpPost(personName);
            Assert.AreEqual(HttpStatusCode.Created, createPersonHttpPostResponse.StatusCode);

            var httpPostResponse = TestingEngine.SubmitQuoteHttpPost(text, personName);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
        }
    }
}