using System;
using System.Collections.Generic;
using System.Linq;

namespace Fruit
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintInvoice(PriceList(3), CustomerList(2));
        }
        public static double Check(string number)
        {
            double result;
            while (!double.TryParse(number, out result))
            {
                Console.WriteLine("Enter a valid number");
                number = Console.ReadLine();
            }
            return result;
        }
        public static List<Fruit> PriceList(int numberOfFruits)
        {
            List<Fruit> fruits = new List<Fruit>();
            Console.WriteLine("------------------------------------Price List------------------------------------");
            for (int i = 0; i < numberOfFruits; i++)
            {
                Console.Write("Enter a name of fruit: ");
                Fruit fruit = new Fruit();
                fruit.Name = Console.ReadLine();
                Console.Write("Enter the price of the fruit per kilo: ");
                fruit.PricePerKilo = Check(Console.ReadLine());
                fruits.Add(fruit);
            }
            return fruits;
        }
        public static List<Fruit> CustomerList(int numberOfPurchses)
        {
            List<Fruit> fruits = new List<Fruit>();
            Console.WriteLine("------------------------------------Customer List------------------------------------");
            for (int i = 0; i < numberOfPurchses; i++)
            {
                Console.Write("Enter a name of fruit: ");
                Fruit fruit = new Fruit();
                fruit.Name = Console.ReadLine();
                Console.Write("Enter the weight of the fruit in kilo: ");
                fruit.WeightKilo = Check(Console.ReadLine());
                fruits.Add(fruit);
            }
            return fruits;
        }
        public static double TotalPrice(List<Fruit> priceList, List<Fruit> customerList)
        {
            var factor = from weight in customerList
                         join price in priceList
                         on weight.Name.ToLower() equals price.Name.ToLower()
                         select new
                         {
                             fruitName = weight.Name.ToLower(),
                             fruitWeightKilo = weight.WeightKilo,
                             fruitPricePerKilo = price.PricePerKilo,
                             totalPricePerFruit = weight.WeightKilo * price.PricePerKilo
                         };
            return factor.Sum(i => i.totalPricePerFruit);
        }
        public static void PrintInvoice(List<Fruit> priceList, List<Fruit> customerList)
        {
            var factor = (from weight in customerList
                          join price in priceList
                          on weight.Name.ToLower() equals price.Name.ToLower()
                          select new
                          {
                              fruitName = weight.Name.ToLower(),
                              fruitWeightKilo = weight.WeightKilo,
                              fruitPricePerKilo = price.PricePerKilo,
                              totalPricePerFruit = weight.WeightKilo * price.PricePerKilo
                          }).ToList();
            double totalPrice = TotalPrice(priceList, customerList);
            factor.ForEach(i => Console.WriteLine($"Fruit Name:\t\t{i.fruitName}\nWeight In Kilo:\t\t{i.fruitWeightKilo}\n" +
                $"Price Per Kilo:\t\t{i.fruitPricePerKilo}\nTotal Price:\t\t{i.totalPricePerFruit}\n"));
            Console.WriteLine($"Sum:\t\t\t{totalPrice}");
        }
    }
    class Fruit
    {
        public string Name { get; set; }
        double _weightKilo;
        double _pricePerKilo;
        public double WeightKilo
        {
            get { return _weightKilo; }
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Enter a positive number");
                    value = Program.Check(Console.ReadLine());
                }
                _weightKilo = value;
            }
        }
        public double PricePerKilo
        {
            get { return _pricePerKilo; }
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Enter a positive number");
                    value = Program.Check(Console.ReadLine());
                }
                _pricePerKilo = value;
            }
        }
    }
}
