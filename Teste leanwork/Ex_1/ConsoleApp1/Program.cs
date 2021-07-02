using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex1_1_Recursivo();
            Ex1_1();
            //Ex1_2();
            //Ex1_3();
        }
        private static void Ex1_1()
        {
            int qtd = 0;
            int numero = 0;
            for (int i = 1; i <= 1000000; i++)
            {
                int j = 0;
                Int64 result = i;
                do
                {
                    if (result % 2 == 0)
                        result = result / 2;
                    else
                        result = (result * 3) + 1;
                    j++;
                } while (result != 1);
                if (j > qtd)
                {
                    numero = i;
                    qtd = j;
                }
            }
            Console.WriteLine("Numero: " + numero + " Iterações: " + qtd);
        }

        private static void Ex1_1_Recursivo()
        {
            int qtd = 0;
            int numero = 0;
            //também é possível remover esse for com outra recursão.
            for (int i = 1; i <= 1000000; i++)
            {
                int j = 0;
                Int64 result = i;
                collatz(ref result, ref j, ref i, ref qtd, ref numero);
            }
            Console.WriteLine("Numero: " + numero + " Iterações: " + qtd);
        }

        private static void collatz(ref Int64 result, ref int j, ref int i, ref int qtd, ref int numero)
        {
            if (result != 1)
            {
                if (result % 2 == 0)
                    result = result / 2;
                else
                    result = (result * 3) + 1;
                j++;
                collatz(ref result, ref j, ref i, ref qtd, ref numero);
            }
            else
            {
                if (j > qtd)
                {
                    numero = i;
                    qtd = j;
                }
            }
        }

        private static void Ex1_2()
        {
            int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            Console.WriteLine(numeros.Where(x => x % 2 == 0).Count() == 0);
        }
        private static void Ex1_3()
        {
            int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
            int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };
            Console.WriteLine(string.Join(",", primeiroArray.Where(x => !segundoArray.Contains(x)).ToArray()));
        }

    }
}