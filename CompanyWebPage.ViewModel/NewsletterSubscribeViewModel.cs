using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyWebPage.ViewModel
{
    public class NewsletterSubscribeViewModel
    {
        [Range(1,99)]
        [Required]
        public int? Age { get; set; }

        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
