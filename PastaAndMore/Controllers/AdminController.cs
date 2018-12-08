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
		public JsonResult UpdateProduct(string id, string name, string desc, int price, string catName)
		{

			Product p = new Product() { ID = Convert.ToInt32(id), Name = name, Description = desc, Price = price, Cat = Category.GetCategoryByName(catName) };
			//Product p = Product.GetProductById(Convert.ToInt32(id));
			Product.Update(p);
			return Json(new
			{
				success = true,
				responseText = "The product has been succesfully changed"
			});
		}
		public JsonResult UpdateCategory(string id, string name, string desc)
		{

			Category p = new Category() { ID = Convert.ToInt32(id), Name = name, Description = desc };
			//Product p = Product.GetProductById(Convert.ToInt32(id));
			Category.Update(p);
			return Json(new
			{
				success = true,
				responseText = "The product has been succesfully changed"
			});
		}
		public JsonResult DeleteProduct(string id)
		{

			Product.Delete(Convert.ToInt32(id));
			return Json(new
			{
				success = true,
				responseText = "The Product has been succesfully Deleted"
			});
		}
		public JsonResult DeleteCategory(string id)
		{
			var products = Product.GetAllProducts();
			foreach(var prod in products)
			{
				if(prod.Cat.ID == Convert.ToInt32(id))
				{
					return Json(new
					{
						success = false,
						responseText = "You cant delete this Category cause there is at leats 1 product connected with it"
					});
				}
			}
			Category.Delete(Convert.ToInt32(id));
			return Json(new
			{
				success = true,
				responseText = "The Category has been succesfully Deleted"
			});
		}
		public JsonResult AddProduct(string name, string desc, int price, string cat)
		{
			List<Product> products = Product.GetAllProducts();

			foreach(Product pr in products)
			{
				if(pr.Name == name)
				{
					return Json(new
					{
						success = false,
						responseText = "There is also a product with similar name"
					});
				}
			}

			Category category = Category.GetCategoryByName(cat);
			Product.AddProduct(new Product() { Name = name, Description = desc, Price = price, Cat = category });
			return Json(new
			{
				success = true,
				responseText = "The product has been succesfully Added"
			});
		}
		public JsonResult AddCategory(string name, string desc)
		{
			List<Category> categories = Category.GetAllCategories();

			foreach (Category cat in categories)
			{
				if (cat.Name == name)
				{
					return Json(new
					{
						success = false,
						responseText = "There is also a category with similar name"
					});
				}
			}

			Category.AddCategory(name, desc);
			return Json(new
			{
				success = true,
				responseText = "The category has been succesfully Added"
			});
		}

	}
}