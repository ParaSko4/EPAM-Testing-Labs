using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace PageObject.Pages
{
    public class FlightsPage
    {
        private readonly IWebDriver driver;
        private bool check_Page = false;

        private IWebElement input_From
        {
            get
            {
                if (check_Page)
                {
                    return FindElement("div > input", "-origin-airport");
                }
                else
                {
                    return FindElement("div > input", "-origin");
                }
            }
        }

        private IWebElement input_To
        {
            get
            {
                if (check_Page)
                {
                    return FindElement("div > input", "destination-airport");
                }
                else
                {
                    return FindElement("div > input", "destination");
                }
            }
        }

        private IWebElement display_inputFrom
        {
            get
            {
                return FindElement("div", "-origin-airport-display");
            }
        }

        private IWebElement display_inputTo
        {
            get
            {
                return FindElement("div", "destination-airport-display");
            }
        }

        private IWebElement body
        {
            get
            {
                return driver.FindElement(By.CssSelector("Body"));
            }
        }

        private IWebElement button_Search
        {
            get
            {
                if (check_Page)
                {
                    return FindElement("div", "col-button-wrapper").FindElement(By.CssSelector("button"));
                }
                else
                {
                    return driver.FindElement(By.ClassName("buttonBlock")).FindElement(By.CssSelector("button"));
                }
            }
        }

        public string get_messageError
        {
            get
            {
                return FindElement("ul", "messages").FindElement(By.XPath("li/ul/li")).Text;
            }
        }

        public FlightsPage(IWebDriver driver)
        {
            this.driver = driver;
            if (FindElement("div > input", "-origin") == null)
            {
                check_Page = true;
            }
        }


        public void InputFromValue(string value)
        {
            if (check_Page)
            {
                display_inputFrom.Click();
            }
            else
            {
                input_From.Click();
            }

            input_From.SendKeys(value);
            input_From.Click();
        }

        public void InputToValue(string value)
        {
            if (check_Page)
            {
                body.Click();
                display_inputTo.Click();
                input_To.SendKeys("Стамбул");

                display_inputFrom.Click();
            }
            else
            {
                input_To.Click();
                input_To.SendKeys("Стамбул");

                input_From.Click();
            }
        }

        public void PressSearch()
        {
            button_Search.Click();
        }

        private IWebElement FindElement(string attribute, string name)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector(attribute));
            Regex findByCharptName = new Regex($@"\w*{name}$");

            for (int i = 0; i < elements.Count; i++)
            {
                if (findByCharptName.Match(elements[i].GetAttribute("id")).Success && elements[i].Enabled)
                {
                    return elements[i];
                }
            }
            return null;
        }
    }
}
