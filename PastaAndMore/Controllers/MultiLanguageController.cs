using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PastaAndMore.Controllers
{
	public class MultiLanguageController : Controller
	{
		// GET: MultiLanguage
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Change(string Lang)
		{
			if(Lang != null)
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
				Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
			}

			HttpCookie cookie = new HttpCookie("Language");
			cookie.Value = Lang;
			Response.Cookies.Add(cookie);

			return View("~/Views/Home/Index.cshtml");
		}
	}
}