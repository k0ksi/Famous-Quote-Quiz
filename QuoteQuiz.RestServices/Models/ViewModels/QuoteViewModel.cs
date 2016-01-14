namespace QuoteQuiz.RestServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using QuoteQuiz.Models;

    public class QuoteViewModel
    {
        public string Text { get; set; }

        public string PersonName { get; set; }

        public static Expression<Func<Quote, QuoteViewModel>> Create
        {
            get
            {
                return quote => new QuoteViewModel()
                {
                    Text = quote.Text,
                    PersonName = quote.Person.Name
                };
            }
        }
    }
}