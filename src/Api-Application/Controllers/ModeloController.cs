using ApiApplication.Extensions;
using ApiApplication.ViewModel;
using AutoMapper;
using Business.Interface;
using Business.Interface.Repository;
using Business.Interface.Services;
using Business.Models;
using Business.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ApiApplication.Controllers
{
    [Authorize]
    [Route("api/modelo")]
    public class ModeloController : BaseApiController
    {

        const string Permissao = "MODELO";
        private readonly IMapper _mapper;

        //TODO: criar observabilidade
        // private readonly ILogger<ModeloController> _logger;



        private readonly IModeloService _service;
        private readonly IModeloRepository _repository;

        public ModeloController(
                               IMapper mapper,
                               IBroadcaster broadcaster,
                               IModeloService service,
                               IModeloRepository repository)
           : base(broadcaster)
        {

            _service = service;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("listar-catalogo")]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<CatalogoViewModel>> ListarCatalogo([FromQuery] CatalogoModeloFilter filtro)
        {
            var lista = await _repository.Pesquisar(filtro);
            lista = lista.OrderBy(i => i.Nome).ToList();
            return _mapper.Map<IEnumerable<CatalogoViewModel>>(lista);
        }
        [HttpGet]
        [ClaimsAuthorize(Permissao)]
        public async Task<IEnumerable<ModeloViewModel>> Listar([FromQuery] CatalogoModeloFilter filtro)
        {
            var lista = await _repository.Pesquisar(filtro);
            lista = lista.OrderBy(i => i.Nome).ToList();
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
        public async Task<ActionResult<ModeloViewModel>> Adicionar(ModeloViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            if (!UploadArquivo(model.ImagemPerfilUpload, model.ImagemPerfilNome = Guid.NewGuid() + "_" + model.ImagemPerfilNome))
                return CustomResponse(model);

            var entity = _mapper.Map<Modelo>(model);
            await _service.Adicionar(entity);
            scope.Complete();
            return CustomResponse();

        }

        [HttpPut("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult<ModeloViewModel>> Atualizar(int id, ModeloViewModel model)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            if (!string.IsNullOrEmpty(model.ImagemPerfilUpload) && !UploadArquivo(model.ImagemPerfilUpload, model.ImagemPerfilNome = Guid.NewGuid() + "_" + model.ImagemPerfilNome))
                return CustomResponse(model);

            var entity = _mapper.Map<Modelo>(model);
            await _service.Editar(id, entity);
            scope.Complete();
            return CustomResponse();
        }

        [HttpDelete("{id:int}")]
        [ClaimsAuthorize(Permissao)]
        public async Task<ActionResult> Deletar(int id)
        {
            await _service.Excluir(id);

            return CustomResponse();
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                ToTransmit("Forneça uma imagem!");
                return false;
            }

            var imageDataByteArray = System.Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\profile", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                ToTransmit("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }


    }
}
