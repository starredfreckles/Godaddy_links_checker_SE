using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Godaddy_links_checker_SE
{
    public partial class Form1 : Form
    {
        private List<(string market, string language)> godaddyMarkets = new List<(string, string)>
        {
            ("es-AR", "//*[@id='id-marketSelector']/div[2]/div/ul/li[1]/a"),
            ("en-AU", "//*[@id='id-marketSelector']/div[2]/div/ul/li[2]/a"),
            ("nl-BE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[3]/a"),
            ("fr-BE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[4]/a"),
            ("pt-BR", "//*[@id='id-marketSelector']/div[2]/div/ul/li[5]/a"),
            ("en-CA", "//*[@id='id-marketSelector']/div[2]/div/ul/li[6]/a"),
            ("fr-CA", "//*[@id='id-marketSelector']/div[2]/div/ul/li[7]/a"),
            ("es-CL", "//*[@id='id-marketSelector']/div[2]/div/ul/li[8]/a"),
            ("es-CO", "//*[@id='id-marketSelector']/div[2]/div/ul/li[9]/a"),
            ("da-DK", "//*[@id='id-marketSelector']/div[2]/div/ul/li[10]/a"),
            ("de-DE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[11]/a"),
            ("es-ES", "//*[@id='id-marketSelector']/div[2]/div/ul/li[12]/a"),
            ("es-US", "//*[@id='id-marketSelector']/div[2]/div/ul/li[13]/a"),
            ("fr-FR", "//*[@id='id-marketSelector']/div[2]/div/ul/li[14]/a"),
            ("en-HK", "//*[@id='id-marketSelector']/div[2]/div/ul/li[15]/a"),
            ("en-IN", "//*[@id='id-marketSelector']/div[2]/div/ul/li[16]/a"),
            ("hi-IN", "//*[@id='id-marketSelector']/div[2]/div/ul/li[17]/a"),
            ("id-ID", "//*[@id='id-marketSelector']/div[2]/div/ul/li[18]/a"),
            ("en-IE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[19]/a"),
            ("en-IL", "//*[@id='id-marketSelector']/div[2]/div/ul/li[20]/a"),
            ("it-IT", "//*[@id='id-marketSelector']/div[2]/div/ul/li[21]/a"),
            ("en-MY", "//*[@id='id-marketSelector']/div[2]/div/ul/li[22]/a"),
            ("es-MX", "//*[@id='id-marketSelector']/div[2]/div/ul/li[23]/a"),
            ("nl-NL", "//*[@id='id-marketSelector']/div[2]/div/ul/li[24]/a"),
            ("en-NZ", "//*[@id='id-marketSelector']/div[2]/div/ul/li[25]/a"),
            ("nb-NO", "//*[@id='id-marketSelector']/div[2]/div/ul/li[26]/a"),
            ("de-AT", "//*[@id='id-marketSelector']/div[2]/div/ul/li[27]/a"),
            ("en-PK", "//*[@id='id-marketSelector']/div[2]/div/ul/li[28]/a"),
            ("es-PE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[29]/a"),
            ("en-PH", "//*[@id='id-marketSelector']/div[2]/div/ul/li[30]/a"),
            ("pl-PL", "//*[@id='id-marketSelector']/div[2]/div/ul/li[31]/a"),
            ("pt-PT", "//*[@id='id-marketSelector']/div[2]/div/ul/li[32]/a"),
            ("de-CH", "//*[@id='id-marketSelector']/div[2]/div/ul/li[33]/a"),
            ("en-SG", "//*[@id='id-marketSelector']/div[2]/div/ul/li[34]/a"),
            ("en-ZA", "//*[@id='id-marketSelector']/div[2]/div/ul/li[35]/a"),
            ("fr-CH", "//*[@id='id-marketSelector']/div[2]/div/ul/li[36]/a"),
            ("sv-SE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[37]/a"),
            ("it-CH", "//*[@id='id-marketSelector']/div[2]/div/ul/li[38]/a"),
            ("tr-TR", "//*[@id='id-marketSelector']/div[2]/div/ul/li[39]/a"),
            ("en-AE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[40]/a"),
            ("en-GB", "//*[@id='id-marketSelector']/div[2]/div/ul/li[41]/a"),
            ("en-US", "//*[@id='id-marketSelector']/div[2]/div/ul/li[42]/a"),
            ("es-VE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[43]/a"),
            ("vi-VN", "//*[@id='id-marketSelector']/div[2]/div/ul/li[44]/a"),
            ("uk-UA", "//*[@id='id-marketSelector']/div[2]/div/ul/li[45]/a"),
            ("ar-AE", "//*[@id='id-marketSelector']/div[2]/div/ul/li[46]/a"),
            ("th-TH", "//*[@id='id-marketSelector']/div[2]/div/ul/li[47]/a"),
            ("ko-KR", "//*[@id='id-marketSelector']/div[2]/div/ul/li[48]/a"),
            ("zh-TW", "//*[@id='id-marketSelector']/div[2]/div/ul/li[49]/a"),
            ("zh-CN", "//*[@id='id-marketSelector']/div[2]/div/ul/li[50]/a"),
            ("ja-JP", "//*[@id='id-marketSelector']/div[2]/div/ul/li[51]/a"),
            ("zh-HK", "//a[@href='https://hk.godaddy.com/']")
        };

        public Form1()
        {
            InitializeComponent();
        }

        private async void CheckUrlsButton_Click(object sender, EventArgs e)
        {
            string baseUrl = UrlTextBox.Text.Trim(); // Delete blank spaces from URL
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                MessageBox.Show("Please enter a valid URL");
                return;
            }

            Console.WriteLine($"Provided URL: {baseUrl}"); // To verify that the URL is correct
            var (availableResults, unavailableResults) = await CheckUrlsInMarkets(baseUrl);
            DisplayResults(availableResults, unavailableResults);
        }

        private async Task<(List<string> availableResults, List<string> unavailableResults)> CheckUrlsInMarkets(string baseUrl)
        {
            List<string> availableResults = new List<string>();
            List<string> unavailableResults = new List<string>();
            ChromeOptions options = new ChromeOptions();
            // Delete headless line to see real-time execution
            // options.AddArgument("--headless");
            var driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var driverService = ChromeDriverService.CreateDefaultService(driverPath);
            IWebDriver driver = new ChromeDriver(driverService, options);

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Navigate to en-US market first
                var defaultMarket = godaddyMarkets.Find(m => m.market == "en-US");
                if (defaultMarket != default)
                {
                    try
                    {
                        Console.WriteLine($"Testing: {baseUrl}");
                        driver.Navigate().GoToUrl(baseUrl);
                        await Task.Delay(3000); // Timer to wait for the page to load
                        Console.WriteLine($"Loaded URL: {driver.Url}"); // Verify the URL after loading

                        Console.WriteLine($"Setting default market: {defaultMarket.market}");

                        var marketSelector = wait.Until(d => d.FindElement(By.XPath("//*[@id='currentMarket']")));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector);
                        wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector));
                        marketSelector.Click();
                        await Task.Delay(3000); // Timer to wait for the market list to load
                        Console.WriteLine("Market Selector Open");

                        var marketSelector2 = wait.Until(d => d.FindElement(By.XPath(defaultMarket.language)));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector2);
                        wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector2));
                        marketSelector2.Click();
                        await Task.Delay(3000); // Timer to wait for the market page to load
                        Console.WriteLine($"Default Market Selected: {defaultMarket.market}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error navigating to default market {defaultMarket.market}: {ex.Message}");
                    }
                }

                foreach (var market in godaddyMarkets)
                {
                    try
                    {
                        // Go back to the base URL before each iteration
                        driver.Navigate().GoToUrl(baseUrl);
                        await Task.Delay(3000); // Timer to wait for the page to load
                        Console.WriteLine($"Base URL reloaded: {baseUrl}");

                        Console.WriteLine($"Procesing market: {market.market}");

                        // Establecer el mercado deseado
                        var marketSelector = wait.Until(d => d.FindElement(By.XPath("//*[@id='currentMarket']")));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector);
                        wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector));
                        marketSelector.Click();
                        await Task.Delay(3000); // Timer to wait for the market list to load
                        Console.WriteLine("Market Selector Open");

                        if (market.market == "zh-HK")
                        {
                            driver.Navigate().GoToUrl("https://hk.godaddy.com/");
                            await Task.Delay(3000); // Timer to wait for the page to load
                            Console.WriteLine("Navigating to zh-HK");
                        }
                        else
                        {
                            var marketSelector2 = wait.Until(d => d.FindElement(By.XPath(market.language)));
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector2);
                            wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector2));
                            marketSelector2.Click();
                            await Task.Delay(3000); // Timer to wait for the market page to load
                            Console.WriteLine($"Market selected: {market.market}");
                        }

                        // Go back to the base URL after selecting the market
                        driver.Navigate().GoToUrl(baseUrl);
                        await Task.Delay(3000); // Timer to wait for the page to load for the selected market
                        Console.WriteLine($"Página recargada en el contexto del mercado seleccionado: {market.market}");

                        // Verify that the page loads correctly
                        var bodyElement = driver.FindElement(By.TagName("body"));
                        var dataTrackName = bodyElement.GetAttribute("data-track-name");

                        if (driver.Title.Contains("404") || (dataTrackName != null && dataTrackName.Contains("homepage")))
                        {
                            unavailableResults.Add($"{market.market}");
                            Console.WriteLine($"{market.market}");
                        }
                        else
                        {
                            availableResults.Add($"{market.market}");
                            Console.WriteLine($"{market.market}");
                        }

                        // Update results in real time
                        DisplayResults(availableResults, unavailableResults);
                    }
                    catch (Exception ex)
                    {
                        unavailableResults.Add($"Error processing the market {market.market}: {ex.Message}");
                        Console.WriteLine($"Error processing the market {market.market}: {ex.Message}");
                        continue;
                    }
                }
            }
            finally
            {
                driver.Quit();
            }

            return (availableResults, unavailableResults);
        }

        private void DisplayResults(List<string> availableResults, List<string> unavailableResults)
        {
            // Make sure interface updates are done on the main thread
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayResults(availableResults, unavailableResults)));
                return;
            }

            AvailableResultsTextBox.Clear();
            UnavailableResultsTextBox.Clear();
            AvailMarketList.Clear();
            NonAvailMarketList.Clear();

            foreach (string result in availableResults)
            {
                AvailableResultsTextBox.AppendText(result + Environment.NewLine);
                AvailMarketList.AppendText(result + ",");
            }

            foreach (string result in unavailableResults)
            {
                UnavailableResultsTextBox.AppendText(result + Environment.NewLine);
                NonAvailMarketList.AppendText(result + ",");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}