
using AC.AccountsApp.DataTransferObject;
using AC.Domain;
using AC.Infrastruture.Repositories.Contracts;
using AC.PersonApp;
using AC.PersonApp.Contract;
using System;
using System.Collections.Generic;

namespace AC.AccountsApp
{
    public class AccountApplication
    {
        readonly IAccountRepository _accountRepository;
        readonly IAccountChildrenRepository _accountChildrenRepository;
        readonly IPersonApplication _personApplication;

        public AccountApplication(
            IAccountRepository accountRepository , IAccountChildrenRepository accountChildrenRepository, IPersonApplication personApplication)
        {
            _accountRepository = accountRepository;
            _accountChildrenRepository = accountChildrenRepository;
            _personApplication = personApplication;
        }

        public IEnumerable<Account> GetAll()
        {
            return _accountRepository.GetAsync().Result;
        }

        public IEnumerable<Account> GetAllAccountsMaster()
        {
            return _accountRepository.GetAllAccountsMaster();
        }

        public Account Created(AccountMasterDTO accountMaster)
        {
            _accountRepository.Begin();
            Account account = new Account();
            account.Created = DateTime.Now;
            account.Master = true;
            account.Money = accountMaster.Money;
            account.Name = accountMaster.Name;
            account.PersonId = accountMaster.PersonId;
            account.StatusId = accountMaster.StatusId;
            account = _accountRepository.Save(account);
            _accountRepository.Commit();
            return account;
        }

        public Account GetById(int accountId)
        {
            return _accountRepository.Get(new Object[] { accountId });
        }

        public Account PostFull(AccountFullDTO accountFull)
        {
            int PersonId = _personApplication.PostPersonPhysicaORPersonLegal(accountFull.PersonLegal, accountFull.PersonPhysical);
            
            try
            {
                
                if (accountFull.AccountParentId != null && accountFull.AccountParentId > 0)
                {
                    AccountChildrenDTO accountChildrenDTO = new AccountChildrenDTO();
                    accountChildrenDTO.AccountParentId = accountFull.AccountParentId.Value;
                    accountChildrenDTO.Money = accountFull.Money;
                    accountChildrenDTO.Name = accountFull.Name;
                    accountChildrenDTO.PersonId = PersonId;
                    accountChildrenDTO.StatusId = accountFull.StatusId;

                    Account account = CreatedChildren(accountChildrenDTO);
                    
                    return account;

                }
                else
                {
                    AccountMasterDTO accountMaster = new AccountMasterDTO();
                    accountMaster.Money = accountFull.Money;
                    accountMaster.Name = accountFull.Name;
                    accountMaster.PersonId = PersonId;
                    accountMaster.StatusId = accountFull.StatusId;

                    Account account = Created(accountMaster);

                    return account;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("O Cliente foi salvo com sucesso. Porem ocorreu um erro ao salvar a conta, selecione o cliente adicionado e cria a conta novamente!", ex.InnerException);
            }
            
        }

        public Account CreatedChildren(AccountChildrenDTO accountChildrenDTO)
        {

            _accountRepository.Begin();

            try
            {
                
                Account account = _accountRepository.Get(new Object[] { accountChildrenDTO.AccountParentId });

                if (account == null)
                {
                    throw new Exception("Conta pai informada nao existe");
                }

                Account accountChildren = new Account();
                accountChildren.Created = DateTime.Now;
                accountChildren.Master = false;
                accountChildren.Money = accountChildrenDTO.Money;
                accountChildren.Name = accountChildrenDTO.Name;
                accountChildren.PersonId = accountChildrenDTO.PersonId;
                accountChildren.StatusId = accountChildrenDTO.StatusId;

                accountChildren = _accountRepository.Save(accountChildren);

                ChildrenAccounts childrenAccounts = new ChildrenAccounts();
                childrenAccounts.ParentAccountId = account.Id;
                childrenAccounts.ChildrenAccountId = accountChildren.Id;

                childrenAccounts = _accountChildrenRepository.Save(childrenAccounts);

                _accountRepository.Commit();

                return accountChildren;
            }
            catch (Exception ex)
            {
                _accountRepository.RollBack();
                throw ex;
            }
        }

        public Account Updated(int id, AccountUpdated accountUpdated)
        {
            _accountRepository.Begin();

            try
            {

                Account account = _accountRepository.Get(new Object[] { id });

                account.Name = accountUpdated.Name;
                account.StatusId = accountUpdated.StatusId;

                _accountRepository.Save(account);

                _accountRepository.Commit();
                return account;
            }
            catch(Exception ex)
            {
                _accountRepository.RollBack();
                throw ex;
            }
        }
        

        public IEnumerable<Account> GetChildrenAccounts(int AccountParentId)
        {
            return _accountRepository.GetChildren(AccountParentId);
        }
    }
}
