using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawlRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if(account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "a non-premium account hit the Basic Withdraw Rule. Contact IT";
                return response;
            }

            if(amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawl amount must be negative!";
                return response;
            }

            response.Success = true;
            response.OldBalance = account.Balance;
            if (account.Balance + amount < -500)
            {
                account.Balance = account.Balance + amount - 10;
            }
            else
            {
                account.Balance += amount;
            }
            response.account = account;
            response.Amount = amount;
            return response;
        }
    }
}
