using AutoMapper;
using Domain.Core.Shared;
using MediatR;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;

namespace PersonDirectory.Application.Features.People.Commands
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public DeletePersonCommandHandler(IUnitOfWork uow, IMapper mapper) => (this.uow, this.mapper) = (uow, mapper);

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var personInDb = await uow.PersonRepository.GetPersonByIdAsync(request.Id);
            if (personInDb == null)
            {
                throw new DataNotFoundException("პიროვნება ვერ მოიძებნა!");
            }

            cancellationToken.ThrowIfCancellationRequested();

            personInDb.DeleteDate = DateTime.Now;
            foreach (var phNum in personInDb.PhoneNumbers)
            {
                phNum.DeleteDate = DateTime.Now;
            }

            await uow.PersonRepository.Update(personInDb);
            await uow.SaveAsync();
            return Unit.Value;


        }
    }
}
