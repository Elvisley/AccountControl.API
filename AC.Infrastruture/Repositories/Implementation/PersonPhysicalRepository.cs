using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using AC.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Infrastruture.Repositories.Implementation
{
    public class PersonPhysicalRepository : BaseRepository<PersonPhysical>, IPersonPhysicalRepository
    {
        public PersonPhysicalRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
