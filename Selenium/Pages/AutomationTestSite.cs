using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Selenium.Support;

namespace Selenium.Pages
{
    public class AutomationTestSite
    {
        public PageName PageName;
        public string BaseUrl;
        public IWebDriver WebDriver;
        private Collection<TestPage> Pages;

        public AutomationTestSite(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;
                default:
                    WebDriver = new ChromeDriver();
                    WebDriver.Manage().Window.Maximize();
                    break;
            }
            BaseUrl = "https://www.orbitz.com/";
            Pages = InitializePages();
        }

        private Collection<TestPage> InitializePages()
        {
            return new Collection<TestPage>
            {
                new Home(WebDriver),
                new CheckOut(WebDriver)
            };
        }

        public void GoTo(string BaseUrl)
        {
            WebDriver.Navigate().GoToUrl(BaseUrl);
        }

        public bool PageLoaded()
        {
            try
            {
                var waitForDocumentReady = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
                waitForDocumentReady.Until((wdriver) =>
                    (WebDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete"));
                return true;
            }
            catch (TimeoutException timeoutException)
            {
                return false;
            }
        }

        public TestPage GetPage(PageName pageName)
        {
            return Pages.FirstOrDefault(page => page.Name.Equals(pageName));
        }

        public bool DoesElementExistOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            try
            {
                WebDriver.FindElement(locator.FindBy);
            }
            catch (NoSuchElementException noSuchElementException)
            {
                return false;
            }
            return true;
        }

        public void ClickElementOnPage(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).Click();
            System.Threading.Thread.Sleep(5000);
        }

        public void ClickOnElementWithDynamicXpath(PageName pageName, Element element, string xpath)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(By.XPath("//button[@aria-label='" + xpath + "']")).Click();
            System.Threading.Thread.Sleep(5000);
        }

        public void EnterTextIntoInputField(PageName pageName, Element element, string text)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).SendKeys(text);
        }

        public void PressEnterKey(PageName pageName, Element element)
        {
            var locator = GetPage(pageName).GetLocator(element);
            WebDriver.FindElement(locator.FindBy).SendKeys(Keys.Enter);
        }


        public void SelectDropDownOption(PageName pageName, Element element, string optionToSelect)
        {
            var locator = GetPage(pageName).GetLocator(element);
            var selectOptionList = WebDriver.FindElement(locator.FindBy).FindElements(By.TagName("option"));
            foreach (IWebElement option in selectOptionList)
            {
                if (option.Text.Equals(optionToSelect))
                {
                    option.Click();
                    return;
                }
            }
            throw new InvalidSelectorException($"{element} option of {optionToSelect} not found");
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
