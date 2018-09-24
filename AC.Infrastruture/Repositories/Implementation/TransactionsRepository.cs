using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using AC.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.Infrastruture.Repositories.Implementation
{
    public class TransactionsRepository : BaseRepository<Transactions>, ITransactionsRepository
    {

        private readonly DataBaseContext _context;

        public TransactionsRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public Transactions GetTransactionReversal(int transactionId)
        {
            return _context.Set<Transactions>()
                .Include(ac => ac.AccountDestination)
                .ThenInclude(ac => ac.Person)
                .Include(ac => ac.AccountSource)
                .ThenInclude(ac => ac.Person)
                .Where(c => c.Id == transactionId).FirstOrDefault();
            
        }

        public IEnumerable<Transactions> GetTransactionsDependences()
        {
            return _context.Set<Transactions>()
               .Include(ac => ac.AccountDestination)
               .ThenInclude(ac => ac.Person)
               .Include(ac => ac.AccountSource)
               .ThenInclude(ac => ac.Person)
               .Include(ac => ac.TransactionType).OrderByDescending(c => c.Created)
               .ToList();
        }
    }
}
