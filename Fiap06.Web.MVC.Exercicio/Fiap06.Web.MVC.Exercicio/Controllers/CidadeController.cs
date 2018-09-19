using Fiap06.Web.MVC.Exercicio.Models;
using Fiap06.Web.MVC.Exercicio.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap06.Web.MVC.Exercicio.Controllers
{
    public class CidadeController : Controller
    {
        private BrasilContext _context = new BrasilContext();

        public ActionResult Buscar(int? estado)
        {
            CarregarCombo();
            var lista = _context.Cidades.Include("Estado").Where(c => c.EstadoId == estado || estado == null).ToList();
            return View("Listar", lista);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var lista = _context.Estados.ToList();
            ViewBag.estados = new SelectList(lista, "EstadoId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            TempData["msg"] = "Cadastrado com Sucesso!";
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var cid = _context.Cidades.Find(id);
            return View(cid);
        }

        [HttpPost]
        public ActionResult Editar(Cidade cidade)
        {
            _context.Entry(cidade).State = EntityState.Modified;
            _context.SaveChanges();
            TempData["msg"] = "Atualizado com Sucesso!";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Listar()
        {
            CarregarCombo();
            var lista = _context.Cidades.Include("Estado").ToList();
            return View(lista);
        }

        private void CarregarCombo()
        {
            var ufs = _context.Estados.ToList();
            ViewBag.estados = new SelectList(ufs, "EstadoId", "Nome");
        }

        [HttpPost]
        public ActionResult Excluir(int id)
        {
            var cid = _context.Cidades.Find(id);
            _context.Cidades.Remove(cid);
            _context.SaveChanges();
            TempData["msg"] = "Removido com Sucesso!";
            return RedirectToAction("Listar");
        }
    }
}