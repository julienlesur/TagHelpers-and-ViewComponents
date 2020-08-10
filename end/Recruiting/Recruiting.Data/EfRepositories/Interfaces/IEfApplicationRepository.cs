using Recruiting.Data.EfModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recruiting.Data.EfRepositories.Interfaces
{
    public interface IEfApplicationRepository
    {
        public Task<IList<EfApplication>> GetApplicationListByJobReference(string jobReference);
    }
}
