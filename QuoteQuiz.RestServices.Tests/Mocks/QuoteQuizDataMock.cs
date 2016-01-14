namespace QuoteQuiz.RestServices.Tests.Mocks
{
    using Data.Repositories;
    using Data.UnitOfWork;
    using QuoteQuiz.Models;

    public class QuoteQuizDataMock : IQuoteQuizData
    {
        private readonly GenericRepositoryMock<User> usersMock;
        private readonly GenericRepositoryMock<Person> peopleMock;
        private readonly GenericRepositoryMock<Quote> quotesMock;
        
        public QuoteQuizDataMock()
        {
            this.usersMock = new GenericRepositoryMock<User>();
            this.peopleMock = new GenericRepositoryMock<Person>();
            this.quotesMock = new GenericRepositoryMock<Quote>();
        }

        public bool ChangesSaved { get; set; }

        public IRepository<User> Users => this.usersMock;

        public IRepository<Person> People => this.peopleMock;

        public IRepository<Quote> Quotes => this.quotesMock;

        public void SaveChanges()
        {
            this.ChangesSaved = true;
        }
    }
}