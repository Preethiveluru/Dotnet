using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CalcDelegate
{
    internal class MergeDelegate
    {
        delegate string DelegateMerger(string s1, string s2);//declaring delegate  

        public class DelegateExample
        {
            static string MergedString = string.Empty;
            public static string FullName(string fn, string ln)
            {
                MergedString = $"{fn} {ln}";
                return MergedString;
            }
            public static string FullLocation(string state, string place)
            {
                MergedString = $"{place} is a city in {state} state";
                return MergedString;
            }
            public static string getFullString()
            {
                return MergedString;
            }
            public static void Main(string[] args)
            {
                DelegateMerger merger1 = new DelegateMerger(FullName);//instantiating delegate  
                DelegateMerger merger2 = new DelegateMerger(FullLocation);
                merger1("Preethi", "Velluru");//calling method using delegate  
                Console.WriteLine("After merger1 delegate, the string is: " + getFullString());
                merger2("Andhra", "Nellore");//calling method using delegate  
                Console.WriteLine("After merger2 delegate, the string is: " + getFullString());

            }
        }
    }
}
