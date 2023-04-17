using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Xml.Linq;

class Program
{   
    //метод для проверки данных. необязательный параметр, по сути нужен только в вопросе с домашними питомцами, да-нет, поэтому по дефолту false
    static dynamic CheckingUserInput(bool doWeExpectInt, bool isYesOrNoQuestion = false)
    {
        string stringFromInput;
        int convertedNumberFromInput;
        bool isUserInputCorrect = true;
        string errorMessage = "";
        do
        {
            if (isUserInputCorrect == false)
            {
                Console.WriteLine(errorMessage);
            }
            stringFromInput = Console.ReadLine();
            bool isNumber = int.TryParse(stringFromInput, out convertedNumberFromInput);
            if (isYesOrNoQuestion)
            {
                stringFromInput = stringFromInput.ToLower(); //иначе на вопросе да-нет юзер введет ДА или Да или нЕт или нЕТ и тд, и результат будет неверный
            }

            if (doWeExpectInt != isNumber)
            {
                if (doWeExpectInt)
                {
                    errorMessage = "Нужно ввести число! ";
                }
                else
                {
                    errorMessage = "Подойдут только буквы! ";
                }
                isUserInputCorrect = false;
            }
            else if (doWeExpectInt == true && isNumber == true && convertedNumberFromInput <= 0)
            {
                errorMessage = "Число не может быть меньше нуля! ";
                isUserInputCorrect = false;
            }
            else if (doWeExpectInt == true && isNumber == true && convertedNumberFromInput > 10)
            {
                errorMessage = "Ну не надо больше 10, устанешь вводить-то. "; //ограничение чтоб не перезапускать программу, когда ввел 131723103 питомцев или цветов :D
                isUserInputCorrect = false;
            }
            else if (doWeExpectInt == false && isNumber == false && isYesOrNoQuestion == true && stringFromInput != "да" && stringFromInput != "нет")
            {
                errorMessage = "Только 'да' или 'нет'! ";
                isUserInputCorrect = false;
            }
            else
            {
                isUserInputCorrect = true;
            }
        } while (isUserInputCorrect == false);
        if (doWeExpectInt)
        {
            return convertedNumberFromInput;
        }
        else
        {
            return stringFromInput;
        }
    }

    //метод, который заполняет объявленный в теле программы кортеж
    static (string, string, bool, int, string[], int, string[]) FillingUserDataTuple()
    {

        Console.WriteLine("Введите имя пользователя: ");
        var name = CheckingUserInput(false);

        Console.WriteLine("Введите фамилию пользователя: ");
        var surname = CheckingUserInput(false);

        Console.WriteLine("Есть ли у вас питомцы? Введите 'да', если есть, и 'нет', если нет: ");
        string petYesNoQuestion = CheckingUserInput(false, true);

        bool hasPet;
        if (petYesNoQuestion == "да")
        {
            hasPet = true;
        }
        else
        {
            hasPet = false;
        }

        int petsQuantity = 0;
        string[] petsNames = new string[petsQuantity];
        if (hasPet == true)
        {
            Console.WriteLine("введите количество питомцев: ");
            petsQuantity = CheckingUserInput(true);
            Array.Resize(ref petsNames, petsQuantity);
            for (int i = 0; i < petsQuantity; i++)
            {
                Console.WriteLine("Введите кличку питомца номер {0}", i + 1);
                petsNames[i] = CheckingUserInput(false);
            }
        }

        Console.WriteLine("введите количество любимых цветов: ");
        int favColorsQuantity = CheckingUserInput(true);
        string[] favColors = new string[favColorsQuantity];
        for (int i = 0; i < favColorsQuantity; i++)
        {
            Console.WriteLine("Введите любимый цвет номер {0}", i + 1);
            favColors[i] = CheckingUserInput(false);
        }
        return (name, surname, hasPet, petsQuantity, petsNames, favColorsQuantity, favColors);
    }

    //метод, который принимает в себя заполненный кортеж и выводит данные на экран
    static void ShowTuple(string name, string surname, bool hasPet, int petsQuantity, string[] petsNames, int favColorsQuantity, string[] favColors)
    {
        Console.WriteLine("\nИтак, ваше имя: {0}\nВаша фамилия: {1}", name, surname);

        if (hasPet == false)
        {
            Console.WriteLine("У вас нет домашних питоцев");
        }
        else if (hasPet && petsQuantity == 1)
        {
            Console.WriteLine("У вас есть питомец, его имя: {0}", petsNames[0]);
        }
        else if (hasPet && petsQuantity > 1)
        {
            Console.WriteLine("У вас есть домашние животные, сейчас перечислим их клички: ");
            foreach (var petsName in petsNames)
            {
                Console.WriteLine(petsName);
            }
        }

        if (favColorsQuantity == 1)
        {
            Console.WriteLine("Ваш любимый цвет: {0}", favColors[0]);
        }
        else if (favColorsQuantity > 1)
        {
            Console.WriteLine("Ваши любимые цвета: ");
            foreach (var color in favColors)
            {
                Console.WriteLine(color);
            }
        }
    }

    public static void Main(string[] args)
    {
        var userData = FillingUserDataTuple();
        ShowTuple(userData.Item1, userData.Item2, userData.Item3, userData.Item4, userData.Item5, userData.Item6, userData.Item7);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();  
    }
}



