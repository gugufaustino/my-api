using Business.Interface.Repository;
using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Validations
{
    public class ModeloValidation : AbstractValidator<Modelo>
    {
        private readonly IModeloRepository _repository;

        public ModeloValidation(IModeloRepository repository)
        {
            this._repository = repository;

            RuleFor(u => u.Nome)
                .NotNull()
                .NotEmpty()
                .Length(2, 100); 
             
            RuleFor(u => u.Nome).Must(prop => prop.Contains(" "))
               .WithMessage("Escreva o nome completo.");

            RuleFor(u => u.CPF).Must(CpfUnico)
                .WithMessage("Este CPF já está cadastrado como modelo nessa agência.");

            RuleFor(u => u.Email).Must(EmailUnico)
                .WithMessage("Este E-mail pertence a outro modelo nessa agência.");             
            
        }

        private bool CpfUnico(Modelo model, string cpf)
        {
            return !_repository.Existe(i => i.CPF == cpf &&  i.Id != model.Id).Result;
        }
        private bool EmailUnico(Modelo model, string email)
        {
            return !_repository.Existe(i => i.Email == email && i.Id != model.Id).Result;
        }
        
    }
}
