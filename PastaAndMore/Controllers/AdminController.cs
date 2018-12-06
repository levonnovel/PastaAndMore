using PastaAndMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PastaAndMore.Controllers
{
	public class AdminController : Controller
	{

		public ActionResult Index()
		{
			if(Session["login"] == null)
			{
				return RedirectToAction("Login");
			}
			List<Category> Categories = Category.GetAllCategories();
			List<Product> Products = Product.GetAllProducts();
			Tuple<List<Category>, List<Product>> P = new Tuple<List<Category>, List<Product>>(Categories, Products);
			return View(P);
		}
		public ActionResult Login()
		{
			return View();
		}
		public JsonResult Authorise(string login, string password)
		{
			
			//return RedirectToAction("Index");
			if (Admin.CheckAdmin(login, password))
			{
				Session["login"] = login;
				Session.Timeout = 1;
				return Json(new
				{
					success = true,
					responseText = "The attached file is supported."
				});
			}

			return Json(new
			{
				success = false,
				responseText = "The attached file is not supported."
			});
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