using System;

namespace JestExecuter
{
    class Program
    {
        static void Main()
        {
#if DEBUG
            Console.WriteLine("Jest Running");
            Console.Read();
#endif
        }
    }
}
