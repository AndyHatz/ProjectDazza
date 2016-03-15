using System;

namespace ProjectDazza.Web.Models
{
    public class PrisonerDetailsModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }

        public PrisonerDetailsReferenceDataModel ReferenceData { get; set; }

        public PrisonerDetailsModel()
        {
            ReferenceData = new PrisonerDetailsReferenceDataModel();
        }
    }
}