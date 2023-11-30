using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotNet6.Application.DTOs;
using AutoMapper;

namespace Aula.ApiDotNet6.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
