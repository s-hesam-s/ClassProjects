using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Products
{
    public class DbProduct
    {
        static string c = "Data Source = .;Initial Catalog = Products;Integrated Security = true";
        public static IEnumerable<Product> GetProducts()
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                return sqlConnection.Query<Product>("select * from Product").ToList();
            }
        }
        public static IEnumerable<Product> GetProductsOver500()
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                return sqlConnection.Query<Product>("select * from Product where Price > 500").ToList();
            }
        }
        public static IEnumerable<Product> GetProductsBetween500And1500()
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                return sqlConnection.Query<Product>("select * from Product where Price > 500 and Price < 1500").ToList();
            }
        }
        public static IEnumerable<Product> GetProductsWithA()
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                return sqlConnection.Query<Product>("select * from Product where name like '%a%'").ToList();
            }
        }
        public static void Insert(Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                string newProduct = "insert into product values(@name,@price)";
                sqlConnection.Execute(newProduct, product);
            }
        }
        public static void Delete(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                string deleteProduct = "delete from product where id = @Id";
                sqlConnection.Execute(deleteProduct, new { Id = id });
            }
        }
        public static void Update(int id, Product product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(c))
            {
                Product oldProduct = sqlConnection.Query<Product>("select * from product where Id = @Id", new { Id = id })
                                                         .FirstOrDefault();

                if (product.Name == default)
                {
                    oldProduct.Name = oldProduct.Name;
                }
                else
                {
                    oldProduct.Name = product.Name;
                }

                if (product.Price == default)
                {
                    oldProduct.Price = oldProduct.Price;
                }
                else
                {
                    oldProduct.Price = product.Price;
                }

                sqlConnection.Execute("update product set name =@Name,Price =@Price where Id = @Id", oldProduct);
                //string newProduct = $"update Product set Name = 'product.Name',Price ={product.Price} where Id = @Id";
                //sqlConnection.Execute(newProduct, new { Id = id });
            }

        }
    }
}
