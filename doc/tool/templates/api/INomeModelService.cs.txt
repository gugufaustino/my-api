using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface.Services
{
   public interface I#NomeModel#Service : IDisposable
    {
        Task Adicionar(#NomeModel# #nomemodel#);
        Task Adicionar(List<#NomeModel#> lstGerar#NomeModel#s);
        Task Editar(int Id, #NomeModel# #nomemodel#);
        Task ExcluirPorConta(int id);
        Task Excluir(int id);
        Task EditarPago(int id, bool indPago);
    }
}
