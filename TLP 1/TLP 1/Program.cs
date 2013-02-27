using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp = "a[2] vd: d; 1;";
            AutomatLex a = new AutomatLex(temp);
            a.StartAutomat();
        }
    }
}
