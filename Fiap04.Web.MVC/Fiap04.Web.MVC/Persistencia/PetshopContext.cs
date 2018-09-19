﻿using Fiap04.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fiap04.Web.MVC.Persistencia
{
    //Classe que gerencia as tabelas no bd
    public class PetshopContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        
    }
}