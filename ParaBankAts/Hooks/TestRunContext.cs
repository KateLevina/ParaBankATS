﻿using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace ParaBankAts.Hooks
{
    public static class BrowserType
    {
        public const int Chrome = 1;
    }

    [TestFixture]
    public static class TestRunContext
    {
        public static IConfigurationRoot Config { get; private set; }

        static TestRunContext()
        {
            Config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                   .Build();
        }

        public static void Initialise()
        {
            Initialise(BrowserType.Chrome);
        }

        public static void WindowSetup()
        {
            Driver.Navigate().GoToUrl("http://localhost:8080/parabank");
            Driver.Manage().Window.Maximize();
        }

        #region Browser Types
        public static void Initialise(int browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    SetupChromeDriver();
                    break;
                default:
                    SetupChromeDriver();
                    break;
            }
        }
        #endregion // Browser Types

        #region Local Browsers and Setup
        private static void SetupChromeDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();

            options.SetLoggingPreference(LogType.Browser, LogLevel.Info);
            options.AddArgument("no-sandbox");
            if (bool.Parse(Config["isHeadless"]))
            {
                options.AddArgument("--headless");
            }
            Driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(30));
        }
        #endregion //Local Browsers
    
        public static IWebDriver Driver { get; private set; }

        public static string Location
        {
            get
            {
#if TEST_LOCAL
                return TestRunLocation.Local;
#else
                return TestRunLocation.Remote;
#endif
            }
        }
    }

    internal static class TestRunLocation
    {
        public const string Local = "TestLocal";
        public const string Remote = "TestRemote";
    }
}