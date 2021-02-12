using System;
using AccountContext.Domain.ValueObjects;

namespace AccountContext.Domain.Entities
{
    public class PixTransfer : Transfers
    {
        public PixTransfer(
            Name name,
            Document document,
            Email email,
            string phoneNumber,
            decimal? randomKey,
            string number,
            DateTime paidDate,
            DateTime expireDate,
            decimal paid) : base(paidDate, expireDate, paid, document)
        {
            Name = name;
            DocumentPix = document;
            Email = email;
            PhoneNumber = phoneNumber;
            RandomKey = randomKey;
        }

        public Name Name { get; private set; }
        public Document DocumentPix { get; private set; }
        public Email Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public decimal? RandomKey { get; private set; }
    }
}