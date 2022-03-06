using Domain.Core.Shared;
using MediatR;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Features.Reports.Queries
{
    public class GetPeopleWIthRelatedTypesCountQuery : IRequest<IEnumerable<PersonReportWithRelationsCountDTO>>
    {
    }
    public class GetPeopleWIthRelatedTypesCountQueryHandler : IRequestHandler<GetPeopleWIthRelatedTypesCountQuery, IEnumerable<PersonReportWithRelationsCountDTO>>
    {
        private readonly IUnitOfWork uow;

        public GetPeopleWIthRelatedTypesCountQueryHandler(IUnitOfWork uow) => (this.uow) = (uow);
        public async Task<IEnumerable<PersonReportWithRelationsCountDTO>> Handle(GetPeopleWIthRelatedTypesCountQuery request, CancellationToken cancellationToken)
        {
            var result = await uow.PersonRepository.GetPersonReport();
           
            return result;
        }
    }
}
