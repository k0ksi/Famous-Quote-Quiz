namespace QuoteQuiz.RestServices.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class PersonBindingModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}