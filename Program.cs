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
                    Console.Write("Choose one: Calculator, Area");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "calculator")
                    {
                        Calculator calculation = new Calculator();
                        Console.Write("Enter your first number: ");
                        calculation.Number1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter your second number: ");
                        calculation.Number2 = Convert.ToDouble(Console.ReadLine());
                        do
                        {
                            Console.WriteLine("Enter one of the following operators: +, -, *, / ");
                            calculation.Operation = Console.ReadLine();
                        } while (!calculation.Valid());
                        calculation.calculation();
                    }
                    else if (choice.ToLower() == "area")
                    {
                        Shapes shape = new Shapes();
                        do
                        {
                            Console.Write("Enter a shape out of the following: Rectangle, Right-Angled Triangle or Circle");
                            shape.Shape = Console.ReadLine();
                        } while (!shape.Valid());
                        shape.Area();
                        shape.Perimeter();
                    }    


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
        private double number1;
        private double number2;
        private string operation;

        public double Number1
        {
            get { return number1; }
            set { number1 = value; }
        }

        public double Number2
        {
            get { return number2; }
            set { number2 = value; }
        }

        public string Operation
        {
            get { return operation; }
            set { operation = value; }
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
            double result;
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
    }

    class Shapes
    {
        private double length;
        private double width;
        private string shape;

        public double Length { get; set; }
        public double Width { get; set; }
        public string Shape { get; set; }

        public bool Valid()
        {
            if (shape.ToLower() == "triangle" || shape.ToLower() == "rectangle" || shape.ToLower() == "circle")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Area()
        {
            double area;
            if (shape.ToLower() == "rectangle")
            {
                area = length * width;
            }
            else if (shape.ToLower() == "triangle")
            {
                area = 0.5 * length * width;
            }
            else if (shape.ToLower() == "circle")
            {
                const double pi = Math.PI;
                area = 0.5 * pi * length * length;
            }
            else
            {
                area = 0;
            }
            Console.WriteLine("The area of your shape is " + area);
        }

        public void Perimeter()
        {
            double perimeter;
            if (shape.ToLower() == "rectangle")
            {
                perimeter = 2 * (length + width);
            }
            else if (shape.ToLower() == "triangle")
            {
                perimeter = (length + width) + Math.Sqrt((length * length) + (width * width));
            }
            else if (shape.ToLower() == "circle")
            {
                const double pi = Math.PI;
                perimeter = 2 * pi * length;
            }
            else
            {
                perimeter = 0;
            }
            Console.WriteLine("The perimeter of your shape is " + perimeter);
        }
    }
}
