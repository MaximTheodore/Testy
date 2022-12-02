using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class TableOfRecord
    {
        public string Name;
        public int Letter_in_minute;
        public double Letter_in_second;
        public TableOfRecord(string name, int LinMin = 0, double LinSec = 0)
        {
            Name = name;
            Letter_in_minute = LinMin;
            Letter_in_second = LinSec;
        }
        public static void op(List<TableOfRecord> tableOfRecords)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Таблица рекордов:");
            Console.WriteLine("-----------------");
            foreach (var record in tableOfRecords)
            {
                Console.WriteLine(record.Name+" "+ record.Letter_in_minute + " символов в минуту"+" "+ record.Letter_in_second + " символ в секунду");
            }
            Console.WriteLine("Нажмите на Escape, чтобы начать всё сначала.");
        }
    }
}
