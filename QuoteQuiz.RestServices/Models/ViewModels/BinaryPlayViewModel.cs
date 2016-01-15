namespace QuoteQuiz.RestServices.Models.ViewModels
{
    public class BinaryPlayViewModel
    {
        public QuoteViewModel Quote { get; set; }

        public PersonViewModel Person { get; set; }

        public bool Correct { get; set; }
    }
}