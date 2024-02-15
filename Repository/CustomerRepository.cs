using WebApplication2.Models;
using WebApplication2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace WebApplication2.Repository
{
    public class CustomerRepository : ICustomerRepository
    {



        string connectionString = @"Data Source=APINP-ELPTOH9CG\SQLEXPRESS;Initial Catalog=chubb;User ID=tap2023;Password=tap2023;Encrypt=False";

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"select
DATENAME(Month,Orders.OrderDate)as OrderMonth,
Year(Orders.Orderdate) as OrderYear,
Orders.OrderID,
Customers.CustomerID,
Customers.ContactName,
Products.ProductID,
Orders.ShipCountry,
Orders.ShipVia,
Products.ProductName,
[Order Details].Quantity,
Orders.ShipName,
[Order Details].UnitPrice,
([Order Details].UnitPrice * [Order Details].Quantity) AS total
from Orders
join [Order Details] on [Order Details].OrderID=Orders.OrderID
join Shippers on Orders.ShipVia = Shippers.ShipperID
join Products on [Order Details].ProductID = Products.ProductID
join Suppliers on Suppliers.SupplierID = Products.SupplierID
join Customers on Orders.CustomerID = Customers.CustomerID 
order by month(OrderDate),year(OrderDate), OrderID ASC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer c = new Customer
                                {
                                    CustomerID = reader["CustomerID"].ToString(),
                                    ContactName = reader["ContactName"].ToString(),
                                    ShipCountry = reader["ShipCountry"].ToString(),
                                    ProductID = reader["ProductID"].ToString(),
                                    OrderID = reader["OrderID"].ToString(),
                                    Quantity = reader["Quantity"].ToString(),
                                    UnitPrice = reader["UnitPrice"].ToString(),
                                    Total = reader["total"].ToString(),
                                    ShipName = reader["ShipName"].ToString(),
                                    OrderMonth = reader["OrderMonth"].ToString(),
                                    OrderYear = reader["OrderYear"].ToString(),
                                    productName = reader["ProductName"].ToString(),
                                    ShipVia = reader["ShipVia"].ToString()

                                    // Set other properties as needed
                                };

                                customers.Add(c);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return customers;

        }

        public Customer GetCustomerById(string id)
        {
            Customer customerDetails = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string query = @"SELECT  
    Orders.OrderID,
    Customers.CustomerID,
    Orders.OrderID,
    DATENAME(Month, Orders.OrderDate) AS OrderMonth,
    YEAR(Orders.OrderDate) AS OrderYear,
    Customers.ContactName,
    Products.ProductID,
    Orders.ShipCountry,
    Orders.ShipVia,
    Products.ProductName,
    [Order Details].Quantity,
    Orders.ShipName,
    [Order Details].UnitPrice,
    ([Order Details].UnitPrice * [Order Details].Quantity) AS total 
FROM Orders 
JOIN [Order Details] ON [Order Details].OrderID = Orders.OrderID
JOIN Shippers ON Orders.ShipVia = Shippers.ShipperID
JOIN Products ON [Order Details].ProductID = Products.ProductID
JOIN Suppliers ON Suppliers.SupplierID = Products.SupplierID
JOIN Customers ON Orders.CustomerID = Customers.CustomerID
where Customers.CustomerID = @id";

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                customerDetails = new Customer
                                {

                                    CustomerID = reader["CustomerID"].ToString(),
                                    ContactName = reader["ContactName"].ToString(),
                                    ShipCountry = reader["ShipCountry"].ToString(),
                                    ProductID = reader["ProductID"].ToString(),
                                    OrderID = reader["OrderID"].ToString(),
                                    Quantity = reader["Quantity"].ToString(),
                                    UnitPrice = reader["UnitPrice"].ToString(),
                                    Total = reader["total"].ToString(),
                                    ShipName = reader["ShipName"].ToString(),
                                    OrderMonth = reader["OrderMonth"].ToString(),
                                    OrderYear = reader["OrderYear"].ToString(),
                                    productName = reader["ProductName"].ToString(),
                                    ShipVia = reader["ShipVia"].ToString()


                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return customerDetails;
        }

        public string UpdateCustomerById(string id,string contactName)
        {
            string response = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE  Customers SET ContactName = @contactName where CustomerID= @id ;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@contactName", contactName);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            response = "Data updated successfully!";
                        }
                        else
                        {
                            response = "No data found with the given ID.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine(ex.Message);
                response = "An error occurred while deleting the data.";
            }

            return response;
        }


    public string DeleteCustomerById(string id)
    {

            string response = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "delete from Orders where OrderID = @id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                       
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            response = "Data delete successfully!";
                        }
                        else
                        {
                            response = "Unable to delete";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine(ex.Message);
                response = "An error occurred while deleting the data.";
            }

            return response;

        }

      
    }

    }