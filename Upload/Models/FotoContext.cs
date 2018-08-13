using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Upload.Models
{
    public class FotoContext : DbContext
    {
        public FotoContext() : base("FotoFb")
        {

        }

        public DbSet<Foto> Fotos { get; set; }

    }

}