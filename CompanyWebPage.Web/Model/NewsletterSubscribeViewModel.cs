using CompanyWebPage.Web.Resources;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyWebPage.ViewModel
{
    public class NewsletterSubscribeViewModel
    {
        [Range(1, 99)]
        [Required(ErrorMessageResourceType = typeof(SharedResources),
    ErrorMessageResourceName = "AgeIsIncorrect")]

        public int? Age { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources),
      ErrorMessageResourceName = "EmailCanNotBeEmpty")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResources),
    ErrorMessageResourceName = "FirstNameCanNotBeEmpty")]
        public string FirstName { get; set; }
    }
}
