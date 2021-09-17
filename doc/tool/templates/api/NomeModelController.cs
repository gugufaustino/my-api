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
    [Route("api/#nomemodel#")]
    public class #NomeModel#Controller : BaseApiController
    {

        const string Permissao = "#NOMEMODEL#";

        private readonly ILogger<ContaController> _logger;
        private readonly IMapper _mapper;



        private readonly I#NomeModel#Service _service;
        private readonly I#NomeModel#Repository _repository;

        public #NomeModel#Controller(ILogger<ContaController> logger,                              
                               IMapper mapper,
                               IBroadcaster broadcaster,
                               I#NomeModel#Service service,
                               I#NomeModel#Repository repository)
           : base(broadcaster)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<#NomeModel#ViewModel>> Listar()
        {
             var lista = new List<#NomeModel#> { new #NomeModel# { Id = 1, /*RazaoSocial = "teste" */} }; 
            //var lista = await _repository.ListarTodos();
            lista = lista.OrderBy(i => i.DtVencimento).ToList();
            return _mapper.Map<IEnumerable<#NomeModel#ViewModel>>(lista);
        }

        [HttpGet("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<#NomeModel#ViewModel>> ObterPorId(int id)
        {
            var #nomemodel# = await _repository.ObterPorId(id);

            return _mapper.Map<#NomeModel#ViewModel>(#nomemodel#);
        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<#NomeModel#ViewModel>> Editar(int id, #NomeModel#ViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var entity = _mapper.Map<#NomeModel#>(model);
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
