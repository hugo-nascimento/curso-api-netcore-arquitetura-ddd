using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTestService
    {
        [Fact(DisplayName = "É possível Mapear os Modelos de Cep")]
        public void E_Possivel_Mapear_os_Modelos_Cep()
        {
            var cepDto = new CepModel
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();
            for (var i = 0; i < 5; i++)
            {
                var item = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                        UfId = Guid.NewGuid(),
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow,
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            Nome = Faker.Address.UsState(),
                            Sigla = Faker.Address.UsState().Substring(1, 3)
                        }
                    }
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<CepEntity>(cepDto);
            Assert.Equal(entity.Id, cepDto.Id);
            Assert.Equal(entity.Cep, cepDto.Cep);
            Assert.Equal(entity.Logradouro, cepDto.Logradouro);
            Assert.Equal(entity.Numero, cepDto.Numero);
            Assert.Equal(entity.CreateAt, cepDto.CreateAt);
            Assert.Equal(entity.UpdateAt, cepDto.UpdateAt);

            //Entity => Dto
            var userDto = Mapper.Map<CepDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Cep, entity.Cep);
            Assert.Equal(userDto.Logradouro, entity.Logradouro);
            Assert.Equal(userDto.Numero, entity.Numero);

            var userDtoCompleto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(userDtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(userDtoCompleto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(userDtoCompleto.Logradouro, listaEntity.FirstOrDefault().Logradouro);
            Assert.Equal(userDtoCompleto.Numero, listaEntity.FirstOrDefault().Numero);
            Assert.NotNull(userDtoCompleto.Municipio);
            Assert.NotNull(userDtoCompleto.Municipio.Uf);

            var listaDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (var i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
                Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
                Assert.Equal(listaDto[i].MunicipioId, listaEntity[i].MunicipioId);
            }

            var userDtoCreateResult = Mapper.Map<CepDtoCreateResult>(entity);
            Assert.Equal(userDtoCreateResult.Id, entity.Id);
            Assert.Equal(userDtoCreateResult.Cep, entity.Cep);
            Assert.Equal(userDtoCreateResult.Logradouro, entity.Logradouro);
            Assert.Equal(userDtoCreateResult.Numero, entity.Numero);
            Assert.Equal(userDtoCreateResult.MunicipioId, entity.MunicipioId);
            Assert.Equal(userDtoCreateResult.CreateAt, entity.CreateAt);
            
            var userDtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(userDtoUpdateResult.Id, entity.Id);
            Assert.Equal(userDtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(userDtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(userDtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(userDtoUpdateResult.MunicipioId, entity.MunicipioId);
            Assert.Equal(userDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto => Model
            cepDto.Numero = "";
            var cepModel = Mapper.Map<CepModel>(cepDto);
            Assert.Equal(cepModel.Id, cepDto.Id);
            Assert.Equal(cepModel.Cep, cepDto.Cep);
            Assert.Equal(cepModel.Logradouro, cepDto.Logradouro);
            Assert.Equal("S/N", cepDto.Numero);
            Assert.Equal(cepModel.MunicipioId, cepDto.MunicipioId);

            var userDtoCreate = Mapper.Map<CepDtoCreate>(cepModel);
            Assert.Equal(userDtoCreate.Cep, cepModel.Cep);
            Assert.Equal(userDtoCreate.Logradouro, cepModel.Logradouro);
            Assert.Equal(userDtoCreate.Numero, cepModel.Numero);
            Assert.Equal(userDtoCreate.MunicipioId, cepModel.MunicipioId);

            var userDtoUpdate = Mapper.Map<CepDtoUpdate>(cepModel);
            Assert.Equal(userDtoUpdate.Cep, cepModel.Cep);
            Assert.Equal(userDtoUpdate.Logradouro, cepModel.Logradouro);
            Assert.Equal(userDtoUpdate.Numero, cepModel.Numero);
            Assert.Equal(userDtoUpdate.MunicipioId, cepModel.MunicipioId);


        }
    }
}
