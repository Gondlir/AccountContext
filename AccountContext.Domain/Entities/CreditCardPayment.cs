using System;
using System.Collections.Generic;
using AccountContext.Domain.ValueObjects;

namespace AccountContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardNumber,
            string lastTransactionNumber,
            string cardName,
            string number,
            DateTime paidDate,
            DateTime expireDate,
            decimal totalPaid, decimal total,
            Address addres) : base(number, paidDate, expireDate, totalPaid, total, addres)
        {
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
            CardName = cardName;
        }

        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
        public string CardName { get; private set; }

    }
}