using AC.Domain;
using AC.Persistence.Repositories.Contracts;
using AC.SecurityContribution;
using System.Collections.Generic;

namespace AC.StatusApp
{
    public class StatusApplication
    {
        readonly IStatusRepository _statusRepository;

        public StatusApplication(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public IEnumerable<Status> GetAll()
        {

            var tes = GeneratedCodeContribution.GetCode();

            return _statusRepository.GetAsync().Result;
        }
    }
}
