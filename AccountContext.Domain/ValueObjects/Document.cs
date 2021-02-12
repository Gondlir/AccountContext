using AccountContext.Domain.Enums;
using AccountContext.Shared.ValueObjects;
using Flunt.Validations;

namespace AccountContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            DocumentNumber = number;
            DocumentType = type;
            AddNotifications(new Contract().Requires().IsTrue(DocumentIsValid(), "Document.DocumentNumber", "Documento Inválido"));
        }
        public string DocumentNumber { get; private set; }
        public EDocumentType DocumentType { get; private set; }

        private bool DocumentIsValid()
        {
            if (DocumentType == EDocumentType.CNPJ && DocumentNumber.Length >= 14)
                return true;

            if (DocumentType == EDocumentType.CPF && DocumentNumber.Length >= 11)
                return true;

            return false;
        }
    }
}