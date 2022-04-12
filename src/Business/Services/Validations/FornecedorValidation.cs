using Business.Interface.Repository;
using Business.Models;
using FluentValidation;

namespace Business.Services.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        readonly IFornecedorRepository _repository;
        public FornecedorValidation(IFornecedorRepository repository)
        {
            _repository = repository;

            RuleFor(u => u.Cnpj).Must(CnpjUnico)
               .WithMessage("O CNPJ informado já esta cadastrado.");
        }

        private bool CnpjUnico(Fornecedor fornecedor, string cnpj)
        {
            return !_repository.Existe(i => i.Id != fornecedor.Id && i.Cnpj == cnpj).Result;

        }
    }


}
