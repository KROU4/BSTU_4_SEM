using Lab11.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11.Data
{
    public class ShopRepository
    {
        private readonly string _connectionString;

        public ShopRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ShopDB"].ConnectionString;
        }

        // Существующий метод получения всех продуктов
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM Products";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    });
                }
            }

            return products;
        }

        // Метод для получения элементов корзины
        public List<Product> GetCartItems()
        {
            List<Product> cartItems = new List<Product>();
            string query = "SELECT p.Id, p.Name, p.Price, c.Quantity FROM Cart c JOIN Products p ON c.ProductId = p.Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    cartItems.Add(new Product
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Price = (decimal)reader["Price"],
                        Quantity = (int)reader["Quantity"]
                    });
                }
            }

            return cartItems;
        }

        // Метод для добавления в корзину
        public void AddToCart(int productId, int quantity)
        {
            string query = "INSERT INTO Cart (ProductId, Quantity) VALUES (@ProductId, @Quantity)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Метод для удаления из корзины
        public void RemoveFromCart(int productId)
        {
            string query = "DELETE FROM Cart WHERE ProductId = @ProductId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}