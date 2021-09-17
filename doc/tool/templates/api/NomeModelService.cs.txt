using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class #NomeModel#Service : BaseService, I#NomeModel#Service
    {

        private readonly I#NomeModel#Repository _repository;
        public #NomeModel#Service(IBroadcaster broadcaster,
            I#NomeModel#Repository #NomeModel#Repository)
            : base(broadcaster)
        {
            _repository = #NomeModel#Repository;

        }

        public async Task Adicionar(#NomeModel# #nomemodel#)
        {
            await _repository.Adicionar(#nomemodel#);
        }

        public async Task Adicionar(List<#NomeModel#> lstGerar#NomeModel#s)
        {
            foreach (var #nomemodel# in lstGerar#NomeModel#s)
            {
                await _repository.Adicionar(#nomemodel#);
            }
        }

        public async Task Editar(int Id, #NomeModel# #nomemodel#)
        {
            var entity = await _repository.ObterPorId(Id);
            //entity.RazaoSocial = #nomemodel#.RazaoSocial;
             

            await _repository.Editar(entity);
        }
 

        public async Task Excluir(int id)
        {
            var entity = await _repository.ObterPorId(id);
           
            await _repository.Remover(entity);
        }
 

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
