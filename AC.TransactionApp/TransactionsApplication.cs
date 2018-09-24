using AC.Domain;
using AC.Enum;
using AC.Infrastruture.Repositories.Contracts;
using AC.SecurityContribution;
using AC.TransactionApp.DataTransferObject;
using System;
using System.Collections.Generic;

namespace AC.TransactionApp
{
    public class TransactionsApplication
    {
        readonly ITransactionsRepository _transactionRepository;
        readonly IAccountRepository _accountRepository;

        public TransactionsApplication(ITransactionsRepository transactionRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        public IEnumerable<Transactions> GetTransactionsDependences()
        {
            return _transactionRepository.GetTransactionsDependences();
        }

        public Transactions PostDeposit(TransactionsDepositDTO transactionsDTO)
        {
            
            Account accountDestination = _accountRepository.Get(new Object[] { transactionsDTO.AccountDestinationId });

            if (accountDestination == null || !accountDestination.Master)
            {
                throw new Exception("Aportes sao permitidos apenas para contas principais");
            }

            _transactionRepository.Begin();

            try
            {
                accountDestination.Money = accountDestination.Money + transactionsDTO.Money;
                _accountRepository.Save(accountDestination);

                Transactions transactions = new Transactions();
                transactions.AccountDestinationId = accountDestination.Id;
                transactions.Money = transactionsDTO.Money;
                transactions.TransactionCode = GeneratedCodeContribution.GetCode();
                transactions.TransactionTypeId = (int)TransactionsTypeEnum.DEPOSIT;
                transactions.Created = DateTime.Now;

                _transactionRepository.Save(transactions);
                
                _transactionRepository.Commit();

                return transactions;
            }
            catch (Exception ex)
            {
                _transactionRepository.RollBack();
                throw ex;
            }
        }

        public Transactions PostTransference(TransactionsTransferenceDTO transactionsDTO)
        {

            Account accountDestination = _accountRepository.Get(new Object[] { transactionsDTO.AccountDestinationId });

            Account accountSource = _accountRepository.Get(new Object[] { transactionsDTO.AccountSourceId });
            
            if (accountDestination == null || accountDestination.Master)
            {
                throw new Exception("Transferencias sao permitidas apenas para contas filhas!");
            }

            if (accountDestination ==  accountSource)
            {
                throw new Exception("Transferencias nao sao permitidas para a mesma conta!");
            }

            if (accountDestination.StatusId != (int)StatusEnum.ACTIVE || accountSource.StatusId != (int)StatusEnum.ACTIVE)
            {
                throw new Exception("Transferencias sao permitidas apenas entre contas ativas!");
            }
            
            Boolean AccountReceiveTransfer = _accountRepository.AccountReceiveTransfer(accountSource, accountDestination);

            if(AccountReceiveTransfer == false)
            {
                throw new Exception("A conta de destino nao esta abaixo da conta de origem, portanto a transferencia nao é permitida!");
            }

            _transactionRepository.Begin();

            try
            {
                accountSource.Money = accountSource.Money - transactionsDTO.Money;

                if (accountSource.Money < 0)
                {
                    throw new Exception("A conta de origem nao possui saldo para realizar a transferencia!");
                }

                _accountRepository.Save(accountSource);
                
                accountDestination.Money = accountDestination.Money + transactionsDTO.Money;

                _accountRepository.Save(accountDestination);

                Transactions transactions = new Transactions();
                transactions.AccountDestinationId = accountDestination.Id;
                transactions.AccountSourceId = accountSource.Id;
                transactions.Money = transactionsDTO.Money;
                transactions.TransactionCode = GeneratedCodeContribution.GetCode();
                transactions.TransactionTypeId = (int)TransactionsTypeEnum.TRANSFERENCE;
                transactions.Created = DateTime.Now;

                _transactionRepository.Save(transactions);

                _transactionRepository.Commit();

                return transactions;
            }
            catch(Exception ex)
            {
                _transactionRepository.RollBack();
                throw ex;
            }
        }

        public Transactions PostLoad(TransactionsLoadDTO transactionsDTO)
        {
            Account accountDestination = _accountRepository.Get(new Object[] { transactionsDTO.AccountDestinationId });

        
            if (accountDestination == null || accountDestination.Master)
            {
                throw new Exception("Cargas sao permitidas apenas para contas filhas!");
            }

            if (accountDestination.StatusId != (int)StatusEnum.ACTIVE)
            {
                throw new Exception("Cargas sao permitidas apenas para contas ativas!");
            }
            
            _transactionRepository.Begin();

            try
            {
                accountDestination.Money = accountDestination.Money + transactionsDTO.Money;
                _accountRepository.Save(accountDestination);

                Transactions transactions = new Transactions();
                transactions.AccountDestinationId = accountDestination.Id;
                transactions.Money = transactionsDTO.Money;
                transactions.TransactionCode = GeneratedCodeContribution.GetCode();
                transactions.TransactionTypeId = (int)TransactionsTypeEnum.LOAD;
                transactions.Created = DateTime.Now;

                _transactionRepository.Save(transactions);

                _transactionRepository.Commit();

                return transactions;
            }
            catch (Exception ex)
            {
                _transactionRepository.RollBack();
                throw ex;
            }
        }

        public Transactions PostReversal(TransactionsReversalDTO transactionsReversalDTO)
        {
            
            Transactions transactions = _transactionRepository.GetTransactionReversal(transactionsReversalDTO.TransactionId);
            
            if (transactions.AccountSource == null && transactions.AccountDestination.Master == true 
                && String.IsNullOrEmpty(transactionsReversalDTO.TransactionCode ))
            {
                throw new Exception("É necessario informar o codigo gerado na transacao para realizaar o estorno!");
            }

            if (transactions.Reversed == true)
            {
                throw new Exception("Essa transacao ja foi estornada!");
            }

            Account AccountDestination = transactions.AccountDestination;
            Account AccountSource = transactions.AccountSource;
            
            try
            {

                switch (transactions.TransactionTypeId)
                {
                    case (int)TransactionsTypeEnum.DEPOSIT:
                        return ReversalDeposit(transactions, transactionsReversalDTO);
                    case (int)TransactionsTypeEnum.LOAD:
                        return ReversalLoad(transactions, transactionsReversalDTO);
                    case (int)TransactionsTypeEnum.REVERSAL:
                        throw new Exception("Nao é possivel realizar esta operacao!");
                    case (int)TransactionsTypeEnum.TRANSFERENCE:
                        return ReversalTransference(transactions);
                }

                throw new Exception("Nao foi encontrada nenhum transacao para o codigo de transacao informado!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Transactions ReversalLoad(Transactions transactions, TransactionsReversalDTO transactionsReversalDTO)
        {

            Account AccountDestination = transactions.AccountDestination;
            Account AccountSource = transactions.AccountSource;

            _transactionRepository.Begin();

            try
            {

                AccountDestination.Money = AccountDestination.Money - transactions.Money;

                if (AccountDestination.Money < 0)
                {
                    throw new Exception("A transacao selecionada nao pode ser estornada,porque o valor ja foi utilizado!");
                }

                _accountRepository.Save(AccountDestination);

                Transactions transactionsReversal = new Transactions();
                transactionsReversal.AccountSourceId = AccountDestination.Id;
                transactionsReversal.Money = transactions.Money;
                transactionsReversal.TransactionCode = GeneratedCodeContribution.GetCode();
                transactionsReversal.TransactionTypeId = (int)TransactionsTypeEnum.REVERSAL;
                transactionsReversal.Created = DateTime.Now;

                _transactionRepository.Save(transactionsReversal);

                transactions.Reversed = true;
                _transactionRepository.Save(transactions);

                _transactionRepository.Commit();

                return transactionsReversal;

            }
            catch (Exception ex)
            {
                _transactionRepository.RollBack();
                throw ex;
            }
        }

        public Transactions ReversalTransference(Transactions transactions)
        {

            Account accountDestination = _accountRepository.Get(new Object[] { transactions.AccountDestinationId });

            Account accountSource = _accountRepository.Get(new Object[] { transactions.AccountSourceId });
            

            _transactionRepository.Begin();

            try
            {
                accountDestination.Money = accountDestination.Money - transactions.Money;

                if (accountDestination.Money < 0)
                {
                    throw new Exception("A conta de destino nao possui saldo para realizar o estorno!");
                }

                _accountRepository.Save(accountDestination);

                accountSource.Money = accountSource.Money + transactions.Money;

                _accountRepository.Save(accountDestination);

                Transactions transactionCreated = new Transactions();
                transactionCreated.AccountDestinationId = accountDestination.Id;
                transactionCreated.AccountSourceId = accountSource.Id;
                transactionCreated.Money = transactions.Money;
                transactionCreated.TransactionCode = GeneratedCodeContribution.GetCode();
                transactionCreated.TransactionTypeId = (int)TransactionsTypeEnum.REVERSAL;
                transactionCreated.Created = DateTime.Now;

                _transactionRepository.Save(transactionCreated);

                transactions.Reversed = true;
                _transactionRepository.Save(transactions);

                _transactionRepository.Commit();

                return transactions;
            }
            catch (Exception ex)
            {
                _transactionRepository.RollBack();
                throw ex;
            }
        }

        private Transactions ReversalDeposit(Transactions transactions , TransactionsReversalDTO transactionsReversalDTO)
        {

            Account AccountDestination = transactions.AccountDestination;
            Account AccountSource = transactions.AccountSource;

            _transactionRepository.Begin();

            try
            {
               
                if (transactions.TransactionCode != transactionsReversalDTO.TransactionCode)
                {
                    throw new Exception("O codigo informado é diferente do codigo registrado na transacao!");
                }

                AccountDestination.Money = AccountDestination.Money - transactions.Money;

                if (AccountDestination.Money < 0)
                {
                    throw new Exception("A transacao selecionada nao pode ser estornada,porque o valor ja foi utilizado!");
                }

                _accountRepository.Save(AccountDestination);

                Transactions transactionsReversal = new Transactions();
                transactionsReversal.AccountSourceId = AccountDestination.Id;
                transactionsReversal.Money = transactions.Money;
                transactionsReversal.TransactionCode = GeneratedCodeContribution.GetCode();
                transactionsReversal.TransactionTypeId = (int)TransactionsTypeEnum.REVERSAL;
                transactionsReversal.Created = DateTime.Now;

                _transactionRepository.Save(transactionsReversal);


                transactions.Reversed = true;
                _transactionRepository.Save(transactions);

                _transactionRepository.Commit();

                return transactionsReversal;
                
            }
            catch (Exception ex)
            {
                _transactionRepository.RollBack();
                throw ex;
            }
        }
    }
}
