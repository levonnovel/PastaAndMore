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
		public int Cat_ID { get; set; }
		public static void AddProduct(Product p)
		{

			using (SqlConnection conn = new SqlConnection(cs))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Products VALUES(@name, @desc, @cat_id); ", conn);
				SqlParameter paramID = new SqlParameter("@name", p.Name);
				SqlParameter paramDesc = new SqlParameter("@desc", p.Description);
				SqlParameter paramCatID = new SqlParameter("@cat_id", p.Cat_ID);
				cmd.Parameters.Add(paramID);
				cmd.Parameters.Add(paramDesc);
				cmd.Parameters.Add(paramCatID);

				conn.Open();
				SqlDataReader dr = cmd.ExecuteReader();


			}
		}
	}
}