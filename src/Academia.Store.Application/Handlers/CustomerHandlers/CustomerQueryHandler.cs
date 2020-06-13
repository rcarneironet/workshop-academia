using Academia.Store.Application.Repositories.Dapper;
using Academia.Store.Domain.Abstractions;
using Academia.Store.Domain.Contexts.Queries.Customer;
using Academia.Store.Domain.Implementations;
using FluentValidator;
using System;

namespace Academia.Store.Application.Handlers.CustomerHandlers
{
    public class CustomerQueryHandler :
        Notifiable,
        IQueryHandler<CustomerDocumentQuery>,
        IQueryHandler<AllCustomersQuery>
    {
        private readonly ICustomerRepository _repository;
        public CustomerQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IResult Handle(CustomerDocumentQuery query)
        {
            throw new NotImplementedException();
        }

        public IResult Handle()
        {
            try
            {
                return new ApiContract(true, string.Empty, _repository.AllCustomersQuery());
            }
            catch (Exception ex)
            {
                //TO-DO: implementa log depois
                throw new Exception("Erro - Handler CustomerQueryHandler" + ex.Message);
            }
        }
    }
}
