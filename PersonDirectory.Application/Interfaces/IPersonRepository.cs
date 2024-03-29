﻿using Domain.Core.Shared;
using PersonDirectory.Application.Commons;
using PersonDirectory.Application.DTOs;
using PersonDirectory.Application.DTOs.Filters;
using PersonDirectory.Core.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Interfaces
{
    public interface IPersonRepository:IRepository<Person>
    {
        public Task<Person> GetPersonByIdAsync(int id);
        public Task<PersonRelation> GetRelationByPersonAndRelatedPersonIdAsync(int personId, int relatedPersonId);
        public Task AddRelatedPerson(PersonRelation relation);
        public Task DeleteRelation(PersonRelation relation);
        public Task<List<PersonReportWithRelationsCountDTO>> GetPersonReport();
        public Task<Pagination<Person>> GetPeopleFiltered(PersonFilter personFilter,int currentPage, int pageSize);
        public Task<Pagination<Person>> GetPeopleFilteredQuick(PersonFilter personFilter, int currentPage, int pageSize);

    }
}
