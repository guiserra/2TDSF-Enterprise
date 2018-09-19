using Fiap04.Web.MVC.Models;
using Fiap04.Web.MVC.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap04.Web.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private PetshopContext _context = new PetshopContext();

        [HttpGet]
        public ActionResult Buscar(string nomeBusca)
        {
            //Perquisar por nome no banco
            var lista = _context.Produtos.Where(p => p.Nome.Contains(nomeBusca)).ToList();
            //Joga a lista para a tela de Listar


            return View("Listar",lista);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var produto = _context.Produtos.Find(id);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Editar(Produto p)
        {
            _context.Entry(p).State = EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Produto atualizado!";
            return RedirectToAction("Listar");
        }

        //Excluir
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var p = _context.Produtos.Find(id);
            _context.Produtos.Remove(p);
            _context.SaveChanges();
            TempData["msg"] = "Removido!";
            return RedirectToAction("Listar");
        }

        //Listar
        [HttpGet]
        public ActionResult Listar()
        {
            return View(_context.Produtos.ToList());
        }

        //Cadastrar
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto p)
        {
            _context.Produtos.Add(p);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado com sucesso!";

            return RedirectToAction("Cadastrar");
        }
    }
}