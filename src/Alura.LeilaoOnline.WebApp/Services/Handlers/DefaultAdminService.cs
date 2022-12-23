﻿using System;

using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDao dao;
        ICategoriaDao categoriaDao;

        public DefaultAdminService(ILeilaoDao dao, ICategoriaDao categoriaDao)
        {
            this.dao = dao;
            this.categoriaDao = categoriaDao;
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return categoriaDao.BuscarTodos();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return dao.BuscarTodos();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return dao.BuscarPorId(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            dao.Incluir(leilao);
        }
        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = dao.BuscarPorId(id);
            if(leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                dao.Alterar(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = dao.BuscarPorId(id);
            if(leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                dao.Alterar(leilao);
            }
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if(leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                dao.Excluir(leilao);
            }
        }

        public void ModificaLeilao(Leilao leilao)
        {
            dao.Alterar(leilao);
        }
    }
}
