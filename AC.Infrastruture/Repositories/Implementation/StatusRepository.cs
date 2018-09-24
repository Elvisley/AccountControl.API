using AC.Domain;
using AC.Persistence.Repositories.Contracts;
using AC.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Persistence.Repositories.Implementation
{
    public class StatusRepository : BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
