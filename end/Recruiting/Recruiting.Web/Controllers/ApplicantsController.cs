using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruiting.BL.Models;
using Recruiting.BL.Services.Interfaces;
using Recruiting.Web.Models.ViewModels;

namespace Recruiting.Web.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        public async Task<IActionResult> List(string jobReference)
        {
            IEnumerable<Applicant> applicants = await _applicantService.GetApplicantList(jobReference);
            
            return View(applicants);
        }

        public async Task<IActionResult> Details(int id)
        {
            Applicant applicant = await _applicantService.FindByIdAsync(id);
            if (Applicant.IsEmpty(applicant))
            {
                return RedirectToAction(nameof(ApplicantNotFound));
            }
            return View(new ApplicantDetails { Applicant = applicant, Message = (TempData["Message"] ?? "").ToString() });
        }


        public IActionResult Add()
        {
            return View("Edit", Applicant._EmptyApplicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("FirstName, LastName, Email, Adress1, Adress2, ZipCode, City, Country")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                var newApplicant = await _applicantService.AddAsync(applicant);
                TempData["Message"] = "The applicant has been succesfully added";
                return RedirectToAction(nameof(Details), new { id = newApplicant.ApplicantId });
            }
            return View("Edit", new { id = applicant.ApplicantId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var applicant = await _applicantService.FindByIdAsync(id);
            if (Applicant.IsEmpty(applicant))
            {
                return RedirectToAction(nameof(ApplicantNotFound));
            }

            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantId, FirstName, LastName, Email, Adress1, Adress2, ZipCode, City, Country")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                var updatedApplicant = await _applicantService.UpdateAsync(applicant);
                TempData["Message"] = "The applicant has been succesfully saved";
                return RedirectToAction(nameof(Details), new { id = updatedApplicant.ApplicantId });
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedApplicant = await _applicantService.DeleteAsync(id);
            if (Applicant.IsEmpty(deletedApplicant))
            {
                return RedirectToAction(nameof(ApplicantNotFound));
            }
            return RedirectToAction(nameof(List));
        }

        public IActionResult ApplicantNotFound()
        {
            return View();
        }
    }
}
