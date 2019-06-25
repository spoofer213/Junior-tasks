using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TaskOne
{

    /// задача №1
    /// необходимо просуммировать все найденные числа
    /// исправить потенциальную ошибку
    ///
    /// задачу необходимо реализовать, дописав код, чтобы data.GetDigits() стал работоспособным


    class Program
    {
        ///потенцеальная ошибка возможна:
        ///1) при использовании Random, поэтому в качестве решения я вынес инициализацию повыше и 
        ///сделал статической, чтобы во всей программе была одна единственная инициализация этого класса
        ///
        ///2) переполнение summary при повышении длины генерируемой строки. Добавил checked для вызова исключения
        ///
        static Random random = new Random();
        public static string RandomString(int length)
        {            
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static void Main(string[] args)
        {
            string data = RandomString(5);
            byte summary = 0;
            
            foreach (byte digit in data.GetDigits())
            {
                summary = checked((byte)(summary + digit));
            }

            Console.WriteLine($"{data} => {summary}");
            Console.ReadKey();
        }
    }

    public static class Extensions
    {
        public static byte[] GetDigits(this string data)
        {
            var isHaveDigits = data.Any(c => char.IsDigit(c));
            if (isHaveDigits)
            {
                byte[] matches = Regex.Matches(data, "\\d")
                .Cast<Match>()
                .Select(x => byte.Parse(x.Value))
                .ToArray();               
                return matches;
            }
            return new byte[] {0};
        }
    }
}