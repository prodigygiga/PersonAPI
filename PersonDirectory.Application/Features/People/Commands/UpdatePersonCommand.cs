using AutoMapper;
using Domain.Core.Shared;
using MediatR;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;

namespace PersonDirectory.Application.Features.People.Commands
{
    public class UpdatePersonCommand : SetPersonDTO, IRequest
    {
        public int Id { get; set; }
    }
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UpdatePersonCommandHandler(IUnitOfWork uow, IMapper mapper) => (this.uow, this.mapper) = (uow, mapper);

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var personInDb = await uow.PersonRepository.GetPersonByIdAsync(request.Id);
            if (personInDb == null)
            {
                throw new DataNotFoundException("პიროვნება ვერ მოიძებნა!");
            }
            var gender = Enumeration.FromValue<Gender>(request.GenderId);
            personInDb.SetPersonInfo(
                request.FirstName,
                request.LastName,
                request.PrivateNumber,
                gender,
                request.BirthDate,
                request.CityId,
                null);

            //person.SetId(request.Id);

            personInDb.ModifiedDate = DateTime.Now;
            foreach (var phNum in personInDb.PhoneNumbers)
            {
                phNum.DeleteDate = DateTime.Now;
            }

            foreach (var phNum in request.PhoneNumbers)
            {
                personInDb.AddPhoneNumber(new PhoneNumber(phNum.Number, Enumeration.FromValue<PhoneNumberType>(phNum.NumberTypeId),personInDb.Id));
            }
            await uow.PersonRepository.Update(personInDb);
            await uow.SaveAsync();
            return Unit.Value;


        }
    }
}
