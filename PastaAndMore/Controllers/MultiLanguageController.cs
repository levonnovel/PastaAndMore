using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using PastaAndMore.Models;

namespace PastaAndMore.Controllers
{
	public class MultiLanguageController : BaseController
	{
	
		// GET: MultiLanguage
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Change(string lang)
		{
			if(lang != null)
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
			}

			HttpCookie cookie = new HttpCookie("Language");
			cookie.Value = lang;
			Response.Cookies.Add(cookie);


			SetResource();

			return View("~/Views/Home/Index.cshtml");
		}
	}
}