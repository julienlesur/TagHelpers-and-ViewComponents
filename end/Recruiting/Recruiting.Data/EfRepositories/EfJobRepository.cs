using Recruiting.Data.Data;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System.Linq;

namespace Recruiting.Data.EfRepositories
{
    public class EfJobRepository : EfRepositoryBase<EfJob>, IEfJobRepository
    {
        public EfJobRepository(RecruitingContext context) : base(context)
        {
        }

        public  int GetNumberOfApplicationsByJobId(int jobId)
        {
            return _context.Applications
                            .Where(app => app.JobId == jobId)
                            .Count();
        }

        public bool IsReferenceUnique(int jobId, string reference)
        {
            return !_dbSet.Any(job => job.Id != jobId && job.Reference == reference);
        }
    }
}
