using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class LeilaoDaoComEfCore : ILeilaoDao
    {
        AppDbContext context;
        public LeilaoDaoComEfCore(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Leilao> BuscarTodos()
        {
            return context.Leiloes.Include(i => i.Categoria).ToList();
        }

        public Leilao BuscarPorId(int id)
        {
            return context.Leiloes.First(x => x.Id == id);
        }

        public void Incluir(Leilao leilao)
        {
            context.Leiloes.Add(leilao);
            context.SaveChanges();
        }

        public void Alterar(Leilao leilao)
        {
            context.Leiloes.Update(leilao);
            context.SaveChanges();
        }

        public void Excluir(Leilao leilao)
        {
            context.Leiloes.Remove(leilao);
            context.SaveChanges();
        }
    }
}
