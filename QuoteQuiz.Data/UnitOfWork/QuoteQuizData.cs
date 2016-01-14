namespace QuoteQuiz.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using Repositories;
    using Models;

    public class QuoteQuizData : IQuoteQuizData
    {
        private readonly IQuoteQuizDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public QuoteQuizData(IQuoteQuizDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users => this.GetRepository<User>();

        public IRepository<Person> People => this.GetRepository<Person>();

        public IRepository<Quote> Quotes => this.GetRepository<Quote>();

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}