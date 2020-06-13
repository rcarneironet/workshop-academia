using Academia.Store.Domain.Abstractions;
using FluentValidator;
using FluentValidator.Validation;

namespace Academia.Store.Domain.Contexts.Commands.Customer
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        bool ICommand.IsValid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(Nome, 3, "Nome", "O nome deve conter 3 chars")
                .HasMaxLen(Nome, 50, "Nome", "O nome deve conter 50 chars no maximo")
                .HasMinLen(Sobrenome, 3, "Sobrenome", "O Sobrenome deve conter 3 chars")
                .HasMaxLen(Sobrenome, 50, "Sobrenome", "O nome deve conter 50 chars no maximo")
                .HasMinLen(Documento, 3, "Documento", "O Documento deve conter 3 chars")
                .HasMaxLen(Documento, 50, "Documento", "O Documento deve conter 50 chars no maximo")
                .HasMinLen(Email, 3, "Email", "O Email deve conter 3 chars")
                .HasMaxLen(Email, 50, "Email", "O Email deve conter 50 chars no maximo")
                .IsEmail(Email, "Email", "O e-mail precisa ser válido")
                );
            return IsValid;
        }
    }
}
