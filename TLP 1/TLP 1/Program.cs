using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TLP_1
{
    class Program
    {      
        static void Main(string[] args)
        {
            StreamReader fileInput = new StreamReader(@"input.txt");
            string temp;
            int u = 0;
            Automat a = new Automat();

            while (true)
            {
                temp = (fileInput.ReadLine());

                if (temp != null)
                {
                    a.StartAutomat(temp);
                }
                else
                {
                    a.TableWrite();
                    a.CloseFile();
                    break;
                }
            }

            StreamReader fileOutput = new StreamReader(@"output.txt");

            while (true)
            {
                string s = fileOutput.ReadLine();

                if (s != null)
                {
                    temp = temp + " " + s;
                }
                else
                {
                    fileOutput.Close();
                    break;
                }
            }

            temp = temp.Substring(1);

            RPN r = new RPN(temp);

            r.StartRPN(ref u);
            r.CloseFile();
        }
    }
}
