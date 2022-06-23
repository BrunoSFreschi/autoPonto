using OpenQA.Selenium.Chrome;

string url = "https://web.whatsapp.com/";

List<string> contacts = new List<string>()
{
    "Contact test"
};

ChromeDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl(url);
driver.Manage().Window.Maximize();

Thread.Sleep(8000);

try
{
    foreach (var contact in contacts)
    {
        //<div title="Caixa de texto de pesquisa" role="textbox" class="_13NKt copyable-text selectable-text" contenteditable="true" data-tab="3" dir="ltr"></div>
        var search = driver.FindElementByClassName("_13NKt");
        search.SendKeys(contact);

        //span dir="auto" title="Contact in var conctacts"
        search = driver.FindElementByXPath($"//spam[@title='{contact}']");
        search.Click();

        //<div title="Mensagem" role="textbox" class="_13NKt copyable-text selectable-text" contenteditable="true" data-tab="10" dir="ltr" spellcheck="true"></div>
        var message = driver.FindElementByClassName("_13NKt");
        message.SendKeys("Mensagem teste.");

        //<span data-testid="send" data-icon="send" class=""><svg viewBox="0 0 24 24" width="24" height="24" class=""><path fill="currentColor" d="M1.101 21.757 23.8 12.028 1.101 2.3l.011 7.912 13.623 1.816-13.623 1.817-.011 7.912z"></path></svg></span>
        var send = driver.FindElementByXPath($"//span[@data-testid='send']");
        send.Click();
    }
}
catch (Exception)
{
    Console.WriteLine("Wrong URL");
    driver.Quit();
}
