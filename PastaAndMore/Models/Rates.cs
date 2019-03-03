using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace PastaAndMore.Models
{
	public class Rates
	{
		public static double USD;
		public static double EUR;
		public static double RUR;
		public static void GetRates()
		{
			string URL = "https://bankersalgo.com/apirates2/5c311ea84bef0/3c60c6fbf25040a50c2794bbf2de3506/AMD";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
			request.ContentType = "application/json; charset=utf-8";
			//request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
			//request.PreAuthenticate = true;
			HttpWebResponse response = request.GetResponse() as HttpWebResponse;
			using (Stream responseStream = response.GetResponseStream())
			{
				StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
				dynamic deserializedProduct = JsonConvert.DeserializeObject<dynamic>(reader.ReadToEnd());

				var rates = deserializedProduct["rates"];
				USD = Convert.ToDouble(rates["USD"]);
				RUR = Convert.ToDouble(rates["RUR"]);
				EUR = Convert.ToDouble(rates["EUR"]);
			}
		}
	}
}