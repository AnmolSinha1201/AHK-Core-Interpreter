using System;

namespace AHKCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new Interpreter();
            interpreter.Interpret("#include, Stub.dll\nFunctions.Inner.Test2()\n#using, Functions\nInner.Test2()\nvar=zxc()\nzxc(){return 1}\nzxc.qwe=123\nzxc.asd(123)\nclass zxc{asd(varA){varZ=99}}\nasd(123, 456)\nasd(varA, varB=123, varC=789){var1=123\nvar2=456\nvar1=var2}");
        }
    }
}
