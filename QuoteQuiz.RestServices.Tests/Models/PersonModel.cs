namespace QuoteQuiz.RestServices.Tests.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public QuoteModel[] Quotes { get; set; }
    }
}