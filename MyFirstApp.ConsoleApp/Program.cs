using System;
using System.Linq;
using System.Runtime.InteropServices;

class MainClass
{
    public static void Main(string[] args)
    {

        string ShowColor(string _userName)
        {
            string userColor = "";

            Console.WriteLine("\n{0}, введи свой любимый цвет на английском: ", _userName);
            userColor = Console.ReadLine();
            userColor = userColor.ToLower();
            if (userColor == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0},твой любимый цвет: красный!", _userName);
            }
            else if (userColor == "green")
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0}, твой любимый цвет: зеленый!", _userName);
            }
            else if (userColor == "cyan")
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0}, твой любимый цвет: синий!", _userName);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Без понятия, что ты ввёл,{0}, я таких цветов еще не знаю, я маленькая программка :D", _userName);
            }
            return userColor;
        }

        (string name, int age) anketa;

        Console.Write("Введите имя: ");
        anketa.name = Console.ReadLine();
        Console.Write("Введите возраст с цифрами: ");
        anketa.age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ваше имя: {0}", anketa.name);
        Console.WriteLine("Ваш возраст: {0}", anketa.age);

        string[] favcolors = new string[3];
        for(int i = 0; i < 3; i++)
        {
            favcolors[i] = ShowColor(anketa.name);
        }
        Console.WriteLine("Итак, твои любимые цвета на инглише: ");
        foreach(string color in favcolors)
        {
            Console.WriteLine(color);
        }

        Console.ReadKey();
        
    }



}



