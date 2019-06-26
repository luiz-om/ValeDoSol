using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ValeDoSolFinal_1.Models
{
    public class Consumo
    {
        [Key, ForeignKey("Leitura")]
        public int Id { get; set; }

        public Double Valor { get; set; }

        public DateTime?  DataPagamento { get; set; }
         
        

        public virtual Leitura Leitura { get; set; }
    }
}