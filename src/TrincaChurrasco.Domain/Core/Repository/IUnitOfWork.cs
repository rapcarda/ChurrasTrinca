using System.Threading.Tasks;

namespace TrincaChurrasco.Domain.Core.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
