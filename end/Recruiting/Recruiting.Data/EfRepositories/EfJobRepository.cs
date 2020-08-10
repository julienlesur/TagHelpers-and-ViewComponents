using Microsoft.EntityFrameworkCore;
using Recruiting.Data.Data;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories
{
    public class EfJobRepository : EfRepositoryBase<EfJob>, IEfJobRepository
    {
        public EfJobRepository(RecruitingContext context) : base(context)
        {
        }

        public async Task<int> GetNumberOfApplicationsByJobReference(string jobReference)
        {
            var jobList = await _context.Applications
                            .Where(app => app.Job.Reference == jobReference)
                            .ToListAsync();
                            return jobList.Count();
        }

        public bool IsReferenceUnique(int jobId, string reference)
        {
            return !_dbSet.Any(job => job.Id != jobId && job.Reference == reference);
        }
    }
}
