using Academia.Store.Domain.BaseEntity;
using Academia.Store.Domain.Contexts.Enums;
using System;

namespace Academia.Store.Domain.Contexts.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.UtcNow;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }

        public EDeliveryStatus Status { get; private set; }

        public void Send()
        {
            Status = EDeliveryStatus.Sent;
        }

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}
