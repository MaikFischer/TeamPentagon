using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditClicker
{
    public class Utils
    {
        private string version = "v1.2";
        private string title = "CreditClicker";

        public string getVersion()
        {
            return this.version;
        }
        public string getTitle()
        {
            return this.title;
        }
    }
}
