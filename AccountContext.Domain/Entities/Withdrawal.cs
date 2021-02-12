using AccountContext.Domain.ValueObjects;

namespace AccountContext.Domain.Entities
{

    public class Withdrawal
    {
        public Withdrawal(Document document, string cardPasword)
        {
            Document = document;
            CardPasword = cardPasword;
        }

        public Document Document { get; private set; }
        public string CardPasword { get; private set; }

    }
}