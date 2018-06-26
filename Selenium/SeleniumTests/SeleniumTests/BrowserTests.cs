﻿using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace SeleniumTests
{
    public static class BrowserTests
    {
        public static void ChromeLoginOnTestPage(string name)
        {
            using (var chrome = new ChromeDriver())
            {
                LoginOnTestPage(chrome, name);
            }
        }

        public static void FirefoxLoginOnTestPage(string name)
        {
            using (var firefox = new FirefoxDriver())
            {
                LoginOnTestPage(firefox, name);
            }
        }

        public static void IeLoginOnTestPage(string name)
        {
            using (var edge = new EdgeDriver())
            {
                LoginOnTestPage(edge, name);
            }
        }

        public static void LoginOnTestPage(
            RemoteWebDriver driver, 
            string screenshotName)
        {
            // Go to the home page
            driver.Navigate().GoToUrl("http://testing-ground.scraping.pro/login");

            // Get the page elements
            var userNameField = driver.FindElementById("usr");
            var userPasswordField = driver.FindElementById("pwd");
            var loginButton = driver.FindElementByXPath("//input[@value='Login']");

            // Type user name and password
            userNameField.SendKeys("admin");
            userPasswordField.SendKeys("12345");

            // and click the login button
            loginButton.Click();
            Thread.Sleep(2000);

            // Extract the text and save it into result.txt
            var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
            File.WriteAllText(screenshotName + ".txt", result);

            // Take a screenshot and save it into screen.png
            driver.GetScreenshot().SaveAsFile(screenshotName + ".png");
        }
    }
}
