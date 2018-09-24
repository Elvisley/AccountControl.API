using AC.Domain;
using AC.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Infrastruture.Repositories.Contracts
{
    public interface IAccountRepository : IRepositoryGeneric<Account>
    {
        IEnumerable<Account> GetChildren(int AccountParentId);
        IEnumerable<Account> GetAllAccountsMaster();
        Boolean AccountReceiveTransfer(Account accountSource, Account accountDestination);
    }
}
