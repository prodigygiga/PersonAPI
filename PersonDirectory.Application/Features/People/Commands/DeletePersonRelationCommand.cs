using AutoMapper;
using Domain.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Application.Interfaces.Contracts;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;

namespace PersonDirectory.Application.Features.People.Commands
{
    public class DeletePersonRelationCommand : IRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }


    }
    public class DeletePersonRelationCommandHandler : IRequestHandler<DeletePersonRelationCommand>
    {
        private readonly IUnitOfWork uow;

        public DeletePersonRelationCommandHandler(IUnitOfWork uow) => (this.uow) = (uow);

        public async Task<Unit> Handle(DeletePersonRelationCommand request, CancellationToken cancellationToken)
        {
            if (!await uow.PersonRepository.CheckAsync(x=>x.Id == request.PersonId && x.DeleteDate == null))
            {
                throw new DataNotFoundException("პიროვნება გადმოცემულ Id-ზე არ არსებობს");
            }else if (!await uow.PersonRepository.CheckAsync(x => x.Id == request.RelatedPersonId && x.DeleteDate == null))
            {
                throw new DataNotFoundException("დაკავშირებული პიროვნება გადმოცემულ Id-ზე არ არსებობს");
            }

            var personRelation = await uow.PersonRepository.GetRelationByPersonAndRelatedPersonIdAsync(request.PersonId, request.RelatedPersonId);
            if (personRelation == null)
            {
                throw new DataNotFoundException("კავშირი ვერ მოიძებნა!");
            }
            personRelation.DeleteDate = DateTime.Now;
            await uow.PersonRepository.DeleteRelation(personRelation);
            await uow.SaveAsync();

            return Unit.Value;


        }
    }
}
