namespace QuoteQuiz.Data
{
    using System.Data.Entity;
    using Models;

    public interface IQuoteQuizDbContext
    {
        IDbSet<Quote> Quotes { get; set; }  

        IDbSet<Person> People { get; set; }

        int SaveChanges();
    }
}