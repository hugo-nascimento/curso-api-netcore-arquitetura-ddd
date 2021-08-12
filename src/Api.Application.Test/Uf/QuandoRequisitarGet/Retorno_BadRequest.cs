using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Uf.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É Possível Realizar o GetAll.")]
        public async Task E_Possivel_Invocar_a_Controller_Get()
        {
            var serviceMock = new Mock<IUfService>();
            serviceMock.Setup(m => m.GetTask(It.IsAny<Guid>())).ReturnsAsync(
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    Nome = "São Paulo",
                    Sigla = "SP"
                }
            );

            _controller = new UfsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido!");

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}