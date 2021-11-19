using System.ComponentModel.DataAnnotations;

namespace BankMilleniumRekrutacja.Models
{
    public class FooRequest
    {
        [Required]
        public string Value { get; set; }
    }
}
