using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
	}
}