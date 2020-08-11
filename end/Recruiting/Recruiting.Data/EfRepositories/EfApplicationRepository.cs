using Microsoft.EntityFrameworkCore;
using Recruiting.Data.Data;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories
{
    public class EfApplicationRepository : IEfApplicationRepository
    {
        private readonly RecruitingContext _context;

        public EfApplicationRepository(RecruitingContext context)
        {
            _context = context;
        }

        public async Task<EfApplication> AddAsync(EfApplication newApplication)
        {
            await _context.AddAsync(newApplication);
            return newApplication;
        }

        public async Task<IList<EfApplication>> GetApplicationListByJobReference(string jobReference)
        =>
            await _context.Applications
                            .Include(app => app.Applicant)
                            .Include(app => app.Job)
                            .Where(app => app.Job.Reference == jobReference)
                            .ToListAsync();
    }
}
