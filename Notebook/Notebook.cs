using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    internal class Notebook
    {
        DateTime dateTime;
        string Nameof;
        string Description;
        public  Notebook(string nameof,string descrition,DateTime date)
        {
            Nameof=nameof;
            Description=descrition;
            dateTime=date;
        }
    }
}
