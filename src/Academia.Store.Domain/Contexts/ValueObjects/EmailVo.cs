using FluentValidator;
using FluentValidator.Validation;

namespace Academia.Store.Domain.Contexts.ValueObjects
{
    public class EmailVo : Notifiable
    {
        public EmailVo(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O e-mail é inválido"));
        }

        public string Address { get; private set; }
    }
}
