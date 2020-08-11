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
        public static IEnumerable<Application> MapListEntityToListDomain(IEnumerable<EfApplication> entities)
        {
            ICollection<Application> applications = new List<Application>();
            foreach(var entity in entities)
            {
                applications.Add(MapEntityToDomain(entity));
            }
            return applications;
        }


    }
}
