using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountContext.Domain.Entities;
using AccountContext.Domain.ValueObjects;
using AccountContext.Domain.Enums;

namespace DocumentTest.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Testar_Documento_CNPJ_Errado()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void Testar_Documento_CNPJ_Certo()
        {
            var doc = new Document("12345678911111", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }
        [TestMethod]
        public void Testar_Documento_CPF_Errado()
        {
            var doc = new Document("036", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void Testar_Documento_CPF_Certo()
        {
            var doc = new Document("03628166039", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}