﻿using System.ComponentModel.DataAnnotations;

namespace Rubrica.Models
{
    public class Città
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
