using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Quarto
    {
        public int Id { get; set; }

        [Required]
        public string? Numero { get; set; }

        public string? Tipo { get; set; }

        public decimal PrecoDiaria { get; set; }

        public bool Disponivel { get; set; }
    }
}
