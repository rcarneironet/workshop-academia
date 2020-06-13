using Academia.Store.Domain.BaseEntity;
using Academia.Store.Domain.Contexts.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Academia.Store.Domain.Contexts.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;
        public Customer(NameVo name, CpfVo cpf, EmailVo email, string phone)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public NameVo Name { get; private set; }
        public CpfVo Cpf { get; private set; }
        public EmailVo Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
