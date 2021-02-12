using System;
using System.Collections.Generic;
using AccountContext.Domain.ValueObjects;
using AccountContext.Shared.Entities;
using Flunt.Validations;

namespace AccountContext.Domain.Entities
{
    ///BOLETO, CREDIT CARD
    public abstract class Payment : Entity
    {
        protected Payment(
            string number,
            DateTime paidDate,
            DateTime expireDate,
            decimal totalPaid,
            decimal total,
            Address addres)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            TotalPaid = totalPaid;
            Addres = addres;
            Total = total;
            AddNotifications(new Contract()
            .Requires()
            .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total não pode ser zero")
            .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor do pagamento"));

        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal TotalPaid { get; private set; }
        public decimal Total { get; private set; }
        public Address Addres { get; private set; }
    }

}