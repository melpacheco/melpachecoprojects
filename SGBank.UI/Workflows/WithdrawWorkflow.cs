using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            AccountManager manager = AccountManagerFactory.Create();

            Console.Write("Enter your account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter your withdrawl amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = manager.Withdraw(accountNumber, amount);

            if (response.Success == true)
            {
                Console.WriteLine("Withdrawl Completed!");
                Console.WriteLine($"Account Number: {response.account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Withdrawn: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.account.Balance:c}");
                //the new balance logic works but the c is preventing it from appearing negative dollars.
            }

            else
            {
                Console.WriteLine("An error has occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }
}
