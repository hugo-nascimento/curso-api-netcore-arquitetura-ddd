using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possível Mapear os Modelos de Uf")]
        public void E_Possivel_Mapear_os_Modelos_Uf()
        {
            var model = new UfModel
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.UsState(),
                Sigla = Faker.Address.UsState().Substring(1, 3),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<UfEntity>();
            for (var i = 0; i < 5; i++)
            {
                var item = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<UfEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.Sigla, model.Sigla);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var userDto = Mapper.Map<UfDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Nome, entity.Nome);
            Assert.Equal(userDto.Sigla, entity.Sigla);

            var listaDto = Mapper.Map<List<UfDto>>(listEntity);
            Assert.True(listaDto.Count() == listEntity.Count());
            for (var i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listEntity[i].Nome);
                Assert.Equal(listaDto[i].Sigla, listEntity[i].Sigla);

            }

            //Dto => Model
            var userModel = Mapper.Map<UfDto>(model);
            Assert.Equal(userModel.Id, model.Id);
            Assert.Equal(userModel.Nome, model.Nome);
            Assert.Equal(userModel.Sigla, model.Sigla);





        }
    }
}
