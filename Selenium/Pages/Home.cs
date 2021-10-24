using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Selenium.Support;

namespace Selenium.Pages
{
    public class Home : TestPage
    {
        public Home(IWebDriver webDriver)
        {
            Setup(webDriver);
            Name = PageName.Home;
            Url = "http://automationpractice.com/index.php";
        }

        protected sealed override Collection<Locator> InitializeLocators()
        {
            return new Collection<Locator>
            {
                new Locator(Element.signInButton, By.XPath("//button[normalize-space()='Sign in']")),
                new Locator(Element.flightTab, By.XPath("//a[@href='?pwaLob=wizard-flight-pwa']")),
                new Locator(Element.roundTripOption, By.XPath("//a[@href='?flightType=roundtrip']")),
                new Locator(Element.fromDestination, By.XPath("//button[@aria-label='Leaving from']")),
                new Locator(Element.searchPopFrom, By.Id("location-field-leg1-origin")),
                new Locator(Element.toDestination, By.XPath("//button[@aria-label='Going to']")),
                new Locator(Element.searchPopTo, By.Id("location-field-leg1-destination")),
                new Locator(Element.dateSelection, By.XPath("//button[@id='d1-btn']")),
                new Locator(Element.doneDateSelection, By.CssSelector(".dialog-done")),
                new Locator(Element.roundTripIcon, By.XPath("//button[@aria-label='Swap origin and destination']//*[name()='svg']")),
                new Locator(Element.searchFlightsButton, By.CssSelector(".uitk-layout-grid-item > .uitk-button")),
                new Locator(Element.sortDropDown, By.XPath("//select[@id='listings-sort']")),
                new Locator(Element.firstFlight, By.XPath("//button[@data-test-id='select-link']")),
                new Locator(Element.continueForBooking, By.XPath("//button[@data-test-id='select-button']")),
            };
        }


    }
}
