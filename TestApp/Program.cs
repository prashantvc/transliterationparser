using System;
using Transliteration;

namespace TestApp
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var parser = new Parser();
            string result = parser.Translate("ಪ್ರs");

            Console.WriteLine(result);
        }
    }
}
