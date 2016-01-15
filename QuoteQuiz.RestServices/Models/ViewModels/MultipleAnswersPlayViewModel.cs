namespace QuoteQuiz.RestServices.Models.ViewModels
{
    using System.Collections.Generic;

    public class MultipleAnswersPlayViewModel
    {
        public QuoteViewModel Quote { get; set; }

        public IList<PersonViewModel> People { get; set; } 
    }
}