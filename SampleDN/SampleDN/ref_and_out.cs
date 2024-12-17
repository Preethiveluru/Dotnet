using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SampleDN
{
    internal class ref_and_out
    {
        public const int c = 15;
        public void Add(ref int a,out int b)
        {
          b= c + 5;
          
        }
       
        
       

        static void Main(string[] args)
        {
            int number = 5;
            int result;
            ref_and_out add = new ref_and_out();
            add.Add(ref  number, out  result);
            Console.WriteLine($"number: {number}, result: {result}");
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Green;
            // Console.ResetColor();
            Console.Title="preethi";

        }

            

            


    }
}
