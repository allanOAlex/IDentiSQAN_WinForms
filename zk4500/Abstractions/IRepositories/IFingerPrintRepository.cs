using System.Threading.Tasks;
using zk4500.Entities;
using zk4500.Shared.Requests;
using zk4500.Shared.Responses;

namespace zk4500.Abstractions.IRepositories
{
    public interface IFingerPrintRepository : IBaseRepository<FingerPrint>
    {
        Task<FingerPrint> Verify(FingerPrint fingerPrint);
    }
}
