using OpenQA.Selenium;

namespace Training_Center_Task_15.Pages
{
    public class CartPage : BasePage
    {
        private IWebDriver _driver;

        public CartPage(IWebDriver driver) : base(driver)
        {
            _driver = Driver;
        }

        public IWebElement ProductTable => _driver.FindElement(By.Id("cart_info_table"));

        public List<string> GetProductsFromCart()
        {
            List<string> products = new List<string>();
            List<IWebElement> allProducts = ProductTable.FindElements(By.TagName("img")).ToList();
            foreach (IWebElement product in allProducts)
            {
                string photoURL = product.GetAttribute("src");
                products.Add(photoURL);
            }
            return products;
        }
    }
}
