using System;

namespace TrincaChurrasco.Domain.Core.Repository
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
