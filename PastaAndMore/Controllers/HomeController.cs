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
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Menu()
		{
			return View();
		}
		public ActionResult AdminPage()
		{
			List<Category> Categories = Category.GetAllCategories();

			return View(Categories);
		}
		public void AddProduct(string product, string desc, string cat)
		{
			Category c = Category.GetCategoryByName(cat);
			Product.AddProduct(new Product() { Name = product, Description = desc, Cat_ID = c.ID});
		}
	}
}