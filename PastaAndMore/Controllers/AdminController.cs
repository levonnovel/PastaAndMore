using PastaAndMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastaAndMore.Controllers
{
	public class AdminController : Controller
	{

		public ActionResult Index()
		{
			List<Category> Categories = Category.GetAllCategories();
			List<Product> Products = Product.GetAllProducts();
			Tuple<List<Category>, List<Product>> P = new Tuple<List<Category>, List<Product>>(Categories, Products);
			return View(P);
		}
		public ActionResult AdminLogin()
		{
			return View();
		}
		public ActionResult Authorise(string login, string password)
		{
			return RedirectToAction("Index");

			if (Admin.CheckAdmin(login, password))
			{
				RedirectToAction("Index");
			}
		}
		public void AddProduct(string product, string desc, string cat)
		{
			Category category = Category.GetCategoryByName(cat);
			Product.AddProduct(new Product() { Name = product, Description = desc, Cat = category });
		}
		public void AddCategory(string name, string desc)
		{
			Category.AddCategory(name, desc);
		}

	}
}