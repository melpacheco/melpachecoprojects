using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Responses
{
    public class AccountWithdrawResponse : Response
    {
        public Account account { get; set; }
         public decimal OldBalance { get; set; }
       public  decimal Amount { get; set; }
    }
}
