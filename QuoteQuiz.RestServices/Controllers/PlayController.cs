namespace QuoteQuiz.RestServices.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Net.Http;
    using Models.ViewModels;
    using System.Web.Mvc;

    public class PlayController : Controller
    {
        public PlayController()
        {
            this.HttpClient = new HttpClient();
        }

        private HttpClient HttpClient { get; }

        public ActionResult ChooseMode()
        {
            return this.View();
        }

        public ActionResult PlayBinary()
        {
            var host = GetHostLeftPart();
            var randomQuote = GetRandomQuoteFromDb(host);
            var quoteId = randomQuote.Id;

            var quoteAuthor = GetQuoteAuthorFromDb(quoteId, host);
            var randomPerson = GetRandomPersonFromDb(host);

            var people = new List<PersonViewModel>() {quoteAuthor, randomPerson};
            var shuffledPeople = Shuffle(people).ToList();
            var defaultIndex = 0;
            var chosenRandomPerson = shuffledPeople[defaultIndex];

            bool isCorrect = chosenRandomPerson.Name.Equals(randomQuote.PersonName);
            var binaryPlayViewModel = new BinaryPlayViewModel()
            {
                Person = chosenRandomPerson,
                Quote = randomQuote,
                Correct = isCorrect
            };

            return this.View(binaryPlayViewModel);
        }

        public ActionResult PlayMultiple()
        {
            var host = GetHostLeftPart();
            var randomQuote = GetRandomQuoteFromDb(host);
            var quoteId = randomQuote.Id;

            var quoteAuthor = GetQuoteAuthorFromDb(quoteId, host);
            var randomPerson = GetRandomPersonNotAuthorOfQuoteFromDb(quoteId, host);
            int randomPersonId = randomPerson.Id;
            var secondRandomPerson = GetRandomPersonNotAuthorOfQuoteFromDb(quoteId, host, randomPersonId);

            var people = new List<PersonViewModel> {quoteAuthor, randomPerson, secondRandomPerson};
            
            var multipleAnswersPlayViewModel = new MultipleAnswersPlayViewModel()
            {
                Quote = randomQuote,
                People = Shuffle(people)
            };

            return this.View(multipleAnswersPlayViewModel);
        }

        private PersonViewModel GetRandomPersonFromDb(string host)
        {
            var randomPersonHttpResponse = this.HttpClient.GetAsync(host + "/api/people/person").Result;
            var randomPerson = randomPersonHttpResponse.Content.ReadAsAsync<PersonViewModel>().Result;

            return randomPerson;
        }

        private PersonViewModel GetQuoteAuthorFromDb(int quoteId, string host)
        {
            var quoteAuthorHttpResponse = this.HttpClient.GetAsync(host + "/api/people/author/" + quoteId).Result;
            var quoteAuthor = quoteAuthorHttpResponse.Content.ReadAsAsync<PersonViewModel>().Result;

            return quoteAuthor;
        }

        private QuoteViewModel GetRandomQuoteFromDb(string host)
        {
            var randomQuoteHttpResponse = this.HttpClient.GetAsync(host + "/api/quotes/randomQuote").Result;
            var randomQuote = randomQuoteHttpResponse.Content.ReadAsAsync<QuoteViewModel>().Result;

            return randomQuote;
        }

        private PersonViewModel GetRandomPersonNotAuthorOfQuoteFromDb(int quoteId, string host, int? randomPersonId = null)
        {
            string randomPersonIdString = "";
            if (randomPersonId != null)
            {
                randomPersonIdString = randomPersonId.Value.ToString();
            }
            var randomPersonHttpResponse = this.HttpClient.GetAsync(host + "/api/people/person/" + quoteId + "/" + randomPersonIdString).Result;
            var randomPerson = randomPersonHttpResponse.Content.ReadAsAsync<PersonViewModel>().Result;

            return randomPerson;
        }

        // Fisher–Yates Shuffle Algorithm
        public IList<T> Shuffle<T>(IList<T> source)
        {
            Random rnd = new Random();
            var array = source.ToArray();
            var n = array.Length;
            for (var i = 0; i < n; i++)
            {
                int r = i + rnd.Next(0, n - i);
                var temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }

            return array;
        }

        private string GetHostLeftPart()
        {
            var host = Request.Url.GetLeftPart(UriPartial.Authority);

            return host;
        }
    }
}