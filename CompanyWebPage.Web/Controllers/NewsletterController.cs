using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace CompanyWebPage.Web.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly ILogger<NewsletterController> _logger;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public NewsletterController(ILogger<NewsletterController> logger, IStringLocalizer<SharedResources> localizer)
        {
            _logger = logger;
            _localizer = localizer;

        }
        public IActionResult Subscribe()
        {
            _logger.Log(LogLevel.Information, "Started Invoking subscribe page");
            return View(new ViewModel.NewsletterSubscribeViewModel());
        }

        [HttpPost]
        public IActionResult Subscribe(ViewModel.NewsletterSubscribeViewModel model)
        {
            _logger.Log(LogLevel.Information, "Started Invoking subscribe page");


            if (ModelState.IsValid)
            {
                // save data (todo: in the future)

                // redirect to /Home/Index
                string cultureString =  Request.Query["culture"].ToString();
                var cultureInfo = new CultureInfo(cultureString);

                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                return RedirectToAction(nameof(HomeController.Index), "Home");                
            }
            else
                return View(model);
        }
    }
}