using System;

namespace ModuloExponentiation
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] arr = new double[3]; // a, b, c
            double Answer = 0;
            arr = ReturnArrayNumb(arr);

            if (arr[1] < 0) Answer = 0;
            else Answer = Math.Pow(arr[0], arr[1]) % arr[2];
            Console.WriteLine("Answer: " + Answer);
        }

        static double[] ReturnArrayNumb(double[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                string NumbStr = "";
                if (i == 0) NumbStr = "A";
                else if (i == 1) NumbStr = "B";
                else NumbStr = "C";

                Array[i] = EnterNumbers(i, NumbStr);
            }

            return Array;
        }

        static double EnterNumbers(double Numb, string NumbStr)
        {
            Console.Write(NumbStr + ": ");
            Numb = TryEnterNumber(Numb);
            return Numb;
        }

        static double TryEnterNumber(double Num)
        {
            try
            {
                Num = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Write("Error! Enter the correct value, pls: ");
                Num = TryEnterNumber(Num);
            }

            return Num;
        }
    }
}