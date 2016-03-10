using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDazza.Web.Models
{
	public class AddressModel
	{
		// Main Model
		public string name { get; set; }
		public string address { get; set; }
		public int postcode { get; set; }
		public string country { get; set; }


		// Reference Data
		public List<string> countries { get; set; }
	}
}
