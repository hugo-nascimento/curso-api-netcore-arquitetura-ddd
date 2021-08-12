using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Muinicipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Municipio.QuandoRequisitarGetCompleteByIBGE
{
    public class Retorno_Ok
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É Possível Realizar o GetCompleteByIBGE.")]
        public async Task E_Possivel_Invocar_a_Controller_GetCompleteByIBGE()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).ReturnsAsync(
                new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo"
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);

            var result = await _controller.GetCompleteByIBGE(1);
            Assert.True(result is OkObjectResult);

        }
    }
}
