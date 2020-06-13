using FluentValidator;
using System;

namespace Academia.Store.Domain.BaseEntity
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
