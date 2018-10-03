using Fiap06.Web.MVC.Exercicio.Models;
using Fiap06.Web.MVC.Exercicio.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Fiap06.Web.MVC.Exercicio.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private BrasilContext _context;

        public CidadeRepository(BrasilContext paisContext)
        {
            _context = paisContext;
        }

        public IList<Cidade> BuscarPor(Expression<Func<Cidade, bool>> filtro)
        {
            return _context.Cidades.Include("Estado")
                .Where(filtro).ToList();
        }

        public Cidade BuscarPorCodigo(int id)
        {
            return _context.Cidades.Find(id);
        }

        public void Cadastrar(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
        }

        public void Editar(Cidade cidade)
        {
            _context.Entry(cidade).State = EntityState.Modified;
        }

        public void Excluir(int id)
        {
            var cidade = BuscarPorCodigo(id);
            _context.Cidades.Remove(cidade);
        }

        public IList<Cidade> Listar()
        {
            return _context.Cidades.Include("Estado").ToList();
        }
    }
}