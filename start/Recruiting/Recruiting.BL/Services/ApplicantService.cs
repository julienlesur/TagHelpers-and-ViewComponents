using Recruiting.BL.Mappers;
using Recruiting.BL.Models;
using Recruiting.BL.Services.Interfaces;
using Recruiting.Data.EfModels;
using Recruiting.Data.EfRepositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.BL.Services
{
    public class ApplicantService : ServiceBase<Applicant, EfApplicant>, IApplicantService
    {
        private readonly IEfApplicantRepository _efApplicantRepository;
        private readonly Func<IEnumerable<EfApplicant>, IList<Applicant>> _mapListEntityToListDomain;
        private readonly Func<EfApplication, Application> _mapApplicationEntityToDomain;

        public ApplicantService(IEfApplicantRepository efApplicantRepository,
                                    IEfUnitRepository efUnitRepository)
            : base(efApplicantRepository, efUnitRepository, ApplicantMapper.MapDomainToEntity, ApplicantMapper.MapEntityToDomain)
        {
            _efApplicantRepository = efApplicantRepository;
            _mapListEntityToListDomain = ApplicantMapper.MapListEntityToListDomain;
            _mapApplicationEntityToDomain = ApplicationMapper.MapEntityToDomain;
        }

        public async Task<IList<Applicant>> DomainListAsync()
        {
            IEnumerable<EfApplicant> efApplicants = await _efApplicantRepository.ListAsync();
            return _mapListEntityToListDomain(efApplicants);
        }
        public async Task<Application> GetApplicantLastApplication(int applicantId)
        {
            var efLastApplication = await _efApplicantRepository.GetLastApplicationByApplicantId(applicantId);
            return _mapApplicationEntityToDomain(efLastApplication);
        }

        public async Task<IEnumerable<Applicant>> GetApplicantListWithLastApplication()
        {
            var applicants = await DomainListAsync();
            foreach (var applicant in applicants)
            {
                var lastApplication = await GetApplicantLastApplication(applicant.ApplicantId);
                applicant.DisplayApplicationTitle = lastApplication.JobTitleAndRef;
            }
            return applicants;
        }
    }
}
