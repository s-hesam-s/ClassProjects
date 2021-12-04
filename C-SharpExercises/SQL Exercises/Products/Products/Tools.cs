using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Products
{
    public class Tools
    {
        static string c = "Data Source = .;Initial Catalog = Products;Integrated Security = true";
        private static float TryFloat(string number)
        {
            float num;
            while (!float.TryParse(number, out num))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nEnter a valid number: ");
                Console.ResetColor();
                number = Console.ReadLine();
            }
            return num;
        }
        private static bool HasId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                return sqlConnection.Query<Product>("select * from product where Id = @Id", new { Id = id }).Any();
            }
        }
        public static void AddProduct()
        {
            string answer;
            do
            {
                Product product = new Product();
                Console.Write("\nEnter the name of the product: ");
                product.Name = Console.ReadLine();
                Console.Write("\nEnter the price of the product: ");
                product.Price = TryFloat(Console.ReadLine());
                DbProduct.Insert(product);
                Console.WriteLine("\nDo you want to continue? Yes/No");
                answer = Console.ReadLine();
                while (answer.ToLower() != "yes" && answer.ToLower() != "no")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEnter yes or no");
                    Console.ResetColor();
                    answer = Console.ReadLine();
                }
            } while (answer == "yes");
        }
        public static void UpdateProduct()
        {
            string answer;
            int id;
        Start1:
            Console.Write("\nEnter the id of the product you want to update: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (!HasId(id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nThe id is invalid");
                Console.ResetColor();
                Console.WriteLine("\nDo you want to continue? Yes/No");
                answer = Console.ReadLine();
                while (answer.ToLower() != "yes" && answer.ToLower() != "no")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEnter yes or no");
                    Console.ResetColor();
                    answer = Console.ReadLine();
                }
                if (answer == "yes")
                {
                    goto Start1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nUpdate canceled");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.WriteLine("\nWhich field(s) do you want to update? 1-Name 2-Price 3-Name and Price");
            Start2:
                int field = Convert.ToInt32(Console.ReadLine());
                switch (field)
                {
                    case 1:
                        Console.Write("\nEnter New Name: ");
                        DbProduct.Update(id, new Product { Name = Console.ReadLine() });
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nUpdate has been done successfully");
                        Console.ResetColor();
                        Console.WriteLine("\nDo you want to update another item: Yes/No");
                        string answer2 = Console.ReadLine();
                        while (answer2.ToLower() != "yes" && answer2.ToLower() != "no")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nEnter yes or no");
                            Console.ResetColor();
                            answer2 = Console.ReadLine();
                        }
                        if (answer2 == "yes")
                        {
                            goto Start1;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\nOpration has finished");
                            Console.ResetColor();
                        }
                        break;

                    case 2:
                        Console.Write("\nEnter New Price: ");
                        DbProduct.Update(id, new Product { Price = TryFloat(Console.ReadLine()) });
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nUpdate has been done successfully");
                        Console.ResetColor();
                        Console.WriteLine("\nDo you want to update another item: Yes/No");
                        string answer3 = Console.ReadLine();
                        while (answer3.ToLower() != "yes" && answer3.ToLower() != "no")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nEnter yes or no");
                            Console.ResetColor();
                            answer3 = Console.ReadLine();
                        }
                        if (answer3 == "yes")
                        {
                            goto Start1;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\nOpration has finished");
                            Console.ResetColor();
                        }
                        break;

                    case 3:
                        Product product = new Product();
                        Console.Write("\nEnter New Name: ");
                        product.Name = Console.ReadLine();
                        Console.Write("\nEnter New Price: ");
                        product.Price = TryFloat(Console.ReadLine());
                        DbProduct.Update(id, product);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\nUpdate has been done successfully");
                        Console.ResetColor();
                        Console.WriteLine("\nDo you want to update another item: Yes/No");
                        string answer4 = Console.ReadLine();
                        while (answer4.ToLower() != "yes" && answer4.ToLower() != "no")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nEnter yes or no");
                            Console.ResetColor();
                            answer4 = Console.ReadLine();
                        }
                        if (answer4 == "yes")
                        {
                            goto Start1;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\nOpration has finished");
                            Console.ResetColor();
                        }
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nEnter 1,2 or 3");
                        Console.ResetColor();
                        goto Start2;
                }
            }
        }
        public static void DeleteProduct()
        {

            string answer;
            int id;
        Start1:
            Console.Write("\nEnter the id of the product you want to delete: ");
            id = Convert.ToInt32(Console.ReadLine());
            if (!HasId(id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nThe id is invalid");
                Console.ResetColor();
                Console.WriteLine("\nDo you want to continue? Yes/No");
                answer = Console.ReadLine();
                while (answer.ToLower() != "yes" && answer.ToLower() != "no")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEnter yes or no");
                    Console.ResetColor();
                    answer = Console.ReadLine();
                }
                if (answer == "yes")
                {
                    goto Start1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nDelete canceled");
                    Console.ResetColor();
                }
            }
            else
            {
                DbProduct.Delete(id);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nDelete has been done successfully");
                Console.ResetColor();
                Console.WriteLine("\nDo you want to delete another item: Yes/No");
                string answer2 = Console.ReadLine();
                while (answer2.ToLower() != "yes" && answer2.ToLower() != "no")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEnter yes or no");
                    Console.ResetColor();
                    answer2 = Console.ReadLine();
                }
                if (answer2 == "yes")
                {
                    goto Start1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\nOpration has finished");
                    Console.ResetColor();
                }
            }
        }
        public static void PrintProducts(IEnumerable<Product> products)
        {
            if (products.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nThere is not any item in the list");
                Console.ResetColor();
            }
            else
            {
                foreach (var product in products)
                {
                    Console.Write($"\nProduct Id: {product.Id}\nProduct Name: {product.Name}\n" +
                        $"Product Price: {product.Price}");
                    Console.WriteLine();
                }
            }
        }
    }
}
