using PastaAndMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PastaAndMore.Controllers
{
	public class HomeController : Controller
	{

		public HomeController()
		{
			ViewData["CatList"] = Category.GetAllCategories();
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