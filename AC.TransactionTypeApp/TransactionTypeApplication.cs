using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using System;
using System.Collections.Generic;

namespace AC.TransactionTypeApp
{
    public class TransactionTypeApplication
    {

        readonly ITransactionTypeRepository _transactionTypeRepository;

        public TransactionTypeApplication(ITransactionTypeRepository transactionTypeRepository)
        {
            _transactionTypeRepository = transactionTypeRepository;
        }

        public IEnumerable<TransactionsType> GetAll()
        {
            return _transactionTypeRepository.GetAsync().Result;
        }
    }
}
