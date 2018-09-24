using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using AC.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AC.Infrastruture.Repositories.Implementation
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {

        private readonly DataBaseContext _context;

        public AccountRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public Boolean AccountReceiveTransfer(Account accountSource, Account accountDestination)
        {
             return _context.Set<ChildrenAccounts>()
               .Where(c => c.ParentAccountId == accountSource.Id && c.ChildrenAccountId == accountDestination.Id)
               .AsNoTracking().Any();
            
        }

        public IEnumerable<Account> GetAllAccountsMaster()
        {
            return _context.Set<Account>()
                .Include(ac => ac.Person)
                .Include(ac => ac.Status)
                .Where(f => f.Master == true)
                .AsNoTracking().ToList();
        }

        public IEnumerable<Account> GetChildren(int AccountParentId)
        {
           return  _context.Set<ChildrenAccounts>()
                .Include(ac => ac.ChildrenAccount)
                .ThenInclude(ac => ac.Person)
                .Include(ac => ac.ChildrenAccount.Status)
                .Where(c => c.ParentAccountId == AccountParentId)
                .AsNoTracking().Select(v =>  new Account() {
                    Person = v.ChildrenAccount.Person,
                    Id = v.ChildrenAccount.Id,
                    Master = v.ChildrenAccount.Master,
                    Created = v.ChildrenAccount.Created,
                    Money = v.ChildrenAccount.Money,
                    Name = v.ChildrenAccount.Name,
                    Status = v.ChildrenAccount.Status,
                    PersonId = v.ChildrenAccount.PersonId,
                    StatusId = v.ChildrenAccount.StatusId
                }).ToList();

        }
    }
}
