using Selenium.Pages;
using System;
using System.Threading;
using System.Windows.Input;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class AssignmentSteps
    {
        private AutomationTestSite automationTestSite;

        public AssignmentSteps(AutomationTestSite automationTestSite)
        {
            this.automationTestSite = automationTestSite;
        }

        [Given(@"I open the browser to (.*) on chrome")]
        public void GivenIOpenTheBrowserToOnChrome(string URL)
        {
            automationTestSite.GoTo(URL);
        }

        [When(@"I click on flight")]
        public void WhenIClickOnFlight()
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.flightTab);
        }

        [When(@"I Click on round trip")]
        public void WhenIClickOnRoundTrip()
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.roundTripOption);
        }

        [When(@"I Enter from as (.*) and destination as (.*)")]
        public void WhenIEnterFromAsAndDestinationAs(string fromLocation, string toLocation)
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.fromDestination);
            automationTestSite.EnterTextIntoInputField(PageName.Home, Element.searchPopFrom, fromLocation);
            automationTestSite.PressEnterKey(PageName.Home, Element.searchPopFrom);

            automationTestSite.ClickElementOnPage(PageName.Home, Element.toDestination);
            automationTestSite.EnterTextIntoInputField(PageName.Home, Element.searchPopTo, toLocation);
            automationTestSite.PressEnterKey(PageName.Home, Element.searchPopTo);
        }

        [When(@"Select departing date as (.*) days and returning as (.*) days from now")]
        public void WhenSelectDepartingDateAsDaysAndReturningAsDaysFromNow(int startDays, int endDays)
        {
            //expected format Nov 18, 2021
            string startDate = DateTime.Now.AddDays(startDays).ToString("MMM d, yyyy");
            string endDate = DateTime.Now.AddDays(endDays).ToString("MMM d, yyyy");
            automationTestSite.ClickElementOnPage(PageName.Home, Element.dateSelection);
            automationTestSite.ClickOnElementWithDynamicXpath(PageName.Home, Element.dateSelection, startDate);
            automationTestSite.ClickOnElementWithDynamicXpath(PageName.Home, Element.dateSelection, endDate);
            automationTestSite.ClickElementOnPage(PageName.Home, Element.doneDateSelection);
        }

        [When(@"I click on search for flights")]
        public void WhenIClickOnSearchForFlights()
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.searchFlightsButton);
            Thread.Sleep(20000);
        }

        [When(@"I select (.*) in sort dropdown")]
        public void WhenISelectInSortDropdown(string sortSelection)
        {
            automationTestSite.SelectDropDownOption(PageName.Home, Element.sortDropDown, sortSelection);
        }

        [When(@"I click on the first option")]
        public void WhenIClickOnTheFirstOption()
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.firstFlight);
        }

        [When(@"Click on continue")]
        public void WhenClickOnContinue()
        {
            automationTestSite.ClickElementOnPage(PageName.Home, Element.continueForBooking);
        }

        [Then(@"The Sign in option should be displayed")]
        public void ThenTheSignInOptionShouldBeDisplayed()
        {
            automationTestSite.DoesElementExistOnPage(PageName.Home, Element.signInButton);
        }

        [Then(@"Validate the round trip icon is displayed")]
        public void ThenValidateTheRoundTripIconIsDisplayed()
        {
            automationTestSite.DoesElementExistOnPage(PageName.Home, Element.roundTripIcon);
        }

        [Then(@"Sort dropdown should be displayed")]
        public void ThenSortDropdownShouldBeDisplayed()
        {
            automationTestSite.DoesElementExistOnPage(PageName.Home, Element.sortDropDown);
        }

        [Then(@"Check out page should be displayed with (.*) and destination as (.*)")]
        public void ThenCheckOutPageShouldBeDisplayedWithAndDestinationAs(string fromLocation, string destinationLocation)
        {
            automationTestSite.DoesElementExistOnPage(PageName.CheckOut, Element.checkOut);
        }
    }
}
