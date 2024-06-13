using AutoMapper;
using System;
using WassamaraManagement.Domain;
using WassamaraManagement.Domain.Enums;
using WassamaraManagement.DTOs;
using WassamaraManagement.Repository.UnitOfWork;
using WassamaraManagement.Services.Interfaces;
using WassamaraManagement.Services.Validators;

namespace WassamaraManagement.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonDto> GetById(int id)
        {
            var person = await _unitOfWork.Persons.GetById(id);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> Create(PersonDto personDto)
        {
            PersonValidator.ValidatePersonDto(personDto);

            Person person = _mapper.Map<Person>(personDto);

            if (personDto.Type == PersonType.PF)
            {
                PersonValidator.ValidatePersonPF(personDto.NaturalPerson!);

                person.CPF = personDto.NaturalPerson.CPF;
                person.BirthDate = personDto.NaturalPerson.BirthDate;
                person.FullName = personDto.NaturalPerson.FullName;
            }
            if (personDto.Type == PersonType.PJ)
            {
                PersonValidator.ValidatePersonPJ(personDto.PersonJuridical!);

                person.CNPJ = personDto.PersonJuridical.CNPJ;
                person.TradingName = personDto.PersonJuridical.TradingName;
                person.CompanyName = personDto.PersonJuridical.CompanyName;
            }
            if(Enum.IsDefined(typeof(PersonType), personDto.Type))
                throw new ArgumentException("Invalid person type.");

            await _unitOfWork.Persons.Add(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDto>(person);
        }

        public async Task Update(int id, PersonDto personDto)
        {
            Person person = await _unitOfWork.Persons.GetById(id);
            if (person == null)
            {
                throw new KeyNotFoundException("Person not found.");
            }

            PersonValidator.ValidatePersonDto(personDto);

            person = _mapper.Map<Person>(personDto);

            if (personDto.Type == PersonType.PF)
            {
                PersonValidator.ValidatePersonPF(personDto.NaturalPerson!);

                person.CPF = personDto.NaturalPerson.CPF;
                person.BirthDate = personDto.NaturalPerson.BirthDate;
                person.FullName = personDto.NaturalPerson.FullName;
            }
            if (personDto.Type == PersonType.PJ)
            {
                PersonValidator.ValidatePersonPJ(personDto.PersonJuridical!);

                person.CNPJ = personDto.PersonJuridical.CNPJ;
                person.TradingName = personDto.PersonJuridical.TradingName;
                person.CompanyName = personDto.PersonJuridical.CompanyName;
            }
            if (Enum.IsDefined(typeof(PersonType), personDto.Type))
                throw new ArgumentException("Invalid person type.");

            await _unitOfWork.Persons.Update(id, person);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var person = await _unitOfWork.Persons.GetById(id);
            if (person == null)
            {
                throw new KeyNotFoundException("Person not found.");
            }

            await _unitOfWork.Persons.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
