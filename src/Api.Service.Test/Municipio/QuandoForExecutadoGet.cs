using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Muinicipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGet : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método Get.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetTask(IdMunicipio)).ReturnsAsync(municipioDto);
            _service = _serviceMock.Object;

            var result = await _service.GetTask(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetTask(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.GetTask(IdMunicipio);
            Assert.Null(_record);

        }
    }
}
