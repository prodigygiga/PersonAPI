﻿using Domain.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDirectory.Core.Domain.Aggregates.CityAggregate
{
    public class City:Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public City(string Name)
        {
            this.Name = Name;
        }
    }
}
