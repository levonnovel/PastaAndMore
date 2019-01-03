using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastaAndMore.Models
{
	public class ProductType
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Desc { get; set; }
		public int Price { get; set; }
		public string ImgPath { get; set; }
		public string CatName { get; set; }
	}
}