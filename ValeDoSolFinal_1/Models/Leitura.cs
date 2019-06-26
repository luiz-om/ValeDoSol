using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValeDoSolFinal_1.Models
{
    [Table("Leitura")]
    public class Leitura
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Lote")]
        public int LoteId { get; set; }

        public DateTime DataLeitura { get; set; }

        
        public int NumeroLeitura { get; set; }

        public virtual Lote Lote { get; set; }

        public virtual Consumo Consumo { get; set; }

        
    }
}