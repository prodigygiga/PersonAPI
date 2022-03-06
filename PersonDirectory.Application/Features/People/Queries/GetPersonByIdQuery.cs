using AutoMapper;
using Domain.Core.Shared;
using MediatR;
using PersonDirectory.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.People.Queries
{
    public class GetPersonByIdQuery : IRequest<GetPersonDTO>
    {
        public int Id { get; set; }
    }
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, GetPersonDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPersonByIdQueryHandler(IUnitOfWork uow, IMapper mapper) => (this.uow, this.mapper) = (uow, mapper);
        public async Task<GetPersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await uow.PersonRepository.GetPersonByIdAsync(request.Id);
            var personDto = mapper.Map<GetPersonDTO>(person);
            return personDto;
        }
    }
}

