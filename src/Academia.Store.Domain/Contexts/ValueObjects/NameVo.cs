using FluentValidator;
using FluentValidator.Validation;

namespace Academia.Store.Domain.Contexts.ValueObjects
{
    public class NameVo : Notifiable
    {
        public NameVo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "Firstname deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 20, "FirstName", "Firstname deve conter no máximo 20 caracteres")
                .HasMinLen(LastName, 3, "FirstName", "Firstname deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 20, "FirstName", "Firstname deve conter no máximo 20 caracteres")
                );

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

}
