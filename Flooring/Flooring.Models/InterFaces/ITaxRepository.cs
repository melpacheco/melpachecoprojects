using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.InterFaces
{
    public interface ITaxRepository  
    {
        Tax LoadTaxObject(string StateName);
        void SaveNewTax(Tax tax);
        List<Tax> TaxList();
    }
}
