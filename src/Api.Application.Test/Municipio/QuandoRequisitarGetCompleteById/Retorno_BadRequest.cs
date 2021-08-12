using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Muinicipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetCompleteById
{
    public class Retorno_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É Possível Realizar o GetCompleteById.")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompleteById()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(
                new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo"
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido!");

            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
