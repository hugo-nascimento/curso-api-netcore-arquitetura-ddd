using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoUpdate : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        
        [Fact(DisplayName = "É possível Executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var _result = await _service.Post(userDtoCreate);
            Assert.NotNull(_result);
            Assert.Equal(NomeUsuario, _result.Name);
            Assert.Equal(EmailUsuario, _result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var _resultUpdate = await _service.Put(userDtoUpdate);
            Assert.NotNull(_resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, _resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, _resultUpdate.Email);


        }
        
    }
}
