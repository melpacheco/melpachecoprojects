using Flooring.Models;
using Flooring.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Data
{
   public class TestTaxRepository : ITaxRepository
    {


        public List<Tax> TaxList()
        {
            List<Tax> TaxList = new List<Tax>();

            TaxList.Add(new Tax { StateName = "Ohio", StateAbbreviation = "OH", TaxRate = 6.25M });

            return TaxList;
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
