using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLouTests
{

    public static class ExtensionMethods
    {
        public static void ClickViaJavaScript(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)driver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            javaScriptExecutor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
