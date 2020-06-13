using Academia.Store.Application.Repositories.Dapper;
using Academia.Store.Domain.Contexts.Entities;
using Academia.Store.Domain.Contexts.Queries.Customer;
using Academia.Store.Infrastructure.DataAccess.Dapper.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academia.Store.Infrastructure.DataAccess.Dapper.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomerRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<AllCustomersQuery> AllCustomersQuery() =>
            _context
            .Connection
            .Query<AllCustomersQuery>("SELECT Nome, Documento, Email, Telefone FROM dbo.Cliente");

        public CustomerDocumentQuery GetByDocument(string cpf) => _context
            .Connection
            .Query<CustomerDocumentQuery>("Select Documento FROM dbo.Cliente Where Documento = @Cpf", param: new { Cpf = cpf })
            .FirstOrDefault();

        public void Save(Customer model, Guid? id)
        {

            if (id.HasValue) //update
            {
                _context.Connection.ExecuteScalar(
                    "UPDATE Cliente Set Nome = @Nome, Documento = @Documento, Email = @Email, Telefone = @Telefone Where Id = @Id",
                    param: new { Id = id.Value.ToString().ToUpper(), Nome = model.Name.ToString(), Documento = model.Cpf.Number, Email = model.Email.Address, Telefone = model.Phone });
            }
            else
            {
                _context.Connection.ExecuteScalar(
                    "INSERT INTO Cliente (Id, Nome, Documento, Email, Telefone) VALUES (NEWID(), @Nome, @Documento, @Email, @Telefone);",
                    param: new { Nome = model.Name.ToString(), Documento = model.Cpf.Number, Email = model.Email.Address, Telefone = model.Phone });
            }
        }
    }
}
