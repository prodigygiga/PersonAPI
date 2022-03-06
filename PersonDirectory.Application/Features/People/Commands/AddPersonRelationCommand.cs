using AutoMapper;
using Domain.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Exceptions;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Application.Interfaces.Contracts;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;

namespace PersonDirectory.Application.Features.People.Commands
{
    public class AddPersonRelationCommand : IRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int RelationTypeId { get; set; }


    }
    public class AddPersonRelationCommandHandler : IRequestHandler<AddPersonRelationCommand>
    {
        private readonly IUnitOfWork uow;

        public AddPersonRelationCommandHandler(IUnitOfWork uow) => (this.uow) = (uow);

        public async Task<Unit> Handle(AddPersonRelationCommand request, CancellationToken cancellationToken)
        {
            if (!await uow.PersonRepository.CheckAsync(x=>x.Id == request.PersonId ))
            {
                throw new DataNotFoundException("პიროვნება გადმოცემულ Id-ზე არ არსებობს");
            }else if (!await uow.PersonRepository.CheckAsync(x => x.Id == request.RelatedPersonId ))
            {
                throw new DataNotFoundException("დაკავშირებული პიროვნება გადმოცემულ Id-ზე არ არსებობს");
            }
            var relationType = Enumeration.FromValue<RelationType>(request.RelationTypeId);
            var personRelation = new PersonRelation(request.PersonId, request.RelatedPersonId, relationType);
            personRelation.CreateDate = DateTime.Now;
            await uow.PersonRepository.AddRelatedPerson(personRelation);
            await uow.SaveAsync();

            return Unit.Value;


        }
    }
}
