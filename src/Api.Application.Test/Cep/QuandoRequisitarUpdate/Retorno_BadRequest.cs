using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possível Realizar o Created.")]
        public async Task E_Possivel_Invocar_a_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Logradouro = Faker.Address.StreetName(),
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Nome", "É um Campo Obrigatório!");

            var cepDtoUpdate = new CepDtoUpdate
            {
                Logradouro = Faker.Address.StreetName(),
                Numero = Faker.RandomNumber.Next(1, 1000).ToString()
            };

            var result = await _controller.Put(cepDtoUpdate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
