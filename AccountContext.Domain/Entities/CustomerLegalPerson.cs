using System;
using System.Linq;
using System.Collections.Generic;
using AccountContext.Domain.Entities;
using AccountContext.Domain.ValueObjects;

namespace AccountContext.Domain.Entities
{

    public class CustomerLegalPerson : Customer
    {
        private List<Account> _account;

        public CustomerLegalPerson(string comercialRegister,
            Name name,
            Document document,
            Address address) : base(name, document, address)
        {
            ComercialRegister = comercialRegister;
            NameLP = name;
            DocumentLP = document;
            Addres = address;
        }

        public string ComercialRegister { get; set; }
        public Name NameLP { get; private set; }
        public Document DocumentLP { get; private set; }
        public Address Addres { get; private set; }
        public IReadOnlyCollection<Account> Account { get { return _account.ToArray(); } }
    }
}