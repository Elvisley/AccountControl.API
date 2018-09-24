using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using AC.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Infrastruture.Repositories.Implementation
{
    public class TransactionTypeRepository : BaseRepository<TransactionsType>, ITransactionTypeRepository
    {
        public TransactionTypeRepository(DataBaseContext context) : base(context)
        {

        }
    }
}
