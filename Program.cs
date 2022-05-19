using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises2
{
    class Program
    {
        public enum choices
        {
            calculator = 0,
            area = 1,
            speed = 2,
            c = 3,
            a = 4,
            s = 5,
            series = 6,
            prime = 7,
            p = 7,
            sr = 8
        }
        public enum types
        {
            basic = 0,
            quadratic = 1,
            b = 2,
            q = 3
        }

        public enum primeChoices
        {
            check = 0,
            sum = 1,
            c = 2,
            s = 3
        }
        static void Main(string[] args)
        {
            bool finished = false;
            while (!finished)
            {
                try
                {
                    string choice;
                    //while (choice != "calculator" && choice != "area" && choice != "speed")
                    do 
                    {
                        Console.WriteLine("Choose one: Calculator (c), Area (a), Speed (s), Series (sr) or Prime (p): ");
                        choice = Console.ReadLine().ToLower();
                    } while (!Enum.IsDefined(typeof(choices), choice)) ;
                        if (choice == "calculator" || choice == "c")
                        {
                        Calculator calculation = new Calculator();
                        string CalcType;
                        do
                        {
                            Console.WriteLine("Basic (b) or quadratic (q): ");
                            CalcType = Console.ReadLine().ToLower();
                        } while (!Enum.IsDefined(typeof(types), CalcType));
                        if (CalcType == "b" || CalcType == "basic")
                        {
                            Console.Write("Enter your first number: ");
                            calculation.number1 = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter your second number: ");
                            calculation.number2 = Convert.ToDouble(Console.ReadLine());
                            do
                            {
                                Console.WriteLine("Enter one of the following operators: +, -, *, / ");
                                calculation.operation = Console.ReadLine().ToLower();
                            } while (!calculation.Valid());
                            calculation.calculation();
                        } else
                        {
                            Console.Write("Enter the first co-efficient: ");
                            calculation.a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter the second co-efficient: ");
                            calculation.b = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter the third co-efficient: ");
                            calculation.c = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine($"Your quadratic is the following: {calculation.a}x² + {calculation.b}x + {calculation.c}");
                            calculation.roots(calculation.a, calculation.b, calculation.c);
                        }
                        }
                    else if (choice == "area" || choice == "a")
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
                    else if (choice == "speed" || choice == "s")
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
                    else if (choice == "series" || choice == "sr")
                    {
                        series myObj = new series();
                        Console.Write("Enter a number: ");
                        myObj.N = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter number of terms: ");
                        myObj.terms = int.Parse(Console.ReadLine());
                        myObj.SeriesCalc(myObj.N, myObj.terms);
                    }
                    else if (choice == "prime" || choice == "p")
                    {
                        Prime number = new Prime();
                        string primeChoice;
                        do
                        {
                            Console.WriteLine("Prime check (c) or prime sum (s): ");
                            primeChoice = Console.ReadLine().ToLower();
                        } while (!Enum.IsDefined(typeof(primeChoices), primeChoice));
                        if (primeChoice == "check" || primeChoice == "c")
                        {
                            Console.Write("Enter a number: ");
                            number.N = Convert.ToDouble(Console.ReadLine());
                            number.PrimeCheck(number.N);
                        }
                        if(primeChoice == "sum" || primeChoice == "s")
                        {
                            Console.Write("Enter starting number of your range: ");
                            number.x = int.Parse(Console.ReadLine());
                            Console.Write("Enter ending number of your range: ");
                            number.y = int.Parse(Console.ReadLine());
                            number.PrimeSum(number.x, number.y);
                        }

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
        public double number1 { get; set; }
        public double number2 { get; set; }
        public string operation { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }

        public bool Valid()
        {
            switch (operation)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    return true;
                default:
                    return false;
            }
        }

        public double discriminant(double a, double b, double c)
        {
            double disc = (b * b) - (4 * a * c);
            return disc;
        }

        public void roots(double a, double b, double c)
        {
            if (discriminant(a, b, c) < 0)
                Console.WriteLine("Roots are imaginary.");
            else
            {
                double result1 = (-b + Math.Sqrt(discriminant(a, b, c))) / (2 * a);
                double result2 = (-b - Math.Sqrt(discriminant(a, b, c))) / (2 * a);
                Console.WriteLine($"The roots to your quadratic are {result1} and {result2}");
            }
        }
        public void calculation()
        {
            double result;
            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
                default:
                    result = 0;
                    break;
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
            switch (shape)
            {
                case "triangle":
                case "rectangle":
                case "circle":
                    return true;
                default:
                    return false;
            }
        }

        public void Area()
        {
            double area;
            switch (shape)
            {
                case "rectangle":
                    area = length * width;
                    break;
                case "triangle":
                    area = 0.5 * length * width;
                    break;
                case "circle":
                    const double pi = Math.PI;
                    area = 0.5 * pi * length * length;
                    break;
                default:
                    area = 0;
                    break;
            }
            Console.WriteLine("The area of your {0} is {1}", shape, area);
        }

        public void Perimeter()
        {
            double perimeter;
            switch (shape)
            {
                case "rectangle":
                    perimeter = 2 * (length + width);
                    break;
                case "triangle":
                    perimeter = (length + width) + Math.Sqrt((length * length) + (width * width));
                    break;
                case "circle":
                    const double pi = Math.PI;
                    perimeter = 2 * pi * length;
                    break;
                default:
                    perimeter = 0;
                    break;
            }
            Console.WriteLine("The perimeter of your {0} is {1}", shape, perimeter);
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

    class series
    {
        public static double result = 0.0;
        public static double fact = 0.0;
        public double N { get; set; }
        public double terms { get; set; }

        public void SeriesCalc(double n, double terms)
        {
            for (int i = 0; i <= terms; i++)
            {
                if (i == 0)
                {
                    fact = 1;
                }
                else
                {
                    fact *= i;
                }
                result += Math.Pow(n, i) / fact;
                if (i == 0)
                {
                    Console.Write("1 + ");
                }
                else if (i == n)
                {
                    Console.Write("{0}^{1}/{1}! ", n, i);
                }
                else
                    Console.Write("{0}^{1}/{1}! + ", n, i);
            }
            Console.WriteLine($"= {result}");
        }
    }

    class Prime
    {
        public double N { get; set; }
        public static int ctr = 0;
        public int x { get; set; }
        public int y { get; set; }
        public void PrimeCheck(double n)
        {
            for(int i = 2; i < n; i++)
            {
                if(n%i==0)
                {
                    ctr++;
                    break;
                }
            }
            if (ctr == 0 && n != 1)
                Console.Write("{0} is a prime number.", n);
            else
                Console.Write("{0} is not a prime number.", n);
        }

        public void PrimeSum(int x, int y)
        {
            int n;
            List<int> sum = new List<int>();
            int sum1 = 0;
            for(n = x; n <= y; n++)
            {
                ctr = 0;
                for (int i = 2; i <= n/2; i++)
                {
                    if (n % i == 0)
                    {
                        ctr++;
                        break;
                    }
                }
                if (ctr == 0 && n != 1)
                {
                    Console.Write("{0} ", n);
                    sum.Add(n);
                }
            }
            foreach(int i in sum)
            {
                sum1 += i;
            }
            Console.WriteLine("\nThe sum of your primes is {0}", sum1);
        }
    }
}
