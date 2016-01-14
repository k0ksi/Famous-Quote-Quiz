namespace QuoteQuiz.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class QuoteBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(1000)]
        public string Text { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string PersonName { get; set; }
    }
}