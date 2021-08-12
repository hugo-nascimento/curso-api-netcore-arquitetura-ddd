using System;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Seeds
{
    public static class UfSeeds
    {
        public static void Ufs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UfEntity>().HasData(
                new UfEntity
                {
                    Id = new Guid("22a0bd4f-c522-4c60-97f0-16ca0e0d6acf"),
                    Sigla = "AC",
                    Nome = "Acre",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("2e21c8eb-cbaa-4235-98e8-ac3540276dc0"),
                    Sigla = "AL",
                    Nome = "Alagoas",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("7cb1b6c6-5e64-43f0-86fc-0a3b3e08432d"),
                    Sigla = "AP",
                    Nome = "Amapá",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("863f2e0d-2107-41c3-aa3f-57c647e8f400"),
                    Sigla = "AM",
                    Nome = "Amazonas",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("7fe87dfe-6362-4676-bfd0-95d072918585"),
                    Sigla = "BA",
                    Nome = "Bahia",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("8b0432f9-e794-4407-b8f3-d084eaa079f4"),
                    Sigla = "CE",
                    Nome = "Ceará",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("2c976982-9c2d-4479-b920-c5b2a07780f6"),
                    Sigla = "ES",
                    Nome = "Espírito Santo",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("9ac88f48-ca7b-4469-ae10-d1e8df5cf20b"),
                    Sigla = "GO",
                    Nome = "Goiás",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("8fbd96b4-d62a-41b4-9537-99de60723c92"),
                    Sigla = "MA",
                    Nome = "Maranhão",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("8b5a8424-700b-472c-a498-aed122a0924e"),
                    Sigla = "MT",
                    Nome = "Mato Grosso",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("909515cb-a35c-4477-b02a-5a0e16971fad"),
                    Sigla = "MS",
                    Nome = "Mato Grosso do Sul",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("8ff95a8b-60da-48ee-aee9-405e10de9488"),
                    Sigla = "MG",
                    Nome = "Minas Gerais",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("c3f8c57e-1132-4b48-a87f-d77782cbea02"),
                    Sigla = "PA",
                    Nome = "Pará",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("4a2f7aa7-bf01-42d9-b2e4-142483eaf3cc"),
                    Sigla = "PB",
                    Nome = "Paraíba",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("ec42a205-241e-459b-a3f1-da614e5a55cc"),
                    Sigla = "PR",
                    Nome = "Paraná",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("037527c0-19f4-4b15-9ba1-03cc88af3978"),
                    Sigla = "PE",
                    Nome = "Pernambuco",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("2c777073-9e1c-4a89-988c-e1c970a66571"),
                    Sigla = "PI",
                    Nome = "Piauí",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("b70610c8-1e91-4d86-b46d-b03b244db4c4"),
                    Sigla = "RJ",
                    Nome = "Rio de Janeiro",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("1254ea3a-35f2-4089-aedb-7aeaafffd307"),
                    Sigla = "RN",
                    Nome = "Rio Grande do Norte",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("7236af06-c7ae-4890-92f2-ea061cd24a0a"),
                    Sigla = "RS",
                    Nome = "Rio Grande do Sul",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("3540e439-94c0-44c1-aeb0-aef4f813f158"),
                    Sigla = "RO",
                    Nome = "Rondônia",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("101dce22-a876-406d-bfb7-8fdb2c708ca8"),
                    Sigla = "RR",
                    Nome = "Roraima",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("85266add-5a70-4024-a059-180ac6356051"),
                    Sigla = "SC",
                    Nome = "Santa Catarina",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("0a66e2bb-a0e0-497f-80a7-dd4181477ae6"),
                    Sigla = "SP",
                    Nome = "São Paulo",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("c7992b37-2dae-4684-a2c3-300e86755b70"),
                    Sigla = "SE",
                    Nome = "Sergipe",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("b19a38f4-58e5-4f8a-8c6e-b03d2b44b12d"),
                    Sigla = "TO",
                    Nome = "Tocantins",
                    CreateAt = DateTime.UtcNow
                },
                new UfEntity
                {
                    Id = new Guid("b1147acc-bab8-4263-91ec-6f85ebc907ff"),
                    Sigla = "DF",
                    Nome = "Distrito Federal",
                    CreateAt = DateTime.UtcNow
                }


            );
        }
        
        
        
    }
}
