using Recruiting.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.BL.Services.Interfaces
{
    public interface IJobService : IServiceBase<Job>
    {
        public Task<IEnumerable<Job>> GetJobs();
        public bool IsReferenceUnique(int id, string reference);
    }
}
