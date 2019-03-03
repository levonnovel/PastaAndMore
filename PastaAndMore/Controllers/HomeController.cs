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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PastaAndMore.Helpers;

namespace PastaAndMore.Controllers
{
	public class HomeController : BaseController
	{
		List<Product> products;
		public HomeController()
		{
			//ViewData["currency"] = "AMD";
			//if(Rates.USD == 0)
			//{
			//	Rates.GetRates();
			//}

			products = Product.GetAllProducts();
			CurrencyHelper.Execute();
			foreach (Product p in products)
			{
				p.PriceRUR = Math.Round(p.PriceAMD / CurrencyHelper.RUR, 2);
				p.PriceEUR = Math.Round(p.PriceAMD / CurrencyHelper.EUR, 2);
				p.PriceUSD = Math.Round(p.PriceAMD / CurrencyHelper.USD, 2);
			}
			SetResource();
		}

		// GET: Home
		public ActionResult Index()
		{
			CurrencyHelper.Execute();

			List<IMG> MainPageImgs= IMG.GetAllIMGs();
			List<IMG> CarouselImgs = new List<IMG>();
			List<IMG> GalleryImgs = new List<IMG>();
			foreach(IMG img in MainPageImgs)
			{
				if(img.Type == 1)
				{
					CarouselImgs.Add(img);
				}
				else
				{
					GalleryImgs.Add(img);
				}
			}
			Tuple<List<IMG>, List<IMG>> t = new Tuple<List<IMG>, List<IMG>>(CarouselImgs, GalleryImgs);
			return View(t);
		}
		public ActionResult Menu(string cat)
		{
			List<Product> catProducts = products.Where((x) => x.Cat.Name == cat).ToList();
			Tuple<List<Product>, string> t = new Tuple<List<Product>, string>(catProducts, cat);
			return View(t);
		}

	}
}	