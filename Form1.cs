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
            string baseUrl = UrlTextBox.Text.Trim(); // Elimina espacios en blanco alrededor
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                MessageBox.Show("Por favor, introduce una URL válida.");
                return;
            }

            Console.WriteLine($"URL proporcionada: {baseUrl}"); // Para verificar que se está obteniendo la URL correcta
            var (availableResults, unavailableResults) = await CheckUrlsInMarkets(baseUrl);
            DisplayResults(availableResults, unavailableResults);
        }

        private async Task<(List<string> availableResults, List<string> unavailableResults)> CheckUrlsInMarkets(string baseUrl)
        {
            List<string> availableResults = new List<string>();
            List<string> unavailableResults = new List<string>();
            ChromeOptions options = new ChromeOptions();
            // Eliminar la línea de headless para ver la ejecución en tiempo real
            // options.AddArgument("--headless");
            var driverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var driverService = ChromeDriverService.CreateDefaultService(driverPath);
            IWebDriver driver = new ChromeDriver(driverService, options);

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Navegar primero al mercado en-US
                var defaultMarket = godaddyMarkets.Find(m => m.market == "en-US");
                if (defaultMarket != default)
                {
                    try
                    {
                        Console.WriteLine($"Navegando a: {baseUrl}");
                        driver.Navigate().GoToUrl(baseUrl);
                        await Task.Delay(3000); // Esperar a que se cargue la página
                        Console.WriteLine($"Página cargada: {driver.Url}"); // Verifica la URL actual después de cargar

                        Console.WriteLine($"Navegando al mercado predeterminado: {defaultMarket.market}");

                        var marketSelector = wait.Until(d => d.FindElement(By.XPath("//*[@id='currentMarket']")));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector);
                        wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector));
                        marketSelector.Click();
                        await Task.Delay(3000); // Esperar a que se cargue la lista de mercados
                        Console.WriteLine("Selector de mercado abierto");

                        var marketSelector2 = wait.Until(d => d.FindElement(By.XPath(defaultMarket.language)));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector2);
                        wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector2));
                        marketSelector2.Click();
                        await Task.Delay(3000); // Esperar a que se cargue la página del mercado
                        Console.WriteLine($"Mercado predeterminado seleccionado: {defaultMarket.market}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al navegar al mercado predeterminado {defaultMarket.market}: {ex.Message}");
                    }
                }

                foreach (var market in godaddyMarkets)
                {
                    try
                    {
                        // Volver a la URL base antes de cada iteración
                        driver.Navigate().GoToUrl(baseUrl);
                        await Task.Delay(3000); // Esperar a que se cargue la página
                        Console.WriteLine($"Página principal recargada: {baseUrl}");

                        Console.WriteLine($"Procesando mercado: {market.market}");

                        // Establecer el mercado deseado
                        var marketSelector = wait.Until(d => d.FindElement(By.XPath("//*[@id='currentMarket']")));
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector);
                        wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector));
                        marketSelector.Click();
                        await Task.Delay(3000); // Esperar a que se cargue la lista de mercados
                        Console.WriteLine("Selector de mercado abierto");

                        if (market.market == "zh-HK")
                        {
                            driver.Navigate().GoToUrl("https://hk.godaddy.com/");
                            await Task.Delay(3000); // Esperar a que se cargue la página específica
                            Console.WriteLine("Navegando a la URL específica para zh-HK");
                        }
                        else
                        {
                            var marketSelector2 = wait.Until(d => d.FindElement(By.XPath(market.language)));
                            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", marketSelector2);
                            wait.Until(ExpectedConditions.ElementToBeClickable(marketSelector2));
                            marketSelector2.Click();
                            await Task.Delay(3000); // Esperar a que se cargue la página del mercado
                            Console.WriteLine($"Mercado seleccionado: {market.market}");
                        }

                        // Volver a navegar a la URL base después de seleccionar el mercado
                        driver.Navigate().GoToUrl(baseUrl);
                        await Task.Delay(3000); // Esperar a que se cargue la página en el contexto del mercado seleccionado
                        Console.WriteLine($"Página recargada en el contexto del mercado seleccionado: {market.market}");

                        // Verificar si la página se carga correctamente
                        var bodyElement = driver.FindElement(By.TagName("body"));
                        var dataTrackName = bodyElement.GetAttribute("data-track-name");

                        if (driver.Title.Contains("404") || (dataTrackName != null && dataTrackName.Contains("homepage")))
                        {
                            unavailableResults.Add($"{market.market} - No Disponible");
                            Console.WriteLine($"{market.market} - No Disponible");
                        }
                        else
                        {
                            availableResults.Add($"{market.market} - Disponible");
                            Console.WriteLine($"{market.market} - Disponible");
                        }

                        // Actualizar los resultados en tiempo real
                        DisplayResults(availableResults, unavailableResults);
                    }
                    catch (Exception ex)
                    {
                        unavailableResults.Add($"Error al procesar el mercado {market.market}: {ex.Message}");
                        Console.WriteLine($"Error al procesar el mercado {market.market}: {ex.Message}");
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
            // Asegúrate de que las actualizaciones de la interfaz se hagan en el hilo principal
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayResults(availableResults, unavailableResults)));
                return;
            }

            AvailableResultsTextBox.Clear();
            UnavailableResultsTextBox.Clear();

            foreach (string result in availableResults)
            {
                AvailableResultsTextBox.AppendText(result + Environment.NewLine);
            }

            foreach (string result in unavailableResults)
            {
                UnavailableResultsTextBox.AppendText(result + Environment.NewLine);
            }
        }
    }
}