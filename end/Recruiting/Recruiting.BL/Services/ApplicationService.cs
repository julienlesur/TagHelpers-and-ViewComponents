using Microsoft.AspNetCore.Mvc.Rendering;
using Recruiting.BL.Mappers;
using Recruiting.BL.Models;
using Recruiting.BL.Services.Interfaces;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IEfApplicationRepository _efApplicationRepository;
        private readonly IEfJobRepository _efJobRepository;
        private readonly Func<IEnumerable<EfApplication>, IEnumerable<Application>> _mapApplicationListEntityToListDomain;

        public ApplicationService(IEfApplicationRepository efApplicationRepository, IEfJobRepository efJobRepository)
        {
            _efApplicationRepository = efApplicationRepository;
            _efJobRepository = efJobRepository;
            _mapApplicationListEntityToListDomain = ApplicationMapper.MapListEntityToListDomain;
        }

        public async Task<IEnumerable<Application>> GetApplicationsByIdApplicant(int applicantId)
        {
            var efApplications = await _efApplicationRepository.GetListByIdApplicant(applicantId);
            return _mapApplicationListEntityToListDomain(efApplications);
        }

        public async Task<IEnumerable<SelectListItem>> GetJobsWithoutApplication(int applicantId)
        {
            var idsJob = await _efApplicationRepository.GetListByIdApplicant(applicantId);
            var jobs = await _efJobRepository.GetJobsNotIn(idsJob.Select(j => j.JobId).ToList());

            return jobs
                    .Select(j => new SelectListItem(j.Title + " - " + j.Reference, j.Id.ToString()))
                    .ToList();
        }
    }
}
