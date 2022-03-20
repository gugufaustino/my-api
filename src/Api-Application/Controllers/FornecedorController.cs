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
    [Route("api/fornecedor")]
    public class FornecedorController : BaseApiController
    {

        const string Permissao = "FORNECEDOR";

        private readonly ILogger<ContaController> _logger;
        private readonly IMapper _mapper;



        private readonly IFornecedorService _service;
        private readonly IFornecedorRepository _repository;

        public FornecedorController(ILogger<ContaController> logger,
                               IMapper mapper,
                               IBroadcaster broadcaster,
                               IFornecedorService service,
                               IFornecedorRepository repository)
           : base(broadcaster)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _repository = repository;

            _logger.Log(LogLevel.Information, "ctor fornecedor");
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<FornecedorViewModel>> Listar()
        {
            var lista = await _repository.ListarTodos();
            lista = lista.OrderBy(i => i.RazaoSocial).ToList();
            return _mapper.Map<IEnumerable<FornecedorViewModel>>(lista);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorId(int id)
        {
            var fornecedor = await _repository.ObterPorId(id);

            return _mapper.Map<FornecedorViewModel>(fornecedor);
        }

        [HttpPost]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<FornecedorViewModel>> Inserir(FornecedorViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Fornecedor>(model);
            entity.Endereco = _mapper.Map<Endereco>(model);
           
            await _service.Adicionar(entity);

            return CustomResponse();
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<FornecedorViewModel>> Editar(int id, FornecedorViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<Fornecedor>(model);
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
