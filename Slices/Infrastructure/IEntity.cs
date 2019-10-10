using System;
using System.Collections.Generic;
using MediatR;

namespace NeoFindR.Domain
{
    public interface IEntity
    {
        Queue<INotification> DomainEvents { get; }
    }
    
    public class Entity : Entity<Guid>
    {
        protected Entity() { }
    }

    public class Entity<TId> : IEquatable<Entity<TId>>, IEntity
    {
        private readonly Queue<INotification> _notifications = new Queue<INotification>();
        public Queue<INotification> DomainEvents => _notifications;

        public void ClearEvents()
        {
            _notifications.Clear();
        }

        // EF requires an empty constructor
        protected Entity()
        {
        }

        private TId _id;

        public TId Id
        {
            get => _id;
            protected set
            {
                _id = value;
            }
        }

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
            {
                throw new ArgumentException("The ID cannot be the medType's default value.", "id");
            }

            this.Id = id;
        }

        public bool Equals(Entity<TId> other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id);
        }

        public override bool Equals(object other)
        {
            if (other is Entity<TId> entity)
            {
                return this.Equals(entity);
            }
            return base.Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}