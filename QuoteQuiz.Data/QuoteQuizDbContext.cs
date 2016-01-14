namespace QuoteQuiz.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class QuoteQuizDbContext : IdentityDbContext<User>, IQuoteQuizDbContext
    {
        public QuoteQuizDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Quote> Quotes { get; set; }

        public IDbSet<Person> People { get; set; }

        public static QuoteQuizDbContext Create()
        {
            return new QuoteQuizDbContext();
        }
    }
}