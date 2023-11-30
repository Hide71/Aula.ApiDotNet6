using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotNet6.Application.DTOs;
using AutoMapper;

namespace Aula.ApiDotNet6.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
