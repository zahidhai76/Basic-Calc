using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            while (!finished)
            {
                try
                {
                    Calculator calculation = new Calculator();
                    Console.Write("Enter your first number: ");
                    calculation.Number1 = int.Parse(Console.ReadLine());
                    Console.Write("Enter your second number: ");
                    calculation.Number2 = int.Parse(Console.ReadLine());
                    do
                    {
                        Console.WriteLine("Enter one of the following operators: +, -, *, / ");
                        calculation.Operation = Console.ReadLine();
                    } while (!calculation.Valid());
                    calculation.calculation();
                    calculation.Number1 = int.Parse(Console.ReadLine());
                    finished = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }

    class Calculator
    {
        private int number1;
        private int number2;
        private string operation;

        public int Number1
        {
            get { return number1; }
            set { number1 = value; }
        }

        public int Number2
        {
            get { return number2; }
            set { number2 = value; }
        }

        public bool Valid()
        {
            if(operation == "+" || operation == "-" || operation == "*" || operation == "/")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void calculation()
        {
            int result;
            if(operation == "+")
            {
                result = number1 + number2;
            }
            else if (operation == "-")
            {
                result = number1 - number2;
            }
            else if (operation == "*")
            {
                result = number1 * number2;
            }
            else if (operation == "/")
            {
                result = number1 / number2;
            }
            else
            {
                result = 0;
            }
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
        }

        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }
    }
}
