using AutoMapper;
using Domain.Core.Shared;
using MediatR;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;

namespace PersonDirectory.Application.Features.People.Commands
{
    public class AddPersonCommand : SetPersonDTO, IRequest
    {
    }
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddPersonCommandHandler(IUnitOfWork uow, IMapper mapper) => (this.uow, this.mapper) = (uow, mapper);

        public async Task<Unit> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var gender = Enumeration.FromValue<Gender>(request.GenderId);
            var person = new Person(
                request.FirstName,
                request.LastName,
                request.PrivateNumber,
                gender,
                request.BirthDate,
                request.CityId,
                null);
            person.CreateDate = DateTime.Now;
            foreach(var phNum in request.PhoneNumbers)
            {
                person.AddPhoneNumber(new PhoneNumber(phNum.Number, Enumeration.FromValue<PhoneNumberType>(phNum.NumberTypeId),person.Id));
            }
            await uow.PersonRepository.Create(person);
            await uow.SaveAsync();
            return Unit.Value;


        }
    }
}
