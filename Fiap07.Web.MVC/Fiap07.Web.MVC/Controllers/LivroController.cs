﻿using Fiap07.Web.MVC.Models;
using Fiap07.Web.MVC.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fiap07.Web.MVC.Controllers
{
    public class LivroController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork();

        [HttpPost]
        public ActionResult Excluir(int codigo)
        {
            _unit.LivroRepository.Remover(codigo);
            _unit.Salvar();
            TempData["msg"] = "Livro Excluido";
            return RedirectToAction("Listar");
        }

        [HttpGet]
        public ActionResult Buscar(string titulo)
        {
            var livros = _unit.LivroRepository.BuscarPor(l => l.Titulo.Contains(titulo));
            return View("Listar", livros);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(_unit.LivroRepository.Listar());
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            var lista = _unit.EditoraRepository.Listar();
            ViewBag.editoras = new SelectList(lista, "EditoraId", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Livro livro)
        {
            _unit.LivroRepository.Cadastrar(livro);
            _unit.Salvar();
            TempData["msg"] = "Livro cadastrado";
            return RedirectToAction("Cadastrar");
        }

        protected override void Dispose(bool disposing)
        {
            _unit.Dispose();
            base.Dispose(disposing);
        }
    }
}