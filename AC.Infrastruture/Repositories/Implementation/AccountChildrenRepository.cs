using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using AC.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Infrastruture.Repositories.Implementation
{
    public class AccountChildrenRepository : BaseRepository<ChildrenAccounts>, IAccountChildrenRepository
    {
        public AccountChildrenRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
