using Recruiting.BL.Models;
using Recruiting.Data.EfModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruiting.BL.Mappers
{
    public static class ApplicationMapper
    {
        public static Application MapEntityToDomain(EfApplication entity)
         => 
            entity == null ?
            Application._EmptyApplication : 
            new Application
            {
                ApplicantId = entity.ApplicantId,
                ApplicantFullName = ApplicantMapper.MapEntityToDomain(entity.Applicant).FulllName,
                JobReference = entity.Job.Reference,
                JobTitle = entity.Job.Title,
                ApplicationDate = entity.ApplicationDate
            };


    }
}
