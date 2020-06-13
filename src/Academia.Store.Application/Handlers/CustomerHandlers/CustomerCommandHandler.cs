using Academia.Store.Application.Repositories.Dapper;
using Academia.Store.Domain.Abstractions;
using Academia.Store.Domain.Contexts.Commands.Customer;
using Academia.Store.Domain.Contexts.Entities;
using Academia.Store.Domain.Contexts.ValueObjects;
using Academia.Store.Domain.Implementations;
using FluentValidator;
using System;

namespace Academia.Store.Application.Handlers.CustomerHandlers
{
    public class CustomerCommandHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository _repository;
        public CustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IResult Handle(CreateCustomerCommand command)
        {
            //transações de negócios, regras de negócio, comunicação com outros handlers            
            //Criacao dos objetos
            var name = new NameVo(command.Nome, command.Sobrenome);
            var cpf = new CpfVo(command.Documento);
            var email = new EmailVo(command.Email);
            var customer = new Customer(name, cpf, email, command.Telefone);

            //Validar
            AddNotifications(name.Notifications);
            AddNotifications(cpf.Notifications);
            AddNotifications(email.Notifications);

            if (Invalid)
            {
                return new ApiContract(false,
                    "Erro. Corrija os campos abaixo:",
                    Notifications);
            }

            try
            {
                _repository.Save(customer, null);
            }
            catch (Exception ex)
            {
                //TO-DO: implementa log depois
                throw new Exception("Erro - Handler CustomerCommandHandler" + ex.Message);
            }

            return new ApiContract(true, "Customer criado com sucesso!", null);

        }
    }
}
