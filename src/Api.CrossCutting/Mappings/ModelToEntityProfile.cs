using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            #region User
            CreateMap<UserEntity, UserModel>().ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfEntity, UfModel>().ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioEntity, MunicipioModel>().ReverseMap();
            #endregion

            #region Uf
            CreateMap<CepEntity, CepModel>().ReverseMap();
            #endregion
        }
    }
}
