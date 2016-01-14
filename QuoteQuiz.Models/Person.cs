namespace QuoteQuiz.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Person
    {
        public Person()
        {
            this.Quotes = new HashSet<Quote>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Quote> Quotes { get; set; }
    }
}