using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {
        IAdminService defaultService;
        public ArquivamentoAdminService(ILeilaoDao dao, ICategoriaDao categoriaDao)
        {
            this.defaultService = new DefaultAdminService(dao, categoriaDao);
        }
        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return defaultService.ConsultaCategorias();
        }
        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return defaultService.ConsultaLeiloes().Where(l =>l.Situacao != SituacaoLeilao.Arquivado);
        }
        public Leilao ConsultaLeilaoPorId(int id)
        {
            return defaultService.ConsultaLeilaoPorId(id);
        }
        public void CadastraLeilao(Leilao leilao)
        {
            defaultService.CadastraLeilao(leilao);
        }
        public void ModificaLeilao(Leilao leilao)
        {
            defaultService.ModificaLeilao(leilao);
        }
        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                defaultService.ModificaLeilao(leilao);
            }
        }
        public void IniciaPregaoDoLeilaoComId(int id)
        {
            defaultService.IniciaPregaoDoLeilaoComId(id);
        }
        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            defaultService.FinalizaPregaoDoLeilaoComId(id);
        }
    }

}
