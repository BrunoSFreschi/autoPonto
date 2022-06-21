using OpenQA.Selenium.Chrome;

string url = "https://web.whatsapp.com/";

List<string> contacts = new List<string>()
{
    "Teste bot"
};

ChromeDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl(url);
driver.Manage().Window.Maximize();

Thread.Sleep(5000);

foreach (var contact in contacts)
{
    //<div title="Caixa de texto de pesquisa" role="textbox" class="_13NKt copyable-text selectable-text" contenteditable="true" data-tab="3" dir="ltr"></div>
    var search = driver.FindElementByClassName("_13NKt");
    search.SendKeys(contact);

    search = driver.FindElementByXPath($"//spam[@title='{contact}']");
    search.Click();


}

Console.WriteLine("Hello, World!");
