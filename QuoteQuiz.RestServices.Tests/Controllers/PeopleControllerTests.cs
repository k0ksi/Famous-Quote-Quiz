namespace QuoteQuiz.RestServices.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Models;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PeopleControllerTests
    {
        [TestMethod]
        public void CreatePeople_ListAllPeople_ShouldListCreatedPeopleCorrectly()
        {
            // Arrange -> prepare a few people objects
            TestingEngine.CleanDatabase();
            var peopleToAdd = new PersonModel[]
            {
                new PersonModel() { Name = "Albert Einstein"}, 
                new PersonModel() { Name = "Michael Jordan"}, 
                new PersonModel() { Name = "Woody Allan"},
            };

            // Act -> submit a few people objects
            foreach (var person in peopleToAdd)
            {
                var httpPostResponse = TestingEngine.CreatePersonHttpPost(person.Name);

                // Assert -> ensure each person is successfully created
                Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            }

            // Assert -> list the people and assert their count, order and content are correct
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/people/all").Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            var peopleFromService = httpResponse.Content.ReadAsAsync<List<PersonModel>>().Result;
            Assert.AreEqual(peopleToAdd.Count(), peopleFromService.Count);

            var reversedAddedPeople = peopleToAdd.Reverse().ToList();
            for (int i = 0; i < reversedAddedPeople.Count; i++)
            {
                Assert.IsTrue(peopleFromService[i].Id != 0);
                Assert.AreEqual(reversedAddedPeople[i].Name, peopleFromService[i].Name);
            }
        }

        [TestMethod]
        public void CreateQuoteAndPerson_GetQuoteAuthor_ShouldReturnCorrectAuthorName()
        {
            // Arrange -> prepare a quote and a person
            TestingEngine.CleanDatabase();
            var text = "Quiet people have the loudest minds.";
            var personName = "Stephen Hawking";

            // Act -> submit a person
            var createPersonHttpPostResponse = TestingEngine.CreatePersonHttpPost(personName);
            // Assert -> ensure the person is successfully created
            Assert.AreEqual(HttpStatusCode.Created, createPersonHttpPostResponse.StatusCode);
            
            // Act -> submit a quote
            var createQuoteHttpResponse = TestingEngine.CreateQuoteHttpPost(text, personName);
            // Assert -> ensure the quote is successfully created
            Assert.AreEqual(HttpStatusCode.Created, createQuoteHttpResponse.StatusCode);

            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/quotes/all").Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);

            var quotesFromService = httpResponse.Content.ReadAsAsync<List<QuoteModel>>().Result;
            var quoteFromService = quotesFromService
                .FirstOrDefault(q => q.Text == text);
            var peopleFromServiceHttpResponse = TestingEngine.HttpClient.GetAsync("/api/people/all").Result;
            Assert.AreEqual(HttpStatusCode.OK, peopleFromServiceHttpResponse.StatusCode);

            var peopleFromService = peopleFromServiceHttpResponse.Content.ReadAsAsync<List<PersonModel>>().Result;
            var personFromService = peopleFromService
                .FirstOrDefault(p => p.Name == personName);
            
            // Assert -> ensure the quote author is correct
            Assert.AreEqual(personFromService.Name, quoteFromService.PersonName);
        }
    }
}