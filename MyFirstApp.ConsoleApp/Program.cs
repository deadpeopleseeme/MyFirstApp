using System;

class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Чтоб потренировать циклы и условия, я слил две программы в одну\n");
        Console.WriteLine("Введи 'color', чтоб поговорить о своих любимых цветах\nВведи 'sum', чтоб немного покалькулировать");
        Console.WriteLine("Ввод любых других значений просто закроет программу\n");
        string userChoice = Console.ReadLine();
        userChoice = userChoice.ToLower();
        if(userChoice == "color")
        {
            string userColor = "";
            do
            {
                Console.WriteLine("\nВведи свой любимый цвет на английском, или введи 'stop', чтоб выйти: ");
                userColor = Console.ReadLine();
                userColor = userColor.ToLower();
                if (userColor == "red")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Твой любимый цвет: красный!");
                }
                else if (userColor == "green")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Твой любимый цвет: зеленый!");
                }
                else if (userColor == "cyan")
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Твой любимый цвет: синий!");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Без понятия, что ты ввёл, я таких цветов еще не знаю, я маленькая программка :D");
                }
            }
            while (userColor != "stop");
        }
        else if(userChoice == "sum")
        {
            int sum = 0;
            int userNumber;
            Console.WriteLine("\nВводи любые целые положительные числа, и мы будем их складывать. Введи 0, чтоб закончить ввод и вывести на экран результат:\n ");
            do
            {
                Console.WriteLine("Введи число: ");
                userNumber = Convert.ToInt32(Console.ReadLine());
                if (userNumber > 0)
                {
                    sum += userNumber;
                    Console.WriteLine("ПРИБАВЛЕНО");
                }
                else if (userNumber < 0)
                {  
                    Console.WriteLine("ЭТО ОТРИЦАТЕЛЬНОЕ ЧИСЛО");
                }
            }
            while (userNumber != 0);
            Console.WriteLine("Всё посчитали, сумма: {0}", sum);
            Console.WriteLine("Нажми любую клавишу для выхода...");
            Console.ReadKey();
        }
        
 
        
        
    }

    

}



