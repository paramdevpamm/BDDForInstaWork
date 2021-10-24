using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Selenium.Support;

namespace Selenium.Pages
{
    public class CheckOut : TestPage
    {
        public CheckOut(IWebDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.Home;
            Url = "http://automationpractice.com/index.php";
        }

        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
               new Locator(Element.checkOut, By.XPath("//button[normalize-space()='Check out']")),
            };
        }


    }
}
