﻿using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
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

        public static void WpTest()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            using (var chrome = new ChromeDriver(options))
            {
                chrome.Navigate().GoToUrl("https://www.wp.pl/");
                Thread.Sleep(500);
                var rodoButton = chrome.FindElementByXPath("/html/body/div[3]/div/div[4]/div");
                rodoButton.Click();
                Thread.Sleep(500);
                var pedofilLink = chrome.FindElementByXPath("//*[@id=\"text_topnews\"]/li[4]/a");
                chrome.ExecuteScript($"scroll(0, {pedofilLink.Location.Y - 200})");

                pedofilLink.Click();
                Thread.Sleep(3000);

                var comment = chrome.FindElementByXPath(
                    "/html/body/div[2]/div/table/tbody/tr[1]/td/div[6]/div[2]/div/div[2]/div[1]/div[2]/div/div/a/div/div[1]/div");

                chrome.ExecuteScript($"scroll(0, {comment.Location.Y - 300})");
                Thread.Sleep(500);
                comment.Click();

                Thread.Sleep(500);
                var commentInput = chrome.FindElementById("text");
                chrome.ExecuteScript($"scroll(0, {commentInput.Location.Y - 200})");
                commentInput.SendKeys("Co ten PiS robi z tym krajem");

                Thread.Sleep(500);
                var nameInput = chrome.FindElementByXPath("//*[@id=\"comments\"]/div[2]/div[1]/form/div[2]/input");
                nameInput.SendKeys("Nowoczesny patriota");

                Thread.Sleep(500);
                var submitButton = chrome.FindElementByXPath("//*[@id=\"comments\"]/div[2]/div[1]/form/button");
                submitButton.Click();

                Thread.Sleep(2500);
                chrome.Quit();
            }
        }
    }
}
