using ProjectDazza.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjectDazza.Web.Controllers
{
    public class PrisonerDetailsController : Controller
    {
        public ActionResult Index()
        {
            var model = SetUpModel();

            return View(model);
        }

        public ActionResult Save(string jsondata)
        {
            var serializer = new JavaScriptSerializer();

            PrisonerDetailsModel model = serializer.Deserialize<PrisonerDetailsModel>(jsondata);

            // Saving to database

            AttachReferenceData(model);

            return View("Index", model);
        }

        //public ActionResult Index(int id)
        //{
        //	var model = SetUpModel();

        //	return View(model);
        //}

        private PrisonerDetailsModel SetUpModel()
        {
            var model = new PrisonerDetailsModel();

            AttachReferenceData(model);

            return model;
        }

        private void AttachReferenceData(PrisonerDetailsModel model)
        {
            model.ReferenceData.Countries = GetCountries();
        }




        private List<string> GetCountries()
        {
            // This will ideally be replaced by a call to the service
            return new List<string>
            {
                "Australia",
                "New Zealand",
                "China",
                "India",
                "Other"
            };
        }
    }
}

