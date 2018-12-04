using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PastaAndMore.Models
{
	public class Product
	{
		static string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Category Cat { get; set; }
		public static void AddProduct(Product p)
		{


			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Products VALUES(@name, @desc, @cat_id); ", conn);
				SqlParameter paramID = new SqlParameter("@name", p.Name);
				SqlParameter paramDesc = new SqlParameter("@desc", p.Description);
				SqlParameter paramCatID = new SqlParameter("@cat_id", p.Cat.ID);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramDesc);
				cmd.Parameters.Add(paramCatID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();


			}
		}
		public static List<Product> GetAllProducts()
		{
			List<Product> ProductsList = new List<Product>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					ProductsList.Add(
							new Product()
							{
								ID = Convert.ToInt32(dr["ID"]),
								Name = dr["Name"].ToString(),
								Description = dr["Description"].ToString(),
								Cat = Category.GetCategoryByID(Convert.ToInt32(dr["Category_ID"]))
							}
						);
				}
				return ProductsList;
			}
		}
	}
}