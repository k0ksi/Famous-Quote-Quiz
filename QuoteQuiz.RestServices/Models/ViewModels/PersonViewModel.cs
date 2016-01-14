namespace QuoteQuiz.RestServices.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using QuoteQuiz.Models;

    public class PersonViewModel
    {
        public string Name { get; set; }

        public static Expression<Func<Person, PersonViewModel>> Create
        {
            get
            {
                return person => new PersonViewModel()
                {
                    Name = person.Name
                };
            }
        }
    }
}