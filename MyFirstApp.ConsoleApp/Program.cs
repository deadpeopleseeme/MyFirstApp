using System;

class MainClass
{
    public static void Main(string[] args)
    {

        const string MyName = "Val";

        Console.WriteLine(MyName);

        Console.WriteLine("\t Hello, world!");
        Console.WriteLine("\t I'm 34 y.o");
        Console.WriteLine("\t My name is \n {0}", MyName);
        Console.WriteLine("\u0040");
        Console.WriteLine("\x23");
        Console.ReadKey();

    }
}
