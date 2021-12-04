using System;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            Tools.AddProduct();
            Tools.PrintProducts(DbProduct.GetProducts());

            Tools.UpdateProduct();
            Tools.PrintProducts(DbProduct.GetProducts());

            Tools.DeleteProduct();
            Tools.PrintProducts(DbProduct.GetProducts());

            Console.WriteLine("\nProducts'prices between 500 and 1500");
            Tools.PrintProducts(DbProduct.GetProductsBetween500And1500());

            Console.WriteLine("\nProducts'names that contain \"a\"");
            Tools.PrintProducts(DbProduct.GetProductsWithA());
        }
    }
}
