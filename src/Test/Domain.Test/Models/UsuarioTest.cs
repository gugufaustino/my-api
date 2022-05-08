using Business.Models;
using System;
using Xunit;

namespace Domain.Test.Models
{
    public class UsuarioTest
    {
        [Fact]
        public void Abreviacao_Test()
        {
            var usu1 = new Usuario { Nome = "Gugu" };
            var usu2 = new Usuario { Nome = "Wellington Faustino" };
            var usu3 = new Usuario { Nome = "Wellington Leal Faustino" };
            var usu4 = new Usuario { Nome = "Wellington Leal faustino" };

            var abrev1 = usu1.Abreviatura();
            var abrev2 = usu2.Abreviatura();
            var abrev3 = usu3.Abreviatura();

            Assert.Equal("G", abrev1);
            Assert.Equal("WF", abrev2);
            Assert.Equal("WF", abrev3);
            
            Assert.Equal("WF", usu4.Abreviatura());

        }
    }
}
