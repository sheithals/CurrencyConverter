using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterMVVM.Helpers
{
    public static class RequestHelpers
    {
        private static string _UserFileName = "settings.xml";
        public static string GetXmlFilePath()
        {
            var strCurrentDirectory = Environment.CurrentDirectory;
            var strWorkPath1 = Path.GetDirectoryName(strCurrentDirectory);
            var strWorkPath2 = Path.GetDirectoryName(strWorkPath1);

            var strSettingsXmlFilePath = strWorkPath2 + @"\Settings\" + _UserFileName;
           
            return strSettingsXmlFilePath;
        }
    }
}
