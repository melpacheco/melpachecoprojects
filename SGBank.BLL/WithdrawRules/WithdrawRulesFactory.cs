﻿using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawRules
{
    public class WithdrawRulesFactory 
    {
        public static IWithdraw Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Free:
                    return new FreeAccountWithdrawRule();
                case AccountType.Basic:
                    return new BasicAccountWithdrawlRule();
                default:
                    return new PremiumAccountWithdrawlRule();
            }

            throw new Exception("Account type is not supported!");


   
        }
    }
}
