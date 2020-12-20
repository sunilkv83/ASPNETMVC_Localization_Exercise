using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWebPage.Tests
{
    [TestClass]
    public class SubscribeFormPageTest : BaseTest
    {
        private string EnglishLabelAge = "Your age";
        private string EnglishLabelEmail = "Your e-mail";
        private string EnglishLabelFirstName = "Your name";
        private string SpanishLabelAge = "Tu edad";
        private string SpanishLabelEmail = "Tu e-mail";
        private string SpanishLabelFirstName = "Tu nombre";

        private string EnglishErrorAge = "Age is incorrect (1-99)";
        private string EnglishErrorEmail = "You must provide a email";
        private string EnglishErrorFirstName = "You must provide a name";
        private string SpanishErrorAge = "La edad es incorrecta (1-99)";
        private string SpanishErrorEmail = "Debes proporcionar un e-mail";
        private string SpanishErrorFirstName = "Debes proporcionar un nombre";

        [TestMethod]
        public async Task CheckSubscribeFormEnglishLabelsTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var result = await client.SendAsync(PrepareGetRequest("/newsletter", CultureEnglish));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(EnglishLabelAge));
                Assert.IsTrue(content.Contains(EnglishLabelEmail));
                Assert.IsTrue(content.Contains(EnglishLabelFirstName));
            }
        }

        /// <summary>
        /// For gernam should be english culture used.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task CheckSubscribeFormGermanLabelsTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var result = await client.SendAsync(PrepareGetRequest("/newsletter", CultureGerman));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(EnglishLabelAge));
                Assert.IsTrue(content.Contains(EnglishLabelEmail));
                Assert.IsTrue(content.Contains(EnglishLabelFirstName));
            }
        }


        [TestMethod]
        public async Task CheckSubscribeFormSpanishLabelsTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var result = await client.SendAsync(PrepareGetRequest("/newsletter", CultureSpanish));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(SpanishLabelAge));
                Assert.IsTrue(content.Contains(SpanishLabelEmail));
                Assert.IsTrue(content.Contains(SpanishLabelFirstName));
            }
        }

        [TestMethod]
        public async Task CheckSubscribeFormValidationEnglishTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var request = PreparePostRequest("/newsletter", CultureEnglish, new Dictionary<string, string> { { "Age", "0" }, { "EmailAddress", "" }, { "FirstName", "" } });
                var result = await client.SendAsync(request);

                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(EnglishErrorAge));
                Assert.IsTrue(content.Contains(EnglishErrorEmail));
                Assert.IsTrue(content.Contains(EnglishErrorFirstName));
            }
        }

        [TestMethod]
        public async Task CheckSubscribeFormValidationSpanishTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var request = PreparePostRequest("/newsletter", CultureSpanish, new Dictionary<string, string> { { "Age", "0" }, { "EmailAddress", "" }, { "FirstName", "" } });
                var result = await client.SendAsync(request);

                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(SpanishErrorAge));
                Assert.IsTrue(content.Contains(SpanishErrorEmail));
                Assert.IsTrue(content.Contains(SpanishErrorFirstName));
            }
        }
    }
}
