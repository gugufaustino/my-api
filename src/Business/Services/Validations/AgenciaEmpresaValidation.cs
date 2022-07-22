using Business.Interface.Repository;
using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Validations
{
    public class AgenciaEmpresaValidation : AbstractValidator<AgenciaEmpresa>
    {
        private readonly IAgenciaEmpresaRepository _repository;

        public AgenciaEmpresaValidation(IAgenciaEmpresaRepository repository)
        {
            this._repository = repository;
             
            RuleFor(u => u.Email).Must(EmailUnico)
                .WithMessage("Este E-mail já está sendo utilizado.");

            RuleFor(u => u.Cnpj).Must(CnpjUnico)
                .WithMessage("Este CNPJ já está cadastrado.");
            
        }

        private bool EmailUnico(string cpf)
        {
            return !_repository.Existe(i => i.Email == cpf).Result;
        }
        private bool CnpjUnico(string telefone)
        {
            return !_repository.Existe(i => i.Cnpj == telefone).Result;
        }
    }
}
