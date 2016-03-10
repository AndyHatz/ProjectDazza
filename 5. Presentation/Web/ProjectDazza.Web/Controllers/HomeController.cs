using ProjectDazza.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectDazza.Web.Controllers
{
	public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

			var model = new AddressModel();
			model.address = "158 City Road, Southbank";


			model.countries = GiveMeCountries();


			return View(model);
        }

		public ActionResult Save(string jsondata)
		{
			var serializer = new JavaScriptSerializer();

			AddressModel model = serializer.Deserialize<AddressModel>(jsondata);

			return View("About");
		}

		private List<string> GiveMeCountries()
		{
			return new List<string>()
			{
				"Australia",
				"New Zealand",
				"China",
				"India",
				"United States",
				"Indonesia",
				"Brazil"
			};
		}

		//public ActionResult About(AddressModel model)
		//{
		//	return new EmptyResult();
		//}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}