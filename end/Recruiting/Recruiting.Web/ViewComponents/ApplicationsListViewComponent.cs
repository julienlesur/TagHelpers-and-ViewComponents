using Microsoft.AspNetCore.Mvc;
using Recruiting.BL.Models;
using Recruiting.BL.Services.Interfaces;
using Recruiting.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.Web.ViewComponents
{
    public class ApplicationsListViewComponent : ViewComponent
    {
        private readonly IApplicantService _applicantService;

        public ApplicationsListViewComponent(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        public async Task<IViewComponentResult> InvokeAsync(
            int applicantId)
        {
            IEnumerable<Application> applications = await _applicantService.GetApplicationsByIdApplicant(applicantId);

            ApplicationList applicationList = new ApplicationList
            {
                Applications = applications,
                ApplicantId = applicantId
            };

            return View(applicationList);
        }


    }
}
