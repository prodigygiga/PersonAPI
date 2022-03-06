using Domain.Core.Shared;
using PersonDirectory.Core.Domain.Aggregates.CityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Application.Interfaces
{
    public interface ICityRepository:IRepository<City>
    {
    }
}
