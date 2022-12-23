using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
    public class CategoriaDaoComEfCore : ICategoriaDao
    {
        AppDbContext context;

        public CategoriaDaoComEfCore(AppDbContext context)
        {
            this.context = context;
        }

        public Categoria BuscarPorId(int id)
        {
            return context.Categorias
                .Include(c => c.Leiloes)
                .First(c => c.Id == id);
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return context.Categorias
                .Include(c => c.Leiloes);
        }

    }
}
