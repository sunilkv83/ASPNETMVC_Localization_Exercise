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
    public class AboutPageTest : BaseTest
    {
        private string SubscribeCharacteristicEnglishContent = "<h1 class=\"display-4\">Welcome</h1>";
        private string SubscribeCharacteristicSpanishContent = "<h1 class=\"display-4\">¡Bienvenido!</h1>";

        [TestMethod]
        public async Task CheckAboutUrlEnglishCultureInHeaderTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {      
                var result = await client.SendAsync(PrepareGetRequest("/about", CultureEnglish));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(SubscribeCharacteristicEnglishContent));               
            }
        }

        [TestMethod]
        public async Task CheckAboutUrlGermanCultureInHeaderTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var result = await client.SendAsync(PrepareGetRequest("/about", CultureGerman));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(SubscribeCharacteristicEnglishContent)); // for german culture should return english page
            }
        }

        [TestMethod]
        public async Task CheckAboutUrlEnglishCultureInUrlTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var result = await client.SendAsync(PrepareGetRequest($"/about?culture={CultureEnglish}", ""));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(SubscribeCharacteristicEnglishContent));
            }
        }

        [TestMethod]
        public async Task CheckAboutUrlSpanishCultureInHeaderTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var result = await client.SendAsync(PrepareGetRequest("/about", CultureSpanish));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(SubscribeCharacteristicSpanishContent));
            }
        }

        [TestMethod]
        public async Task CheckAboutUrlSpanishCultureInUrlTest()
        {
            using (var factory = new CustomWebApplicationFactory<CompanyWebPage.Web.Startup>())
            using (var client = factory.CreateClient())
            {
                var result = await client.SendAsync(PrepareGetRequest($"/about?culture={CultureSpanish}", ""));
                result.EnsureSuccessStatusCode();
                var content = await result.Content.ReadAsStringAsync();
                Assert.IsTrue(content.Contains(SubscribeCharacteristicSpanishContent));
            }
        }
    }
}
