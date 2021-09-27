using ApiApplication.Extensions;
using ApiApplication.ViewModel;
using AutoMapper;
using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApplication.Controllers
{
    [Authorize]
    [Route("api/cadastro")]
    public class CadastroController : BaseApiController
    {


        const string Permissao = "USUARIO";

        private readonly ILogger<CadastroController> _logger;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public CadastroController(ILogger<CadastroController> logger,
                                    IUsuarioRepository repository,
                                    IUsuarioService service,
                                    IMapper mapper,
                                    IBroadcaster broadcaster)
           : base(broadcaster)
        {
            _logger = logger;
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var lista = await _repository.ListarTodos();
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(lista);            
        }


        [HttpGet("listar/{nome}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<UsuarioViewModel>> ListarPorNome(string nome)
        {
            var lista = await _repository.Listar(e => e.Nome == nome);
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(lista);
        }


        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<UsuarioViewModel>> Obter(int id)
        {
            var usuario = await _repository.ObterPorId(id);
            if (usuario == null) return NotFound();

            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        [HttpGet("obter-apelido/{email}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<UsuarioViewModel>> ObterApelido(string email)
        {

            var result = await _repository.Listar(e => e.Email == email);
            var usuario = result.FirstOrDefault();
            if (usuario == null) return NotFound();

            return CustomResponse(new { apelido = usuario.Apelido });
        }


        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _service.Adicionar(_mapper.Map<Usuario>(usuario));

            return CustomResponse();
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, UsuarioViewModel usuarioViewModel)
        {

            if (id != usuarioViewModel.Id) return BadRequest();
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //TODO implementar aqui service atualização da entidade

            return CustomResponse();
        }

        [HttpDelete("{id}")]
        public  ActionResult  Delete(int id)
        {
            UsuarioViewModel usuarioViewModel = null;
            if (usuarioViewModel == null) return NotFound();

            return CustomResponse();
        }
    }
}
