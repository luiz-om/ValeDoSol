using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ValeDoSolFinal_1.Context
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }
    }
}