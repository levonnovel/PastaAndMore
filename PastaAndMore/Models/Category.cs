﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace PastaAndMore.Models
{

	public class Category
	{
		static string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public static List<Category> GetAllCategories()
		{
			List<Category> CatList = new List<Category>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", conn);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					CatList.Add(
							new Category()
							{
								ID = Convert.ToInt32(dr["ID"]),
								Name = dr["Name"].ToString(),
								Description = dr["Description"].ToString()
							}
						);
				}
				return CatList;
			}
		}
		public static Category GetCategoryByName(string name)
		{
			Category Cat = new Category();

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE Name = @name", conn);
				SqlParameter paramID = new SqlParameter("@name", name);
				cmd.Parameters.Add(paramID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{

					return new Category()
					{
						ID = Convert.ToInt32(dr["ID"]),
						Name = dr["Name"].ToString(),
						Description = dr["Description"].ToString()
					};
				}
			}
			return null;
		}
		public static Category GetCategoryByID(int ID)
	
	{
			Category Cat = new Category();

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Categories WHERE ID = @id", conn);
				SqlParameter paramID = new SqlParameter("@id", ID);
				cmd.Parameters.Add(paramID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{

					return new Category()
					{
						ID = Convert.ToInt32(dr["ID"]),
						Name = dr["Name"].ToString(),
						Description = dr["Description"].ToString()
					};
				}
			}
			return null;
		}
		public static void AddCategory(string name, string desc)
		{

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Categories VALUES(@name, @desc); ", conn);
				SqlParameter paramID = new SqlParameter("@name", name);
				SqlParameter paramDesc = new SqlParameter("@desc", desc);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramDesc);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();


			}
		}
		public static void Update(Category p)
		{
			Category origin = Category.GetCategoryByID(p.ID);


			StringBuilder queryString = new StringBuilder("UPDATE Categories SET ");

			foreach (var elem in origin.GetType().GetProperties())
			{
				if (elem.GetValue(p)?.ToString() != elem.GetValue(origin)?.ToString())
				{
					queryString.Append(elem.Name);
					queryString.Append(" = ");
					queryString.Append("@"); //elem.GetValue(this)
					queryString.Append(elem.Name);
					queryString.Append(", ");
				}
			}

			queryString.Replace(",", "", queryString.Length - 20, 20);
			queryString.Append("WHERE ID = ");
			queryString.Append(p.ID);

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand(Convert.ToString(queryString), conn);
				SqlParameter paramID = new SqlParameter("@name", p.Name);
				SqlParameter paramDesc = new SqlParameter("@description", p.Description);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramDesc);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

			}
		}
		public static void Delete(int id)
		{
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERe ID = @id", conn);
				SqlParameter paramID = new SqlParameter("@id", id);
				cmd.Parameters.Add(paramID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

			}
		}
	}
}