using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PastaAndMore.Models
{
	public class Opinion
	{
		static string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public string Comments { get; set; }
		public static List<Opinion> GetAllOpinions()
		{
			List<Opinion> OpList = new List<Opinion>();
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Opinions", conn);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					OpList.Add(
							new Opinion()
							{
								ID = Convert.ToInt32(dr["ID"]),
								Name = dr["Name"].ToString(),
								Email = dr["Email"].ToString(),
								Country = dr["Country"].ToString(),
								Comments = dr["Comments"].ToString()
							}
						);
				}
				return OpList;
			}
		}
		public static void AddOpinion(string name, string email, string country, string comments)
		{

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Opinions VALUES(@name, @email, @country, @comments); ", conn);
				SqlParameter paramID = new SqlParameter("@name", name);
				SqlParameter paramEmail = new SqlParameter("@email", email);
				SqlParameter paramCountry = new SqlParameter("@country", country);
				SqlParameter paramComments = new SqlParameter("@comments", comments);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramEmail);
				cmd.Parameters.Add(paramCountry);
				cmd.Parameters.Add(paramComments);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();


			}
		}
	}
}