using Microsoft.AspNetCore.Mvc.Rendering;
using Recruiting.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetApplicationsByIdApplicant(int applicantId);
        Task<IEnumerable<SelectListItem>> GetJobsWithoutApplication(int applicantId);
    }
}
