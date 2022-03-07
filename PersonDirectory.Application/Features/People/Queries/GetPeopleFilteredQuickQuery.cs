using AutoMapper;
using MediatR;
using PersonDirectory.Application.Commons;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.DTOs.Filters;
using PersonDirectory.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.People.Queries
{
    public class GetPeopleFilteredQuickQuery :PersonFilter, IRequest<Pagination<GetPersonDTO>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
    public class GetPeopleFilteredQuickQueryHandler : IRequestHandler<GetPeopleFilteredQuickQuery, Pagination<GetPersonDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetPeopleFilteredQuickQueryHandler(IUnitOfWork uow, IMapper mapper) => (this.uow, this.mapper) = (uow, mapper);
        public async Task<Pagination<GetPersonDTO>> Handle(GetPeopleFilteredQuickQuery request, CancellationToken cancellationToken)
        {
            var people = await uow.PersonRepository.GetPeopleFilteredQuick(request,request.CurrentPage,request.PageSize);
            var mpdPeople = mapper.Map<Pagination<GetPersonDTO>>(people);

            return mpdPeople;
        }
    }
}
