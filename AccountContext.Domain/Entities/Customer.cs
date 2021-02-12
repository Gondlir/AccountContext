using System;
using System.Linq;
using System.Collections.Generic;
using AccountContext.Domain.Entities;
using AccountContext.Domain.ValueObjects;
using AccountContext.Shared.Entities;
using Flunt.Validations;

namespace AccountContext.Domain.Entities
{
    public abstract class Customer : Entity
    {
        protected Customer(Name name, Document document, Address address)
        {
            Name = name;
            Document = document;
            Address = address;
            AddNotifications(name, document, address);
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
    }

}