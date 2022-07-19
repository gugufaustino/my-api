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
        private readonly IAgenciaService _agenciaService;
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository,
                                IBroadcaster broadcaster,
                                IAgenciaService agenciaService)
            : base(broadcaster)
        {
            _repository = repository;
            _agenciaService = agenciaService;
        }

        public async Task Adicionar(Usuario usuario)
        {

            if (!ExecuteValidations(new UsuarioValidator(), usuario)) return;

            if (usuario.TipoCadastro == TipoCadastroEnum.AgenteAutonomo)
            {
                var agencia = new Agencia(usuario.Nome)
                {
                    TipoSituacao = TipoSituacaoEnum.Ativado
                };

                await _agenciaService.Adicionar(agencia);
                usuario.Agencia = agencia;
            }

            await _repository.Adicionar(usuario);

        }

        public async Task<Usuario> ObterUsuarioLogon(string email)
        {
            return await _repository.ObterUsuarioLogon(email);
             
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
