using System;
using AccountContext.Domain.ValueObjects;
using AccountContext.Shared.Entities;

namespace AccountContext.Domain.Entities
{
    ///TED, DOC, PIX
    public abstract class Transfers : Entity
    {
        protected Transfers(
            DateTime paidDate,
            DateTime expireDate,
            decimal paid,
            Document document)
        {
            PaidDate = DateTime.Now;
            ExpireDate = DateTime.Now;
            Paid = paid;
            Document = document;
        }

        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Paid { get; private set; }
        public Document Document { get; private set; }

    }




}