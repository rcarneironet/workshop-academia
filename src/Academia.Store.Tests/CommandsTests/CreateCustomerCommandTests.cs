using Academia.Store.Domain.Contexts.Commands.Customer;
using Academia.Store.Domain.Contexts.Entities;
using Academia.Store.Domain.Contexts.ValueObjects;
using FluentValidator;
using NUnit.Framework;

namespace Academia.Store.Tests.CommandsTests
{
    public class CreateCustomerCommandTests : Notifiable
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateCustomerCommandTests_CreateOrder_ShouldBeValid()
        {
            var command = new CreateCustomerCommand();
            var name = new NameVo("Ray", "Carneiro");
            var cpf = new CpfVo("15366015006");
            var email = new EmailVo("contato@academiadotnet.com.br");
            var customer = new Customer(name, cpf, email, command.Telefone);

            //Validar
            AddNotifications(name.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);

            Assert.AreEqual(true, !Invalid);
        }

    }
}
