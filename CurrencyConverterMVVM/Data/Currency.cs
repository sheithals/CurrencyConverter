using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterMVVM.Data
{
    [Serializable]
    public class Currency
    {
        
        public string CurrencyName { get; set; }    
        public string CurrencySymbol { get; set; }       
        public string Id { get; set; }
    }
}
