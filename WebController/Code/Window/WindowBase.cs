using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebController.Code.Window
{
    public abstract class WindowBase
    {
        protected IWebDriver driver;

        public void GoTo(WindowProperty property)
        {
            driver.Navigate().GoToUrl(property.Pattern);
        }

        public void WriteTo(WindowProperty property, String message)
        {
            Find(property).SendKeys(message);
        }

        public void Click(WindowProperty property)
        {
            Find(property).Click();
        }

        public void Select(WindowProperty property, String selectText)
        {
            new SelectElement(Find(property)).SelectByText(selectText);
        }

        public string GetText(WindowProperty property)
        {
            return Find(property).Text;
        }

        public IEnumerable<String> GetTexts(WindowProperty property)
        {
            return FindAll(property).Select(i => i.Text);
        }

        public void Close(WindowProperty property)
        {
            driver.Close();

        }

        private IWebElement Find(WindowProperty property)
        {
            switch (property.SearchType)
            {
                case WindowPropertySearchType.Id:
                    return driver.FindElement(By.Id(property.Pattern));
                case WindowPropertySearchType.Name:
                    return driver.FindElement(By.Name(property.Pattern));
                case WindowPropertySearchType.Class:
                    return driver.FindElement(By.ClassName(property.Pattern));
                case WindowPropertySearchType.Selector:
                    return driver.FindElement(By.CssSelector(property.Pattern));

                default:
                    throw new NotFoundException("Search doesn't have type property");

            }
        }

        private IEnumerable<IWebElement> FindAll(WindowProperty property) 
        {
            switch (property.SearchType)
            {
                case WindowPropertySearchType.Id:
                    return driver.FindElements(By.Id(property.Pattern));
                case WindowPropertySearchType.Name:
                    return driver.FindElements(By.Name(property.Pattern));
                case WindowPropertySearchType.Class:
                    return driver.FindElements(By.ClassName(property.Pattern));
                case WindowPropertySearchType.Selector:
                    return driver.FindElements(By.CssSelector(property.Pattern));

                default:
                    throw new NotFoundException("Search doesn't have type property");

            }
        }

    }
}
