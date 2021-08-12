using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Muinicipio;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Municipio
{
    public class QuandoRequisitarMunicipio : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_CRUD_Municipio()
        {
            await AdicionarToken();

            var municipioDto = new MunicipioDtoCreate
            {
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                UfId = new Guid("0a66e2bb-a0e0-497f-80a7-dd4181477ae6")
            };
            
            // Post
            var response = await PostJsonAsync(municipioDto, $"{hostApi}municipios", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(municipioDto.Nome, registroPost.Nome);
            Assert.Equal(municipioDto.CodIBGE, registroPost.CodIBGE);
            Assert.False(registroPost.Id == default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}municipios");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<MunicipioDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(r=> r.Id == registroPost.Id).Count() == 1);

            // Put
            var updateMunicipioDto = new MunicipioDtoUpdate()
            {
                Id = registroPost.Id,
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                UfId = new Guid("0a66e2bb-a0e0-497f-80a7-dd4181477ae6")
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateMunicipioDto), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}municipios", stringContent);

            jsonResult = await response.Content.ReadAsStringAsync();

            var registroAtualizado = JsonConvert.DeserializeObject<MunicipioDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Nome, registroAtualizado.Nome);
            Assert.NotEqual(registroPost.CodIBGE, registroAtualizado.CodIBGE);

            // Get id
            response = await client.GetAsync($"{hostApi}municipios/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<MunicipioDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionado.CodIBGE, registroAtualizado.CodIBGE);

            //GET Complete/Id
            response = await client.GetAsync($"{hostApi}Municipios/Complete/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoCompleto);
            Assert.Equal(registroSelecionadoCompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoCompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoCompleto.Uf);
            Assert.Equal("São Paulo", registroSelecionadoCompleto.Uf.Nome);
            Assert.Equal("SP", registroSelecionadoCompleto.Uf.Sigla);

            //GET byIBGE/CodIBGE
            response = await client.GetAsync($"{hostApi}Municipios/byIBGE/{registroAtualizado.CodIBGE}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoIBGECompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoIBGECompleto);
            Assert.Equal(registroSelecionadoIBGECompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoIBGECompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoIBGECompleto.Uf);
            Assert.Equal("São Paulo", registroSelecionadoIBGECompleto.Uf.Nome);
            Assert.Equal("SP", registroSelecionadoIBGECompleto.Uf.Sigla);


            // Delete
            response = await client.DeleteAsync($"{hostApi}municipios/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}Municipios/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);


        }
    }
}
