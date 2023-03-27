using System;
using System.Linq;
using System.Runtime.InteropServices;

class MainClass
{
    public static void Main(string[] args)
    {
        //метод, спрашивающий у юзера любимые цвета, возвращает массив результатов.
        string[] AskAboutColor(string _userName, int _arrayLength)
        {
            string[] _favcolors = new string[_arrayLength];
            for(int i = 0; i < _arrayLength; i++) 
            {   
                Console.WriteLine("\n{0}, введи свой любимый цвет на английском: ", _userName);
                string userColor = Console.ReadLine();
                userColor = userColor.ToLower();
                if (userColor == "red")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("{0}, твой любимый цвет: красный!", _userName);
                }
                else if (userColor == "green")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("{0}, твой любимый цвет: зелёный!", _userName);
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
                _favcolors[i] = userColor;

            }
            return _favcolors;
        }

        //метод, выводит список цветов из существующего массива
        void ShowColor(params string[] _favcolors)
        {
            Console.WriteLine("\nВаши любимые цвета :");
            foreach(var color in _favcolors)
            {
                Console.WriteLine(color);
            }
        }

        //метод, принимающий с клавиатуры целые числа, записывает в массив. в конце перечисляет элементы массива, возвращает результатом сам массив.
        int[] GetArrayFromConsole(int num = 5)
        {   
            var _array = new int[num];
            Console.WriteLine("Сейчас мы введём {0} чисел, чтоб записать их в массив", num);
            for (int i = 0; i < _array.Length; i++)
            { 
                Console.WriteLine("введите число номер {0}", i + 1);
                _array[i] = int.Parse(Console.ReadLine());
            }
            return _array;
        }

        //метод, сортирующий массив по возрастанию, возращает отсортированный массив
        int[] SortAscend(int[] _array)
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                int minimumNumber = _array[i];
                for (int k = i + 1; k < _array.Length; k++)
                {
                    if (_array[k] < _array[i])
                    {
                        minimumNumber = _array[k];
                        _array[k] = _array[i];
                        _array[i] = minimumNumber;
                    }
                }
            }
            return _array;
        }

        //метод, сортирующий массив по убыванию, возращает отсортированный массив
        int[] SortDescend(int[] _array)
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                int maximumNumber = _array[i];
                for (int k = i + 1; k < _array.Length; k++)
                {
                    if (_array[k] > _array[i])
                    {
                        maximumNumber = _array[k];
                        _array[k] = _array[i];
                        _array[i] = maximumNumber;
                    }
                }
            }
            return _array;
        }


        //сортирует массив по возрастанию + по убыванию
        void SortArray(in int[] _array, out int[] _sortedasc, out int[] _sorteddesc)
        {
            _sortedasc = SortAscend(_array);
            int[] _arrayclone = new int[_sortedasc.Length];
            _sortedasc.CopyTo(_arrayclone, 0);
            _sorteddesc = SortDescend(_arrayclone);
        }

        //принимает массив, если параметр "нужно сортировать" = истина, сортирует по возрастанию+убыванию, и выводит на экран оригинал+2 сортированных массива
        //если параметр "нужно сортировать" = ложь, просто выводит на экран массив
        void ShowArray(in int[] _array, bool isNeedToSort)
        {
            if (isNeedToSort)
            {
                int[] sortedasc = new int[_array.Length];
                int[] sorteddesc = new int[_array.Length];
                SortArray(_array, out sortedasc, out sorteddesc);
                Console.WriteLine("Оригинал массива: ");
                foreach (var number in _array)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine("Массив по возрастанию: ");
                foreach (var number in sortedasc)
                {
                    Console.WriteLine(number);
                }
                Console.WriteLine("Массив по убыванию: ");
                foreach (var number in sorteddesc)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Ваш массивю: ");
                foreach (var number in _array)
                {
                    Console.WriteLine(number);
                }
            }
        }

        //рекурсия,  выводит строку, введенную юзером, в виде "эха", глубину которого тоже задаёт юзер (параметры задаются через консоль в теле программы)
        //убирает буквы из фразы, создавая видимость эха, останавливается, если длина фразы в эхе меньше 1, чтоб не повторять в конце много раз одну букву
        //менял именно цвет шрифта, а не цвет бэкграунда, потому что так выглядит симпатичнее :D
        void Echo(string _saidWord, int _echoDepth)
        {
            string echoedWord = _saidWord;
            if (echoedWord.Length > 2)
            {
                echoedWord = echoedWord.Remove(0, 2);
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = (ConsoleColor)_echoDepth;
            Console.WriteLine("...{0}",echoedWord);
            if (_echoDepth > 1 && echoedWord.Length > 2) 
            {   
                Echo(echoedWord, _echoDepth - 1);
            }
        }


        /*юнит 5.3.1, чисто потестить
        int age = 34;
        void ChangeAge(ref int userAge)
        {
            Console.WriteLine("enter your age: ");
            userAge = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(age);
        ChangeAge(ref age);
        Console.WriteLine(age);

        void BigDataOperation(in int[] _arr)
        {
            _arr[0] = 4;
        }
        var arr = new int[] { 1, 2, 3 };
        BigDataOperation(arr);

        Console.WriteLine(arr[0]);
        */

        //начинаем тело программы

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Введите фразу, которую вы хотите крикнуть в горах, и эхо её повторит! ");
        string saidWord = Console.ReadLine();

        Console.WriteLine("Введите глубину эха: ");
        int echoDepth = int.Parse(Console.ReadLine());
        Echo(saidWord, echoDepth);

        (string name, int age) anketa;

        Console.Write("Введите имя: ");
        anketa.name = Console.ReadLine();

        Console.Write("Введите возраст с цифрами: ");
        anketa.age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ваше имя: {0}", anketa.name);
        Console.WriteLine("Ваш возраст: {0}", anketa.age);

        string[] favcolors = AskAboutColor(anketa.name, 3);
        ShowColor(favcolors);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("\nС цветами понятно, теперь поговорим про цифры.");
        var array = GetArrayFromConsole(5);
        ShowArray(array, true);

        Console.WriteLine("Нажмите любую клавишу для выхода... ");
        Console.ReadKey();
        
    }



}



