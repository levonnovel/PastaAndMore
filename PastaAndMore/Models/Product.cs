﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace PastaAndMore.Models
{
	public class Product
	{
		static string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double PriceAMD { get; set; }
		public double PriceUSD { get; set; }
		public double PriceEUR { get; set; }
		public double PriceRUR { get; set; }
		public static string CurrentCurrency { get; set; }
		public string ImgPath { get; set; }
		public Category Cat { get; set; }
		public static void AddProduct(Product p)
		{


			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Products VALUES(@name, @desc, @price, @imgPath, @cat_id); ", conn);
				SqlParameter paramID = new SqlParameter("@name", p.Name);
				SqlParameter paramDesc = new SqlParameter("@desc", p.Description);
				SqlParameter paramPrice = new SqlParameter("@price", p.PriceAMD);
				SqlParameter paramImgPath = new SqlParameter("@imgPath", p.ImgPath);
				SqlParameter paramCatID = new SqlParameter("@cat_id", p.Cat.ID);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramDesc);
				cmd.Parameters.Add(paramPrice);
				cmd.Parameters.Add(paramImgPath);
				cmd.Parameters.Add(paramCatID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();


			}
		}
		public static void Update(Product p)
		{
			bool hasChanges = false;
			Product origin = Product.GetProductById(p.ID);


			StringBuilder queryString = new StringBuilder("UPDATE Products SET ");

			foreach (var elem in origin.GetType().GetProperties())
			{
				if (elem.GetValue(p)?.ToString() != elem.GetValue(origin)?.ToString())
				{
					hasChanges = true;
					queryString.Append(elem.Name);
					queryString.Append(" = ");
					queryString.Append("@"); //elem.GetValue(this)
					queryString.Append(elem.Name);
					queryString.Append(", ");
				}
			}
			if (p.Cat.ID != origin.Cat.ID)
			{
				hasChanges = true;
				queryString.Append("Category_ID");
				queryString.Append(" = ");
				queryString.Append("@"); //elem.GetValue(this)
				queryString.Append("cat_id");
				queryString.Append(", ");
			}
			if (!hasChanges)
			{
				return;
			}
			queryString.Replace(",", "", queryString.Length - 20, 20);
			queryString.Append("WHERE ID = ");
			queryString.Append(p.ID);

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand(Convert.ToString(queryString), conn);
				SqlParameter paramID = new SqlParameter("@name", p.Name);
				SqlParameter paramDesc = new SqlParameter("@description", p.Description);
				SqlParameter paramPrice = new SqlParameter("@price", p.PriceAMD);
				SqlParameter paramImgPath = new SqlParameter("@imgPath", p.ImgPath);
				SqlParameter paramCatID = new SqlParameter("@cat_id", p.Cat.ID);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramDesc);
				cmd.Parameters.Add(paramPrice);
				cmd.Parameters.Add(paramImgPath);
				cmd.Parameters.Add(paramCatID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();


			}
		}
		public static void Delete(int id)
		{
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERe ID = @id", conn);
				SqlParameter paramID = new SqlParameter("@id", id);
				cmd.Parameters.Add(paramID);

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
								PriceAMD = Convert.ToInt32(dr["Price"].ToString()),
								ImgPath = dr["imgPath"].ToString(),
								Cat = Category.GetCategoryByID(Convert.ToInt32(dr["Category_ID"]))
							}
						);
				}
				return ProductsList;
			}
		}
		public static Product GetProductById(int ID)
		{

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ID = @id", conn);
				SqlParameter paramID = new SqlParameter("@id", ID);
				cmd.Parameters.Add(paramID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{

					return new Product()
					{
						ID = Convert.ToInt32(dr["ID"]),
						Name = dr["Name"].ToString(),
						Description = dr["Description"].ToString(),
						PriceAMD = Convert.ToInt32(dr["Price"].ToString()),
						ImgPath = dr["imgPath"].ToString(),
						Cat = Category.GetCategoryByID(Convert.ToInt32(dr["Category_ID"].ToString()))

					};
				}
			}
			return null;
		}
		public static List<Product> GetProductsByCatName(string catName)
		{

			List<Product> products = new List<Product>();

			Category cat = Category.GetCategoryByName(catName);

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE Category_ID = @id", conn);
				SqlParameter paramID = new SqlParameter("@id", cat.ID);
				cmd.Parameters.Add(paramID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{

					products.Add(new Product()
					{
						ID = Convert.ToInt32(dr["ID"]),
						Name = dr["Name"].ToString(),
						Description = dr["Description"].ToString(),
						ImgPath = dr["imgPath"].ToString(),
						PriceAMD = Convert.ToUInt32(dr["Price"].ToString()),
						Cat = cat
					});
				}
				return products;

			}
		}
	}
}
