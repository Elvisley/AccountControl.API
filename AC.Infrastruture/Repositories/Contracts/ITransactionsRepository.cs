using AC.Domain;
using AC.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AC.Infrastruture.Repositories.Contracts
{
    public interface ITransactionsRepository : IRepositoryGeneric<Transactions>
    {
        Transactions GetTransactionReversal(int transactionId);
        IEnumerable<Transactions> GetTransactionsDependences();
    }
}
