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


        public static List<Tax> taxList = new List<Tax>
        {
            new Tax {StateName = "Ohio", StateAbbreviation = "OH", TaxRate = 6.25M}
        };

        public Tax LoadTaxObject(string StateName)
        {
         
            var TaxObject = taxList.Where(p => p.StateName == StateName);

            return TaxObject.FirstOrDefault();
        }

        public void SaveTax(Tax tax)
        {
            taxList.Add(tax);
        }
    }
}
