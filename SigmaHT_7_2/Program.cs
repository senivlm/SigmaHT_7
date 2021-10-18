using System;
using System.IO;

namespace SigmaHT_7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu;

            try
            {
                menu = new Menu(@"C:\Users\User\source\repos\SigmaHT_7\SigmaHT_7_2\Menu.txt",
                                @"C:\Users\User\source\repos\SigmaHT_7\SigmaHT_7_2\PriceTag.txt");
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                return;
            }
            catch(DirectoryNotFoundException dirException)
            {
                Console.WriteLine(dirException.Message);
                return;
            }
            
            Console.WriteLine(menu);
        }
    }
}
