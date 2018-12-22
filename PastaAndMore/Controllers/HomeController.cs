using PastaAndMore.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
	
namespace PastaAndMore.Controllers
{
	public class HomeController : BaseController
	{

		public HomeController()
		{
			SetResource();
		}
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Menu(string cat)
		{
			List<Product> products = Product.GetProductsByCatName(cat);
			Tuple<List<Product>, string> t = new Tuple<List<Product>, string>(products, cat);
			return View(t);
		}
	
	}
}