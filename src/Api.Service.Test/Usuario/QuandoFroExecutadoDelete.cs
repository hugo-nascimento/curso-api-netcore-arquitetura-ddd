using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoFroExecutadoDelete: UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(IdUsuario)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var _deletado = await _service.Delete(IdUsuario);
            Assert.True(_deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            _deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(_deletado);

        }
    
        
    }
}
