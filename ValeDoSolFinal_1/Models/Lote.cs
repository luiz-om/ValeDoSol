using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValeDoSolFinal_1.Models
{
    [Table("Lote")]
    public class Lote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="O nome deve ter no minimo 2 caracters")]
        [MaxLength(140, ErrorMessage ="O nome pode ter no maximo 140 caracteres")]
        public string Proprietario { get; set; }
        
        public string CPF { get; set; }


        //Gera um checkbox
        public Boolean Socio { get; set; }
        public string Cavalete { get; set; } 

      public virtual  ICollection<Leitura> Leituras { get; set; }
    }
}