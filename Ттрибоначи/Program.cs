
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ттрибоначи
{
    class Program
    {
        static Dictionary<BigInteger, BigInteger> dict = new Dictionary<BigInteger, BigInteger>();
        static BigInteger num1, num2, num3;
        static BigInteger prevN = 0;
        static void Main(string[] args)
        {
            Console.Title = "Трибоначчи";
            dict.Add(0, 0);
            dict.Add(1, 1);
            dict.Add(2, 2);
            dict.Add(3, 3);
            num1 = dict[1]; num2 = dict[2]; num3 = dict[3];
            Console.WriteLine("Hit enter to get the next item");
            Console.Write("Enter the tribonach sequence element number> ");
            BigInteger counter = 1;
            while (true)
            {
                BigInteger n;
                string temp = Console.ReadLine();
                if (BigInteger.TryParse(temp, out n))
                {

                        BigInteger num = GetTribon(n);
                    Console.Write($"{n}:\t{num}\nSize: {num.ToString().Length}\n");
                    counter = n + 1;
                    Console.Write("> ");
                }
                else
                {
                    if (temp == "")
                    {
                        BigInteger num = GetTribon(counter);

                        Console.Write($"{counter}\tsize: {num.ToString().Length}:\t{num}");
                        counter++;
                    }
                    else
                    {
                        for (BigInteger i = counter; i <= counter + 100; i++)
                        {
                            BigInteger num = GetTribon(i);
                            Console.WriteLine($"{i}:\t{num:0.#}");
                        }
                        counter += 100;
                    }
                }
            }
        }

        static string GetProgressBar(float percents)
        {
            string output = "[";
            float half = percents / 2L;
            for (int i = 0; i < half; i++) output += (char)0x258C;
            for (int i = 0; i < 50 - half; i++) output += (char)0x2551;
            output += "]";
            return output;
        }



        static BigInteger GetTribon(BigInteger n)
        {
            int sign = 1;
            if (n < 0)
            {
                if ((n + 1) % 2 != 0)
                    sign = -1;
                n = -n;
            }
            BigInteger startIndex;
            BigInteger ans = 0;
            if (prevN <= n)
            {
                startIndex = prevN+1;
            }
            else
            {
                startIndex = 1;
                num1 = dict[1];
                num2 = dict[2];
                num3 = dict[3];
            }

            for (BigInteger i = startIndex; i <= n; i++)
            {
                if (dict.ContainsKey(i))
                {
                    ans = dict[i];
                }
                else
                {
                    ans = num1 + num2 + num3;
                }
                num1 = num2;
                num2 = num3;
                num3 = ans;

                float percents = ((float)(i-startIndex) * 100f) / ((float)n);
                Console.Title = $"Трибоначчи Progess: {GetProgressBar(percents)}{percents:f2}%";
            }
            Console.Title = "Трибоначчи";
            prevN = n;
            return sign * ans;

        }
    }
}
