using Flooring.Models;
using Flooring.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
    public class ProdTaxRepository : ITaxRepository
    {

        public List<Tax> TaxList()
        {
            string path = @"C:\Users\MelPacheco\Documents\SoftWareGuildAssignments\melissa-pacheco-individual-work\online-net-melpacheco\Flooring\FlooringOrders\Taxes.txt";

            List<Tax> newTaxList = new List<Tax>();

            if (File.Exists(path))
            {
               
                string[] rows = File.ReadAllLines(path);

                for (int i = 1; i < rows.Length; i++)
                {
                    Tax tax = new Tax();
                    string[] columns = rows[i].Split(',');
                    tax.StateAbbreviation = columns[0];
                    tax.StateName = columns[1];
                    tax.TaxRate = decimal.Parse(columns[2]);

                    newTaxList.Add(tax);
                }

                return newTaxList;
            }

            else
            {
                return null;
            }
        }
        public Tax LoadTaxObject(string StateName)
        {
            List<Tax> newTaxList = new List<Tax>();
            newTaxList = TaxList();
            foreach (var x in newTaxList)
            {
                if (x.StateName.ToLower() == StateName.ToLower())
                {
                    return x;
                }

            }
            return null;
        }

        public void SaveNewTax(Tax tax)
        {
            TaxList().Add(tax);
        }
    }
}
