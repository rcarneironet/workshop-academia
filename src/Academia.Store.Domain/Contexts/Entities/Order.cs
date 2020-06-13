using Academia.Store.Domain.BaseEntity;
using Academia.Store.Domain.Contexts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academia.Store.Domain.Contexts.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _itens;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            CreationDate = DateTime.UtcNow;
            Status = EOrderStatus.Created;
            _itens = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreationDate { get; private set; }
        public EOrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Itens => _itens.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
    }
}
