using AutoMapper;
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

        public async Task<PersonDto> GetById(long id)
        {
            var person = await _unitOfWork.Persons.GetById(id);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<List<Person>> GetAll(string? cpf = null, string? cnpj = null)
        {
            var person = await _unitOfWork.Persons.GetAll(cpf, cnpj);
            return person == null ? new List<Person>() : person.ToList();
        }

        public async Task<PersonDto> Create(PersonDto personDto)
        {
            PersonValidator.ValidatePersonDto(personDto);

            Person person = _mapper.Map<Person>(personDto);

            if (personDto.Type == PersonType.PF)
            {
                PersonValidator.ValidatePersonPF(personDto.NaturalPerson!);
            }
            if (personDto.Type == PersonType.PJ)
            {
                PersonValidator.ValidatePersonPJ(personDto.PersonJuridical!);
            }
            if(!Enum.IsDefined(typeof(PersonType), personDto.Type))
                throw new ArgumentException("Invalid person type.");

            await _unitOfWork.Persons.Add(person);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PersonDto>(person);
        }

        public async Task Update(long id, PersonDto personDto)
        {
            Person personExist = await _unitOfWork.Persons.GetById(id);
            if (personExist == null)
            {
                throw new KeyNotFoundException("Person not found.");
            }

            PersonValidator.ValidatePersonDto(personDto);

            Person person = _mapper.Map<Person>(personDto);
            person.Id = id;

            if (personDto.Type == PersonType.PF)
            {
                PersonValidator.ValidatePersonPF(personDto.NaturalPerson!);
            }
            if (personDto.Type == PersonType.PJ)
            {
                PersonValidator.ValidatePersonPJ(personDto.PersonJuridical!);
            }
            if (!Enum.IsDefined(typeof(PersonType), personDto.Type))
                throw new ArgumentException("Tipo de Pessoas inválida");

            await _unitOfWork.Persons.Update(personExist, person);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            Person person = await _unitOfWork.Persons.GetById(id);
            if (person == null)
            {
                throw new KeyNotFoundException("Pessoa não encontrada");
            }

            await _unitOfWork.Persons.Delete(person);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
