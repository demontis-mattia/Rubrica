using System.ComponentModel.DataAnnotations;

namespace Rubrica.Models
{
    public class Contatto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        [StringLength(1)]
        public string Sesso { get; set; }

        public DateOnly? DataNascita { get; set; }

        [StringLength(20)]
        public string? NumeroTelefono { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [StringLength(50)]
        public string? Città { get; set; }
    }
}
