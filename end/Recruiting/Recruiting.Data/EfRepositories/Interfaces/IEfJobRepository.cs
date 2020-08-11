using Recruiting.Data.EfModels;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories.Interfaces
{
    public interface IEfJobRepository : IEfRepositoryBase<EfJob>
    {        
        public Task<int> GetNumberOfApplicationsByJobReference(string jobReference);
        public bool IsReferenceUnique(int jobId, string reference);
        public Task<int> GetJobIdByReference(string jobReference);
    }
}
