using System;
using System.Collections.Generic;
using AccountContext.Shared.Entities;
using AccountContext.Domain.ValueObjects;
using Flunt.Validations;

namespace AccountContext.Domain.Entities
{
    public class Account : Entity
    {
        private List<Transfers> _transfer;
        private List<Payment> _payment;
        public Account(
            bool active, DateTime lastDate,
            Document document)
        {
            LastDate = lastDate;
            Active = true;
            Document = document;
            _transfer = new List<Transfers>();
            _payment = new List<Payment>();
        }

        public DateTime LastDate { get; private set; }
        public bool Active { get; private set; }
        public Document Document { get; private set; }

        public IReadOnlyCollection<Transfers> Transfer
        {
            get { return _transfer.ToArray(); }
        }
        public void MakeActive()
        {
            Active = true;
            LastDate = DateTime.Now;
        }
    }
}