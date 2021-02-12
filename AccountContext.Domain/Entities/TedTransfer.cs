using System;
using AccountContext.Domain.ValueObjects;

namespace AccountContext.Domain.Entities
{
    public class TedTransfer : Transfers
    {
        public TedTransfer(
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
            Name = name;
            DocumentTed = document;
            Bank = bank;
            Agency = agency;
            Account = account;
            TypeOfAccount = typeOfAccount;
        }

        public Name Name { get; private set; }
        public Document DocumentTed { get; private set; }
        public string Bank { get; private set; }
        public string Agency { get; private set; }
        public string Account { get; private set; }
        public string TypeOfAccount { get; private set; }
    }
}