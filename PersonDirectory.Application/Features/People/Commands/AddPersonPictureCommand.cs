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
    public class AddPersonPictureCommand : IRequest
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }

    }
    public class AddPersonPictureCommandHandler : IRequestHandler<AddPersonPictureCommand>
    {
        private readonly IUnitOfWork uow;
        private readonly IFileService fileService;

        public AddPersonPictureCommandHandler(IUnitOfWork uow, IFileService fileService) => (this.uow, this.fileService) = (uow, fileService);

        public async Task<Unit> Handle(AddPersonPictureCommand request, CancellationToken cancellationToken)
        {
            var personInDb = await uow.PersonRepository.GetPersonByIdAsync(request.PersonId);
            if (personInDb == null)
            {
                throw new DataNotFoundException("პიროვნება ვერ მოიძებნა!");
            }
            var uploadedFilePath = await fileService.SavePicture(request.File, request.File.FileName);
            personInDb.SetPicturePath(uploadedFilePath);
            await uow.PersonRepository.Update(personInDb);
            await uow.SaveAsync();

            return Unit.Value;


        }
    }
}
