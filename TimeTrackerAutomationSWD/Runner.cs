using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using AutomationBase.BetterSelenium.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TimeTrackerAutomationSWD
{
    public static class Runner
    {
        public static ChromeDriver Driver { get; set; }
        
        public static Credentials Credentials { get; set; }
        
        public static bool IsLogged { get; set; }

        public static void Login(Credentials credentials)
        {
            Credentials = credentials;
            Driver.Navigate().GoToUrl(TimeTrackerLoginPageMetadata.LoginUrl);
            
            Driver.FindElement(By.CssSelector(TimeTrackerLoginPageMetadata.UsernameTextBoxSelector))
                .SendKeys(credentials.User);
                
            Driver.FindElement(By.CssSelector(TimeTrackerLoginPageMetadata.PasswordTextBoxSelector))
                .SendKeys(credentials.Password);
            
            Driver.FindElement(By.CssSelector(TimeTrackerLoginPageMetadata.LoginButtonSelector))
                .Click();
        }

        public static void Enter(List<Entry> entries)
        {
            entries.ForEach(EnterEntry);
        }

        private static void EnterEntry(Entry entry)
        {
            Driver.FindNeverStaleElement(By.CssSelector(TimeTrackerListPageMetadata.TrackButtonSelector))
                .Click();

            Thread.Sleep(3000);
            
            var elDate = Driver.FindNeverStaleElement(By.CssSelector(TimeTrackerFormPageMetadata.DateTextBoxSelector));
            elDate.Clear();
            elDate.SendKeys(entry.Date);

            Driver.FindNeverStaleElement(By.CssSelector(TimeTrackerFormPageMetadata.ProjectDropDownSelector))
                .SelectByText(entry.Project);

            Thread.Sleep(1500);

            Driver.FindNeverStaleElement(By.CssSelector(TimeTrackerFormPageMetadata.HoursTextBoxSelector))
                .SendKeys(entry.Hours.ToString(CultureInfo.InvariantCulture));
            
            Thread.Sleep(750);
            
            Driver.FindNeverStaleElement(By.CssSelector(TimeTrackerFormPageMetadata.AssignmentTypeDropDownSelector))
                .SelectByText(entry.AssignmentType);
            
            Thread.Sleep(750);

            //// For some reason page refreshes when I start typing, so added 2 typing events with custom typing delay
            //// and also some pauses between selection and typing events to get this working
            var byDescription = By.CssSelector(TimeTrackerFormPageMetadata.DescriptionTextBoxSelector);
            var elDescription = Driver.FindNeverStaleElement(byDescription);
            Thread.Sleep(750);
            elDescription.SendKeysWithDelay(entry.Description, 15);
            Thread.Sleep(1500);
            elDescription.Clear();
            Thread.Sleep(750);
            elDescription.SendKeysWithDelay(entry.Description, 30);
            Thread.Sleep(750);

            Driver.FindNeverStaleElement(By.CssSelector(TimeTrackerFormPageMetadata.FocalPointDropDownSelector))
                .SelectByText(entry.FocalPoint);
            
            Thread.Sleep(750);
            
            Driver.FindNeverStaleElement(By.CssSelector(TimeTrackerFormPageMetadata.AcceptButtonSelector))
                .Click();
            
            Thread.Sleep(2000);
        }
    }
}