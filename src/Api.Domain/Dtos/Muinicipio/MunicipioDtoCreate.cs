using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Dtos.Muinicipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome de município é obrigatório!")]
        [StringLength(60, ErrorMessage = "Nome de município deve ter no máximo {1} caracteres!")]
        public string Nome { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage ="Código do IBGE inválido")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é campo obrigatório!")]
        public Guid UfId { get; set; }
        
    }
}
