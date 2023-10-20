using System.Threading.Tasks;
using zk4500.Entities;

namespace zk4500.Abstractions.IRepositories
{
    public interface IFingerPrintRepository : IBaseRepository<FingerPrint>
    {
        Task<FingerPrint> Verify(FingerPrint fingerPrint);
    }
}
