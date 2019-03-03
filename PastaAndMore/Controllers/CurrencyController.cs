using PastaAndMore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastaAndMore.Controllers
{
	public class CurrencyController : BaseController
	{
		// GET: Currency
		public ActionResult Index()
		{
			return View();
		}
		public JsonResult Change(string currency)
		{

			switch (currency)
			{
				case "AMD":
					Product.CurrentCurrency = "AMD";
					break;
				case "RUR":
					Product.CurrentCurrency = "RUR";
					break;
				case "EUR":
					Product.CurrentCurrency = "EUR";
					break;
				case "USD":
					Product.CurrentCurrency = "USD";
					break;
			}
			//ViewBag.Currency = currency;
			return Json(new
			{
				success = true
				//responseText = "The Product has been succesfully Deleted"
			});

		}
	}
}