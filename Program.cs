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
                    Console.WriteLine("Choose one: Calculator, Area, Speed ");
                    string choice = Console.ReadLine().ToLower();
                    while (choice != "calculator" && choice != "area" && choice != "speed")
                    {
                        Console.WriteLine("Choose one: Calculator, Area, Speed ");
                        choice = Console.ReadLine().ToLower();
                    }
                    if (choice == "calculator")
                    {
                        Calculator calculation = new Calculator();
                        Console.Write("Enter your first number: ");
                        calculation.Number1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter your second number: ");
                        calculation.Number2 = Convert.ToDouble(Console.ReadLine());
                        do
                        {
                            Console.WriteLine("Enter one of the following operators: +, -, *, / ");
                            calculation.Operation = Console.ReadLine().ToLower();
                        } while (!calculation.Valid());
                        calculation.calculation();
                    }
                    else if (choice.ToLower() == "area")
                    {
                        Shapes shape = new Shapes();
                        do
                        {
                            Console.WriteLine("Enter a shape out of the following: Rectangle, Triangle or Circle");
                            shape.Shape = Console.ReadLine().ToLower();
                        } while (!shape.Valid());
                        if (shape.Shape == "triangle" || shape.Shape == "rectangle")
                        {
                            Console.WriteLine("Enter the length of your " + shape.Shape);
                            shape.Length = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter the width of your " + shape.Shape);
                            shape.Width = Convert.ToDouble(Console.ReadLine());
                        }
                        else
                        {
                            Console.WriteLine("Enter the radius of your circle: ");
                            shape.Length = Convert.ToDouble(Console.ReadLine());
                        }
                        shape.Area();
                        shape.Perimeter();
                    }
                    else if (choice.ToLower() == "speed")
                    {
                        SpeedCalc car = new SpeedCalc();
                        Console.Write("Input distance(metres): ");
                        car.Distance = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Input time (hour): ");
                        car.Hour = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Input time (minutes): ");
                        car.Min = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Input time (seconds): ");
                        car.Sec = Convert.ToDouble(Console.ReadLine());
                        car.speed();
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
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
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
            if (operation == "+")
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

        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public string Shape
        {
            get { return shape; }
            set { shape = value; }
        }

        public bool Valid()
        {
            if (shape == "triangle" || shape == "rectangle" || shape == "circle")
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
            if (shape == "rectangle")
            {
                area = length * width;
            }
            else if (shape == "triangle")
            {
                area = 0.5 * length * width;
            }
            else if (shape == "circle")
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
            if (shape == "rectangle")
            {
                perimeter = 2 * (length + width);
            }
            else if (shape == "triangle")
            {
                perimeter = (length + width) + Math.Sqrt((length * length) + (width * width));
            }
            else if (shape == "circle")
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

    class SpeedCalc
    {
        private double distance, hour, min, sec, timeinseconds, mps, kph, mph;

        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public double Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        public double Min
        {
            get { return min; }
            set { min = value; }
        }
        public double Sec
        {
            get { return sec; }
            set { sec = value; }
        }
        public void speed()
        {
            timeinseconds = (hour * 3600) + (min * 360) + sec;
            mps = distance / timeinseconds;
            kph = (distance / 1000) / (timeinseconds / 3600);
            mph = kph / 1.609;
            Console.WriteLine("Your speed in metres/sec is {0}", mps);
            Console.WriteLine("Your speed in km/h is {0}", kph);
            Console.WriteLine("Your speed in miles/h is {0}", mph);
        }
    }

}
