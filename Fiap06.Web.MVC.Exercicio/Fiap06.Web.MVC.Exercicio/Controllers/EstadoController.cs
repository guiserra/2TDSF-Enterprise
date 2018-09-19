using Fiap06.Web.MVC.Exercicio.Models;
using Fiap06.Web.MVC.Exercicio.Persistencia;
using Fiap06.Web.MVC.Exercicio.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap06.Web.MVC.Exercicio.Controllers
{
    public class EstadoController : Controller
    {
        private UnityOfWork _unit = new UnityOfWork();

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Estado estado)
        {
            _unit.EstadoRepository.Cadastrar(estado);
            _unit.Salvar();
            TempData["msg"] = "Cadastrado com Sucesso!";
            return RedirectToAction("Cadastrar");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}