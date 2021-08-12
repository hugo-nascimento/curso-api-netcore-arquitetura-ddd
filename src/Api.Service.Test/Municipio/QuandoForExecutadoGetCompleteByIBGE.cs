using System.Threading.Tasks;
using Api.Domain.Dtos.Muinicipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;
using Xunit;


namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetCompleteByIBGE : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Possível Executar o Método GetCompleteByIBGE.")]
        public async Task E_Possivel_Executar_Metodo_GetCompleteByIBGE()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(CodigoIBGEMunicipio)).ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteByIBGE(CodigoIBGEMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.NotNull(result.Uf);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));
            _service = _serviceMock.Object;

            var _record = await _service.GetTask(IdMunicipio);
            Assert.Null(_record);
        }
    }
}
