using OpenQA.Selenium.Chrome;

string url = "https://web.whatsapp.com/";

List<string> contacts = new List<string>()
{
    "Teste bot" //Nome do contato ou grupo que sera pesquisado.
};

ChromeDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl(url);
driver.Manage().Window.Maximize();

Thread.Sleep(5000);

foreach (var contact in contacts)
{
    var search = driver.FindElementByClassName("_13NKt"); //Usa a classe da mensagem que esta na caixa de pesquisa.
    search.SendKeys(contact);

    search = driver.FindElementByXPath($"//spam[@title='{contact}']");
    search.Click();
}
