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

        public async Task<int> GetJobIdByReference(string jobReference)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(j => j.Reference == jobReference);
            if (job != null)
            {
                return job.Id;
            }
            return 0;
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
