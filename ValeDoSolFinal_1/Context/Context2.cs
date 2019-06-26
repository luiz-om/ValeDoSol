using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ValeDoSolFinal_1.Models;

namespace ValeDoSolFinal_1.Context
{
    public class Context2 : DbContext
    {
        public Context2() : base("DefaultConnection")
        {

        }

        public DbSet<Lote> Lote { get; set; }
        public DbSet<Leitura> Leitura { get; set; }
        public DbSet<Consumo> Consumo{ get; set; }

      

    }
}