using System;
using AccountContext.Domain.ValueObjects;

namespace AccountContext.Domain.Entities
{
    public class DocTransfer : Transfers
    {
        public DocTransfer(decimal maxValue,
            DateTime toPaidDate,
            Name name,
            Document document,
            string bank,
            string agency,
            string account,
            string typeOfAccount,
            string number,
            DateTime paidDate,
            DateTime expireDate,
            decimal paid) : base(paidDate, expireDate, paid, document)
        {
            MaxValue = maxValue;
            ToPaidDate = toPaidDate;
            Name = name;
            DocumentDoc = document;
            Bank = bank;
            Agency = agency;
            Account = account;
            TypeOfAccount = typeOfAccount;
        }

        public decimal MaxValue { get; private set; }
        public DateTime ToPaidDate { get; private set; }
        public Name Name { get; private set; }
        public Document DocumentDoc { get; private set; }
        public string Bank { get; private set; }
        public string Agency { get; private set; }
        public string Account { get; private set; }
        public string TypeOfAccount { get; private set; }
    }
}