namespace QuoteQuiz.RestServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using QuoteQuiz.Models;

    public class QuoteViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string PersonName { get; set; }

        public static Expression<Func<Quote, QuoteViewModel>> Create
        {
            get
            {
                return quote => new QuoteViewModel()
                {
                    Id = quote.Id,
                    Text = quote.Text,
                    PersonName = quote.Person.Name
                };
            }
        }
    }
}