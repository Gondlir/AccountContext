using System;
using System.Linq;
using System.Collections.Generic;
using AccountContext.Domain.Entities;
using AccountContext.Domain.ValueObjects;
using Flunt.Validations;

namespace AccountContext.Domain.Entities
{
    public class CustomerPhisycalPerson : Customer
    {
        private IList<Account> _account;
        private IList<Transfers> _transfer;
        private IList<Payment> _payment;
        public CustomerPhisycalPerson(Account account,
            Name name,
            Document document,
            Address address
            ) : base(name, document, address)
        {
            Account = account;
            NamePP = name;
            DocumentPP = document;
            AddressPP = address;
            _account = new List<Account>();
            _transfer = new List<Transfers>();
            _payment = new List<Payment>();
        }

        public Name NamePP { get; private set; }
        public Document DocumentPP { get; private set; }
        public Address AddressPP { get; private set; }
        public Account Account { get; private set; }
        public IReadOnlyCollection<Account> Accounts { get { return _account.ToArray(); } }
        public IReadOnlyCollection<Transfers> Transfers { get { return _transfer.ToArray(); } }
        public IReadOnlyCollection<Payment> Payment { get { return _payment.ToArray(); } }

        public void AddAccount(Account bankAccount)
        {
            var hasAccount = false;
            foreach (var account in _account)
            {
                if (account.Active)
                    hasAccount = true;
            }
            if (hasAccount)
                AddNotification("Customer.Accounts", "Você já tem uma conta");

            AddNotifications(new Contract()
            .Requires()
            .IsFalse(hasAccount, "Account.Subscriptions", "Você já tem uma conta ativa")
            .AreEquals(0, bankAccount.Transfer.Count, "Account.Transfer", "Esta conta é inexistente")
        );
            //verificar se nao tiver pagamento não cria conta

            if (Valid)
                _account.Add(bankAccount);
        }
        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
            .IsGreaterThan(DateTime.Now, payment.PaidDate, "CustomerPhisycalPerson.Total", "A data do pagamento deve ser futura !"));
            if (_payment.Count != 0)
            {
                _payment.Add(payment);
                AddNotifications(new Contract().Requires().IsGreaterThan(0, payment.Total, "CustomerPhisycalPerson.Total", "Pagamento efetuado"));
            }
            else
            {
                AddNotifications(new Contract()
            .Requires().IsLowerOrEqualsThan(0, payment.Total, "CustomerPhisycalPerson.Total", "Pagamento não efetuado, valor deve ser maior que zero."));
            }
        }
        public void AddTransfer(Transfers transfer)
        {
            AddNotifications(new Contract()
            .IsGreaterThan(DateTime.Now, transfer.PaidDate, "CustomerPhisycalPerson.Payment", "A data do pagamento deve ser futura !"));
            if (_transfer.Count != 0)
            {
                _transfer.Add(transfer);
                AddNotifications(new Contract().Requires().IsGreaterThan(0, transfer.Paid, "CustomerPhisycalPerson.Payment", "Pagamento efetuado"));
            }
            else
            {
                AddNotifications(new Contract()
            .Requires().IsLowerOrEqualsThan(0, transfer.Paid, "CustomerPhisycalPerson.Payment", "Pagamento não efetuado, valor deve ser maior que zero."));
            }
            //validação do pagamento

        }
    }

}