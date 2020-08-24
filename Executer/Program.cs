using StringFighter.StringExtractors;
using System;

namespace Executer
{
    class Program
    {
        static void Main(string[] args)
        {
        
            ChangingValueExtractor changingExtractor = new ChangingValueExtractor("tarafıerndan satılaktadır.  {} ");

            var result = changingExtractor.ExtractChangingValue("tarafından satılaktadır.  annenin amı ");

            Console.WriteLine("Hello World!");
        }
    }
}
