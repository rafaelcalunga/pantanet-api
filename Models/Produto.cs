using System;
using System.ComponentModel.DataAnnotations;

namespace PantaNet.Api.Models
{
    public class Produto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }
    }
}