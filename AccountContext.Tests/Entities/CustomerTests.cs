using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountContext.Domain.Entities;
using AccountContext.Domain.ValueObjects;
using AccountContext.Domain.Enums;
using System;
namespace AccountContext.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly CustomerPhisycalPerson _pessoafisica;
        private readonly Account _account;
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        public CustomerTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("00000000000", EDocumentType.CPF);
            _email = new Email("batman@dc.com");
            _address = new Address("Rua Bat", "6969", "", "Caverna", "DC", "USA", "000000");
            _account = new Account(true, DateTime.Now, _document);
            _pessoafisica = new CustomerPhisycalPerson(_account, _name, _document, _address);
        }

        [TestMethod]
        public void Retornar_Erro_ContaJáCriada()
        {
            var payment = new TedTransfer(_name, _document, "100000", "5000", "120", "aa", "ss", DateTime.Now, DateTime.Now, 500m);

            _pessoafisica.AddTransfer(payment);

            _pessoafisica.AddAccount(_account);
            _pessoafisica.AddAccount(_account);
            Assert.IsTrue(_pessoafisica.Invalid);
            //Retornar Erro de conta já criada...
        }
        [TestMethod]
        public void Retornar_Erro_PagamentoNaoEfetuado()
        {
            _pessoafisica.AddAccount(_account);
            Assert.IsTrue(_pessoafisica.Invalid);
            //Pagamento não efetuado...
        }
        [TestMethod]
        public void Retornar_Certo_()
        {
            var payment = new TedTransfer(_name, _document, "100000", "5000", "120", "aa", "ss", DateTime.Now, DateTime.Now, 500m);
            _pessoafisica.AddTransfer(payment);
            _pessoafisica.AddAccount(_account);
            Assert.IsTrue(_pessoafisica.Valid);
        }
    }
}
