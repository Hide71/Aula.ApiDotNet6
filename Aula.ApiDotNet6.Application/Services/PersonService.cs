﻿using Aula.ApiDotnet6.Domain.Entities;
using Aula.ApiDotnet6.Domain.Repositories;
using Aula.ApiDotNet6.Application.DTOs;
using Aula.ApiDotNet6.Application.DTOs.Validations;
using Aula.ApiDotNet6.Application.Services.Interfaces;
using AutoMapper;

namespace Aula.ApiDotNet6.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

            var result = new PersonDTOValidator().Validate(personDTO);
            if (!result.IsValid)
            {
                return ResultService.RequestError<PersonDTO>("Problema de validade!", result);

            }

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));

        }

        public async Task <ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail("Pessoa não encontrada");
            await _personRepository.DeleteAsync(person);
            return ResultService.Ok($"Pessoa do Id:{id} foi deletada");
        }

        async Task<ResultService<ICollection<PersonDTO>>> IPersonService.GetAsync()
        {
            var people = await _personRepository.GetPeopleAsync();
            return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        async Task<ResultService<PersonDTO>> IPersonService.GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail<PersonDTO>("Pessoa não encontrada!");
            return ResultService.Ok(_mapper.Map<PersonDTO>(person));
        }

        public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new PersonDTOValidator().Validate(personDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema com a validação dos campos", validation);

            var person = await _personRepository.GetByIdAsync(personDTO.Id);

            if (person == null)
                return ResultService.Fail("Pessoa não encontrada");
            //var person = _mapper.Map<Person>(personDTO) ; Inserir
            person = _mapper.Map<PersonDTO, Person>(personDTO, person);// Edição
            await _personRepository.EditAsync(person);
            return ResultService.Ok("Pessoa Editada");
        }
    }
}
