using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class test
    {
        public static void Foo()
        {
            InsertToAccess insert = new InsertToAccess();
            List<string> categories = new List<string>
            {
                "Artificial intelligence"
            };
            //insert.InsertLemma(@"C:\Users\Ceyx\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\Database\Artificial intelligence\Artificial intelligence(new)", categories);
        }
    }
}
