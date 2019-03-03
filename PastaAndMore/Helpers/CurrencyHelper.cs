using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PastaAndMore.Helpers
{
	public class CurrencyHelper
	{
		public static double AMD { get; set; } = 1;
		public static double RUR { get; set; }
		public static double USD { get; set; }
		public static double EUR { get; set; }

		public static void Execute()
		{

			HttpWebRequest request = CreateWebRequest();
			XmlDocument soapEnvelopeXml = new XmlDocument();
			soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                  <soap:Body>
                    <ExchangeRatesLatest xmlns=""http://www.cba.am/"" />
                  </soap:Body>
                </soap:Envelope>");

			using (Stream stream = request.GetRequestStream())
			{
				soapEnvelopeXml.Save(stream);
			}

			using (WebResponse response = request.GetResponse())
			{
				using (StreamReader rd = new StreamReader(response.GetResponseStream()))
				{
					string soapResult = rd.ReadToEnd();
					XmlDocument xmltest = new XmlDocument();
					xmltest.LoadXml(soapResult);

					var soapBody = xmltest.GetElementsByTagName("soap:Body")[0];
					var Rates = soapBody.ChildNodes[0].ChildNodes[0].ChildNodes[3];
					Dictionary<string, double> rate = new Dictionary<string, double>();
					for (int i = 0; i < Rates.ChildNodes.Count; i++)
					{
						var iso = Rates.ChildNodes[i].ChildNodes[0].ChildNodes[0].Value;
							if (iso == "USD" || iso == "RUB" || iso == "EUR")
							{
								rate.Add(Rates.ChildNodes[i].ChildNodes[0].ChildNodes[0].Value, double.Parse(Rates.ChildNodes[i].ChildNodes[2].ChildNodes[0].Value, CultureInfo.InvariantCulture));
							}
					}

					RUR = rate["RUB"];
					USD = rate["USD"];
					EUR = rate["EUR"];
				}
			}
		}
		/// <summary>
		/// Create a soap webrequest to [Url]
		/// </summary>
		/// <returns></returns>
		public static HttpWebRequest CreateWebRequest()
		{
			HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://api.cba.am/exchangerates.asmx");
			webRequest.Headers.Add(@"SOAP:Action");
			webRequest.ContentType = "text/xml;charset=\"utf-8\"";
			webRequest.Accept = "text/xml";
			webRequest.Method = "POST";

			return webRequest;
		}

	}
}