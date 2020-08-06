using Recruiting.Data.EfModels;

namespace Recruiting.Data.EfRepositories.Interfaces
{
    public interface IEfJobRepository : IEfRepositoryBase<EfJob>
    {        
        public int GetNumberOfApplicationsByJobId(int jobId);
        public bool IsReferenceUnique(int jobId, string reference);
    }
}
