using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Business.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository,
                                IBroadcaster broadcaster)
            : base(broadcaster)
        {
            _repository = repository;

        }

        public async Task Adicionar(Usuario usuario)
        {

            if (!ExecuteValidations(new UsuarioValidator(), usuario)) return;

            await _repository.Adicionar(usuario);
             
        }
       
        public async Task<Usuario> ObterUsuarioLogon(string email)
        {
            var retorno = await _repository.Obter(w => w.Email == email);
            return retorno;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
