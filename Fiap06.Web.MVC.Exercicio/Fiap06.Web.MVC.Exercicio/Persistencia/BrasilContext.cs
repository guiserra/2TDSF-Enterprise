using Fiap06.Web.MVC.Exercicio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fiap06.Web.MVC.Exercicio.Persistencia
{
    public class BrasilContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
    }
}