﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawlRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = "Error: a non basic account hit the basic withdraw rule. Contact IT";
                return response;
            }

            if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawl amounts must be negative!";
                return response;
            }

            if (amount < -500)
            {
                response.Success = false;
                response.Message = "Basic Accounts cannot withdraw more than $500";
                return response;
            }

            if (account.Balance + amount < -100)
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit!";
                return response;
            }

            response.OldBalance = account.Balance;
            if (account.Balance + amount < 0)
            {
                account.Balance = account.Balance + amount - 10;
            }
            else
            {
                account.Balance += amount;
            }
            response.account = account;
            response.Amount = amount;
            response.Success = true;
            return response;
        }
    }
}
