using Academia.Store.Domain.Contexts.Entities;
using Academia.Store.Domain.Contexts.Queries.Customer;
using System;
using System.Collections.Generic;

namespace Academia.Store.Application.Repositories.Dapper
{
    public interface ICustomerRepository
    {
        //Comando
        void Save(Customer model, Guid? id);
        //Queries
        CustomerDocumentQuery GetByDocument(string cpf);
        IEnumerable<AllCustomersQuery> AllCustomersQuery();
    }
}
