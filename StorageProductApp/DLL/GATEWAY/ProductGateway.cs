using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace StorageProductApp
{
    class ProductGateway
    {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static string query;

        private static void CallForConnection()
        {
            string conn = ConfigurationManager.ConnectionStrings["StorageProduct"].ConnectionString;
            connection = new SqlConnection(conn);
            connection.ConnectionString = conn;

        }
        public void Save(Product aProduct)
        {

            CallForConnection();
            connection.Open();
            query = "INSERT INTO Table_StorageProduct (Code,Name,Quantity) Values(@0,@1,@2)";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@0", aProduct.code);
            command.Parameters.AddWithValue("@1", aProduct.Name);
            command.Parameters.AddWithValue("@2", aProduct.Quantity);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Product> GetAllProduct()
        {

            CallForConnection();
            connection.Open();
            query = String.Format("SELECT* FROM Table_StorageProduct");
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<Product> allProduct = new List<Product>();


            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    Product aProduct = new Product();
                    aProduct.ProductID = (int) aReader[0];
                    aProduct.code = aReader[1].ToString();
                    aProduct.Name = aReader[2].ToString();
                    aProduct.Quantity = (double) aReader[3];
                    allProduct.Add(aProduct);                   
                }
            }
            connection.Close();
            return allProduct;
        }

        public List<double> GetProductQuantityList()
        {
            CallForConnection();
            connection.Open();
            query = String.Format("SELECT Quantity FROM Table_StorageProduct");
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<double> productQuantityList = new List<double>();

            
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    double quantity = (double)aReader[0];
                    productQuantityList.Add(quantity);
                }
            }
            connection.Close();
            return productQuantityList;
        }
    }
}