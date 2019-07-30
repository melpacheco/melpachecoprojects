using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private static Account _account = new Account();

        public static string Create()
        {
            string path = @".\Accounts.txt";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("AccountNumber,Name,Balance,Type");
                writer.WriteLine("11111,Free Customer,100,F");
                writer.WriteLine("22222,Basic Customer,500,B");
                writer.WriteLine("33333,Premium Customer,1000,P");
            }

            return path;
        }

        public Account LoadAccount(string AccountNumber)
        {
            string path = Create();

            Account account = new Account();
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                for (int i = 1; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Split(',');

                    //Account account = new Account();
                    account.AccountNumber = columns[0];
                    account.Name = columns[1];
                    account.Balance = decimal.Parse(columns[2]);
                    string type = columns[3];
                    account.Type = accountType(type);

                }
            }

            
            else
            {
                Console.WriteLine("Could not find the file at {0}", path);
                return null;
            }

            return account;
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }

        public AccountType accountType(string type)
        {
            switch (type)
            {
                case "Free Customer":
                    return AccountType.Free;
                case "Basic Customer":
                    return AccountType.Basic;
                default:
                    return AccountType.Premium;
            }

        }
    }
}



