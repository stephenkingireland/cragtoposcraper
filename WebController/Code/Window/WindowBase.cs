using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public void GoTo(IWindowProperty property)
        {
            driver.Navigate().GoToUrl(property.Pattern);
        }

        public void WriteTo(IWindowProperty property, String message)
        {
            Find(property).SendKeys(message);
        }

        public void Click(IWindowProperty property)
        {
            var element = Find(property);

            var jse = (IJavaScriptExecutor)driver;

            jse.ExecuteScript("arguments[0].scrollIntoView()", element);

            element.Click();
        }

        public void Select(IWindowProperty property, String selectText)
        {
            new SelectElement(Find(property)).SelectByText(selectText);
        }

        public void SelectNextPage(IWindowProperty paginationProperty)
        {
            var paginationArea = Find(paginationProperty);

            var paginationButtons = new WindowProperty() {Pattern =  "a", SearchType = WindowPropertySearchType.Selector};

            FindAll(paginationButtons, paginationArea).Last().Click();
        }

        public string GetText(IWindowProperty property)
        {
            return Find(property).Text;
        }

        public IEnumerable<String> GetTexts(IWindowProperty property)
        {
            return FindAll(property).Select(i => i.Text);
        }

        public String RunJS(String jsToRun)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            return (string)js.ExecuteScript(jsToRun);

        }


        public void Close()
        {
            driver.Close();
        }

        public bool Has(IWindowProperty property, ISearchContext subElement = null)
        {
            var items = FindAll(property, subElement);

            return items.Count() > 0;
        }

        public IWebElement Find(IWindowProperty property, ISearchContext subElement = null)
        {

            if(subElement == null)
            {
                subElement = driver;
            }

            switch (property.SearchType)
            {
                case WindowPropertySearchType.Id:
                    return subElement.FindElement(By.Id(property.Pattern));
                case WindowPropertySearchType.Name:
                    return subElement.FindElement(By.Name(property.Pattern));
                case WindowPropertySearchType.Class:
                    return subElement.FindElement(By.ClassName(property.Pattern));
                case WindowPropertySearchType.Selector:
                    return subElement.FindElement(By.CssSelector(property.Pattern));

                default:
                    throw new NotFoundException("Search doesn't have type property");

            }
        }

        public IEnumerable<IWebElement> FindAll(IWindowProperty property, ISearchContext subElement = null) 
        {

            if (subElement == null)
            {
                subElement = driver;
            }

            switch (property.SearchType)
            {
                case WindowPropertySearchType.Id:
                    return subElement.FindElements(By.Id(property.Pattern));
                case WindowPropertySearchType.Name:
                    return subElement.FindElements(By.Name(property.Pattern));
                case WindowPropertySearchType.Class:
                    return subElement.FindElements(By.ClassName(property.Pattern));
                case WindowPropertySearchType.Selector:
                    return subElement.FindElements(By.CssSelector(property.Pattern));

                default:
                    throw new NotFoundException("Search doesn't have type property");

            }

        }

    }

    public abstract class PaginationBase
    {
        protected WindowBase window;

        public PaginationBase(WindowBase window)
        {
            this.window = window;
        }

        public abstract bool NextPage();
        public abstract bool HasPagination();
        public abstract void GotoPage(string pageId);
    }
}
