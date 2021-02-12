using System;
using System.Collections.Generic;
using AccountContext.Domain.ValueObjects;

namespace AccountContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode,
            string boletoNumber,
            string number,
            DateTime paidDate,
            DateTime expireDate,
            decimal totalPaid, decimal total,
            Address addres) : base(number, paidDate, expireDate, totalPaid, total, addres)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }

    }
}