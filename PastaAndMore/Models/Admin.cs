using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PastaAndMore.Models
{
	public class Admin
	{
		static string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public static bool CheckAdmin(string logIn, string pass)
		{
			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("SELECT * FROM Admins WHERE LogIn = @logIn AND Password = @pass", conn);
				SqlParameter paramLogIn = new SqlParameter("@logIn", logIn);
				SqlParameter paramPass = new SqlParameter("@pass", pass);
				cmd.Parameters.Add(paramLogIn);
				cmd.Parameters.Add(paramPass);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();
				
				if (dr.Read())
				{
					return true;
				}
			}
			return false;
		}
		
	}
}