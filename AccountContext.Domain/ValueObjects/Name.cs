using AccountContext.Shared.ValueObjects;
using Flunt.Validations;

namespace AccountContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddNotifications(new Contract().Requires()
            .HasMinLen(FirstName, 3, "Name.FirstName", "Nome deve conter no mínimo 3 caracteres")
            .HasMinLen(LastName, 3, "Name.LastName", "Sobrenome deve conter no mínimo 3 caracteres")
            .HasMaxLen(FirstName, 20, "Name.FirstName", "Nome deve ter no máximo 20 caracteres")
            .HasMaxLen(LastName, 40, "Name.LastName", "Sobrenome deve ter no máximo 40 caracteres"));
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

    }
}