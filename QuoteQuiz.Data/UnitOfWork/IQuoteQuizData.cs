namespace QuoteQuiz.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface IQuoteQuizData
    {
        IRepository<User> Users { get; } 

        IRepository<Person> People { get; } 

        IRepository<Quote> Quotes { get; }

        void SaveChanges();
    }
}