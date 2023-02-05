using OpenQA.Selenium;

namespace Training_Center_Task_15.Pages
{
    public class ProductsPage : BasePage
    {
        private IWebDriver _driver;

        public ProductsPage(IWebDriver driver) : base(driver)
        {
            _driver = Driver;
        }

        public IWebElement ContinueShoppingButton => _driver.FindElement(By.CssSelector("button[class='btn btn-success close-modal btn-block']"));
        public IWebElement CartLink => _driver.FindElement(By.CssSelector("a[href='/view_cart']"));

        public CartPage ClickCartLink()
        {
            CartLink.Click();
            return new CartPage(_driver);
        }

        public CartPage ClickContinueShoppingButton()
        {
            ContinueShoppingButton.Click();
            return new CartPage(_driver);
        }

        public List<string> AddMultipleProductsToCart(int numberOfProducts)
        {
            List<string> products = new List<string>();
            int counter = 1;
            while (counter <= numberOfProducts)
            {
                IWebElement buttonProductToAdd = _driver.FindElement(By.CssSelector($"a[data-product-id='{counter}']"));
                IWebElement productPicLink = _driver.FindElement(By.CssSelector($"img[src='/get_product_picture/{counter}']"));
                string productPicName = productPicLink.GetAttribute("src");
                buttonProductToAdd.Click();
                ClickContinueShoppingButton();
                counter++;
            }
            return products;
        }

        public void ScrollToFirstProducts()
        {
            IWebElement element = _driver.FindElement(By.CssSelector("a[data-product-id='4']"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
    }
}
