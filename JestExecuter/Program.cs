using System;
using JestExecuter.jest;

namespace JestExecuter
{
    class Program
    {
        static void Main()
        {
            var test_1 = new Data_test().TestReadFile();
#if DEBUG
            Console.WriteLine("Jest Running");
            Console.Read();
#endif
        }
    }
}
