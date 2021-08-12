using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarGetByCep
{
    public class Retorno_Ok
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possível Realizar o GetByCep.")]
        public async Task E_Possivel_Invocar_a_Controller_GetByCep()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName()
                }
            );

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.Get(Faker.RandomNumber.Next(10000, 99999).ToString());
            Assert.True(result is OkObjectResult);

        }
    }
}
