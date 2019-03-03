using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace PastaAndMore.Models
{
	public class IMG
	{
		static string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		public int ID { get; set; }
		public int Type { get; set; }
		public string Path { get; set; }
		public static void Update(IMG img)
		{
			StringBuilder queryString = new StringBuilder("UPDATE MainPageImgs SET Path = @path WHERE ID = @id");

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand(Convert.ToString(queryString), conn);
				SqlParameter paramID = new SqlParameter("@id", img.ID);
				SqlParameter paramPath = new SqlParameter("@path", img.Path);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramPath);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

			}
		}
		public static IMG GetIMG(int id)
		{
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM MainPageImgs WHERE ID = @id", conn);
				SqlParameter paramID = new SqlParameter("@id", id);
				cmd.Parameters.Add(paramID);
				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					return new IMG()
							{
								ID = Convert.ToInt32(dr["ID"]),
								Type = Convert.ToInt32(dr["Type"]),
								Path = dr["Path"].ToString()
							};
				}
			}
			return null;
		}
		public static List<IMG> GetAllIMGs()
		{
			List<IMG> IMGList = new List<IMG>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM MainPageImgs", conn);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					IMGList.Add(
							new IMG()
							{
								ID = Convert.ToInt32(dr["ID"]),
								Type = Convert.ToInt32(dr["Type"]),
								Path = dr["Path"].ToString()
							}
						);
				}
				return IMGList;
			}
		}

	}
}