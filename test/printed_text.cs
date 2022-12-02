using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class printed_text
    {
        static int j = 60;
        static int i = 0;
        static string name = "";
        static string text = "";
        public static List<TableOfRecord> t = new();
        public static void Fist()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(1, 0);
            Console.Write("Введите ваше имя для таблицы рекордов ");
            name = Console.ReadLine();
            Fast_text();
        }
        public static void Fast_text()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Нажмите Enter, чтобы начать.");
            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            if (value == 0) { text = "Кандидаты в первый отряд космонавтов набирались среди военных лётчиков-истребителей по решению Сергея Павловича Королёва"; }
            else if (value == 1) { text = "Книги Пушкин любил с детства. По словам его младшего брата, он, еще будучи мальчиком, проводил бессонные ночи, тайком забираясь в кабинет отца."; }
            Console.SetCursorPosition(0, 1);
            Console.Write(text);
            ConsoleKeyInfo v = Console.ReadKey();
            char c;
            int mistakesCount = 0;
            Thread thread1 = new Thread(Time);
            if (v.Key == ConsoleKey.Enter)
            {
                thread1.Start();
                while (i < text.Length || j <= 0)
                {
                    int h = 0;
                    c = Console.ReadKey(true).KeyChar;
                    if (c == text[i])
                    {
                        Console.SetCursorPosition(i, 1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(c);
                        i++;
                    }
                    else mistakesCount++;
                }
            }
        }
        public static void Time()
        {
            while (j <= 60 && j >= 0)
            {
                Thread.Sleep(1000);
                Console.SetCursorPosition(40, 10);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(j + "..");
                if (j == 0)
                {
                    t.Add(new TableOfRecord(name, i, Math.Round((double)i / 60, 2)));
                    ToFile();
                    Console.SetCursorPosition(60, 10);
                    Console.WriteLine("Stop");
                    ConsoleKeyInfo v = Console.ReadKey();
                    if (v.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Fist();
                    }
                }
                j--;
            }
        }
        static void ToFile()
        {
            TableOfRecord.op(t);
            string path = "C:\\Users\\user6\\OneDrive\\Рабочий стол\\Таблица рекордов.json";
            if (File.Exists(path))
            {
                string json = JsonConvert.SerializeObject(t);
                File.AppendAllText(path, json);
            }
            else { File.Create(path); }

        }
    }
}
