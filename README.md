# Company Web Page

## Introduction
You are creating a website for a company that provides two simple subpages:
- a site with information about the company,
- a page that allows users to subscribe to the newsletter.
Both pages can be displayed in English or in Spanish depending on the user's culture.
Your task is to complete the implementation as required below.

## Requirements
- **You cannot change anything** in the `HomeController.cs`, `NewsletterController.cs`, `Index.cshtml`, `Index.es.cshtml`, `Subscribe.cshtml`, or `Subscribe.es.cshtml`.
- **You can change the CompanyWebPage.Resources.csproj (project with resources) if it is required. Other .csproj files are read only!**.
- The main page should be available at `/` or `/about` (the `Index` action from the `HomeController` should be called).
	- The main page should be localized based on the user’s culture recognized with `accept-language` (from the request header) or `?culture=` (from the request URL, for example, `/about?culture=es`).
		- The `accept-language` is more important than `?culture=`!
		- If the user’s culture is Spanish, the `Index.es.cshtml` should be used or otherwise the `Index.cshtml` should be used.	
		- Only `es` (Spanish) and `en` (English) cultures should be supported. If other culture is recognized, the `en` culture should be used.

- The page where all users can subscribe to the newsletter should be available at `/newsletter` (the `Subscribe` action from the `NewsletterController` should be called).
	- The page should be localized based on the user’s culture recognized with `accept-language` (from the request header) or `?culture=` (from the request URL, for example, `/newsletter?culture=es`).
		- The `accept-language` is more important than `?culture=`!
		- If the user’s culture is Spanish the `Subscribe.es.cshtml` should be used or otherwise the `Subscribe.cshtml` should be used.	
		- Only `es` (Spanish) and `en` (English) culture should be supported. If other culture is recognized, the `en` culture should be used.

- The `/newsletter` should display a form that allows users to subscribe to the newsletter. Please find below the requirements for the page:
	- *Remember: you cannot change the Subscribe.cshtml and the Subscribe.es.cshtml.*
	- The labels for fields in the html form (see the `Subscribe.cshtml` or the `Subscribe.es.cshtml`) should be taken accordingly from: 
		- the label for `Age` from the `SharedResources.YourAge` resource, 
		- the label for `EmailAddress` from the `SharedResources.YourEmailAddress` resource, 
		- the label for `FirstName` from the `SharedResources.YourFirstName` resource,  
		- when the user’s culture is `es`, the `SharedResources.es.resx` should be used, otherwise the `SharedResources.resx` should be used.
	- The validations rules for fields should be defined:
		- *Remember: you cannot change the NewsletterController.*
		- *Hint: validation should be done automatically.*
		- *Hint: validation errors are displayed using the @Html.ValidationSummary(), so you do not need to implement it!*
		- The `Age` is required and should be between 1 and 99, otherwise the error from the `SharedResources.AgeIsIncorrect` should be displayed. 
		- The `FirstName` is required. If this field is empty, the error from the `SharedResources.FirstNameCanNotBeEmpty` should be displayed. 
		- The `EmailAddress` is required. If this field is empty, the error from the `SharedResources.EmailCanNotBeEmpty` should be displayed (email address format validation is not required, so you do not need to implement it). 
		- When the user’s culture is `es`, the `SharedResources.es.resx` should be used, otherwise the `SharedResources.resx` should be used.

- When the user puts an URL other than `/`, `/about`, `/newsletter`, `/error` (for example, `/about123`), the `/error` page should be called (the `Error` action from the `HomeController`).

- All action calls on controllers should be logged with the `Log` function from the `IActionLogger`. 
	- The implementation of the `IActionLogger` should be always injected. An instance of the `IActionLogger` is registered in the `Startup.ConfigureServices`. 
		By default, it is a `FakeActionLogger`, but tests and production can have their own implementation. Remember about it when you want to get an instance of the `IActionLogger`!
	- The `IActionLogger.Log` method parameters are described in the code.

## Hints
1. Your solution should pass all tests.
2. **To run all tests, you may need to run Visual Studio with administrator privileges.**
