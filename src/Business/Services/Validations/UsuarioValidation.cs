using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nome)
                .NotNull()
                .NotEmpty()
                .Length(2, 100);

            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty();

            RuleFor(u => u.Password).Equal(u => u.ConfirmPassword)
                .WithMessage("O campo senha não confere, não está igual a confirmação");

            RuleFor(u => u.Nome).Must(prop => prop.Contains(" "))
               .WithMessage("Escreva o nome completo");
        }
    }
}
