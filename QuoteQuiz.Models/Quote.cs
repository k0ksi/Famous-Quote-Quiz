namespace QuoteQuiz.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Quote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(1000)]
        public string Text { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}