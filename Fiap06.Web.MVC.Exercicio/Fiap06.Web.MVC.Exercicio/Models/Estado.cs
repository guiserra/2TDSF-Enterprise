using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fiap06.Web.MVC.Exercicio.Models
{
    [Table("TEstado")]
    public class Estado
    {
        [Column("Id")]
        public int EstadoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Sigla { get; set; }
        public int Populacao { get; set; }

        public List<Cidade> Cidades { get; set; }
    }
}