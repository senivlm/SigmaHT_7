using System;

namespace SigmaHT_7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            TextChanger textChanger = new TextChanger();

            Console.WriteLine(textChanger.GetChangedText("I go to school?   I run to university, She go to school!"));
        }
    }
}
