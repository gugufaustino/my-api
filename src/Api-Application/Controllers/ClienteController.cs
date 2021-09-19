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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiApplication.Controllers
{
    [Authorize]
    [Route("api/cliente")]
    public class ClienteController : BaseApiController
    {

        const string Permissao = "CLIENTE";

        private readonly ILogger<ContaController> _logger;
        private readonly IMapper _mapper;



        private readonly IClienteService _service;
        private readonly IClienteRepository _repository;

        public ClienteController(ILogger<ContaController> logger,                              
                               IMapper mapper,
                               IBroadcaster broadcaster,
                               IClienteService service,
                               IClienteRepository repository)
           : base(broadcaster)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<ClienteViewModel>> Listar()
        {
            var lista = await _repository.ListarTodos();
            lista = lista.ToList();
            return _mapper.Map<IEnumerable<ClienteViewModel>>(lista);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(int id)
        {
            var cliente = await _repository.ObterPorId(id);

            return _mapper.Map<ClienteViewModel>(cliente);
        }
        
        [HttpPost]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ClienteViewModel>> Inserir(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Cliente>(cliente);
            await _service.Adicionar(entity);

            return CustomResponse();
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ClienteViewModel>> Editar(int id, ClienteViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Cliente>(model);
            await _service.Editar(id, entity);

            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult> Deletar(int id)
        {
            await _service.Excluir(id);

            return CustomResponse();
        }


    }
}
