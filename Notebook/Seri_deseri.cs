using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    internal class Seri_deseri
    {
        public static void MySeri<T>(T date, string filename)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(date);
            File.WriteAllText(desktop + "\\" + filename, json);
        }
        public static T Mydeserial<T>(string filename)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "\\" + filename);
            T date = JsonConvert.DeserializeObject<T>(json);
            return date;
        }
    }
}
