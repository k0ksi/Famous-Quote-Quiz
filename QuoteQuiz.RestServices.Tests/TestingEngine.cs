namespace QuoteQuiz.RestServices.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using EntityFramework.Extensions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using Microsoft.Owin.Testing;
    using Owin;
    using Data;
    using Models;

    [TestClass]
    public static class TestingEngine
    {
        private static TestServer TestWebServer { get; set; }

        public static HttpClient HttpClient { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Start OWIN testing HTTP server with Web API support
            TestWebServer = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);
                var webAppStartup = new Startup();
                webAppStartup.Configuration(appBuilder);
                appBuilder.UseWebApi(config);
            });
            HttpClient = TestWebServer.HttpClient;
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Stop the OWIN testing HTTP server
            TestWebServer.Dispose();
        }

        public static void CleanDatabase()
        {
            using (var dbContext = new QuoteQuizDbContext())
            {
                dbContext.Quotes.Delete();
                dbContext.People.Delete();
                dbContext.Users.Delete();
                dbContext.SaveChanges();
            }
        }

        public static int GetQuotesCountFromDb()
        {
            using (var dbContext = new QuoteQuizDbContext())
            {
                return dbContext.Quotes.Count();
            }
        }

        public static int GetPeopleCountFromDb()
        {
            using (var dbContext = new QuoteQuizDbContext())
            {
                return dbContext.Quotes.Count();
            }
        }

        public static HttpResponseMessage RegisterUserHttpPost(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/register", postContent).Result;
            return httpResponse;
        }

        public static HttpResponseMessage LoginUserHttpPost(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/user/login", postContent).Result;
            return httpResponse;
        }

        public static UserSessionModel RegisterUser(string username, string password)
        {
            var httpResponse = TestingEngine.RegisterUserHttpPost(username, password);
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;
            return userSession;
        }

        public static UserSessionModel LoginUser(string username, string password)
        {
            var httpResponse = TestingEngine.LoginUserHttpPost(username, password);
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;
            return userSession;
        }

        public static HttpResponseMessage CreatePersonHttpPost(string name)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", name)
            });

            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/people", postContent).Result;

            return httpResponse;
        }

        public static HttpResponseMessage SubmitQuoteHttpPost(string text, string authorName)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("text", text),
                new KeyValuePair<string, string>("authorName", authorName)
            });

            var httpResponse = TestingEngine.HttpClient.PostAsync("/api/quotes", postContent).Result;

            return httpResponse;
        }
    }
}