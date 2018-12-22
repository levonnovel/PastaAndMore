using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;

namespace PastaAndMore.Controllers
{
	public class BaseController : Controller
	{
		public void SetResource()
		{
			Dictionary<string, string> categories = new Dictionary<string, string>();
			object objKey = null;
			object objVal = null;
			string strKey = string.Empty;
			string strVal = string.Empty;
			ResourceManager rm = Resources.MenuText.ResourceManager;
			var recource = rm.GetResourceSet(CultureInfo.CurrentCulture, true, true);
			
			foreach (DictionaryEntry el in recource)
			{
				objKey = el.Key;
				strKey = Convert.ToString(objKey);
				objVal = el.Value;
				strVal = Convert.ToString(objVal);
				categories.Add(strKey, strVal);
				//categories.Add(str);
			}
			ViewData["CatList"] = categories;
		}
	}
}