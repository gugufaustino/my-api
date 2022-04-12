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
    [Route("api/modelo")]
    public class ModeloController : BaseApiController
    {

        const string Permissao = "MODELO";

        private readonly ILogger<ContaController> _logger;
        private readonly IMapper _mapper;



        private readonly IModeloService _service;
        private readonly IModeloRepository _repository;

        public ModeloController(ILogger<ContaController> logger,                              
                               IMapper mapper,
                               IBroadcaster broadcaster,
                               IModeloService service,
                               IModeloRepository repository)
           : base(broadcaster)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<ModeloViewModel>> Listar()
        {
            var lista = await _repository.ListarTodos();
            //lista = lista.OrderBy(i => i.Nome).ToList();
            return _mapper.Map<IEnumerable<ModeloViewModel>>(lista);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ModeloViewModel>> ObterPorId(int id)
        {
            var modelo = await _repository.ObterPorId(id);

            return _mapper.Map<ModeloViewModel>(modelo);
        }
        
        [HttpPost]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ModeloViewModel>> Inserir(ModeloViewModel conta)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Modelo>(conta);
            await _service.Adicionar(entity);

            return CustomResponse();
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ModeloViewModel>> Editar(int id, ModeloViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Modelo>(model);
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
