using System;

namespace AHKCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter();
            interpreter.Interpret();
        }
    }
}
