using HtmlAgilityPack;

public enum SiteCategory //Меню выбора категории для парсинга
{
    It = 0,
    Money = 1,
    Auto = 2,
    House = 3
}

public class Program
{
    public static void Main()
    {
        int count = 0; //счетчик для вывода нумерации новостей
        var siteLink = new Dictionary<SiteCategory, string> //заводим словарь, ключем выступает наш enym объявленный выше
                                                            //значением будет ссылка на категории сайта
        {
            {SiteCategory.It, "https://tech.onliner.by/"},
            {SiteCategory.Money, "https://money.onliner.by/"},
            {SiteCategory.Auto, "https://auto.onliner.by/"},
            {SiteCategory.House, "https://realt.onliner.by/"}
        };
        var web = new HtmlWeb(); //заводим переменную обозначаем, что будем парсить сайт
        
        Console.WriteLine("Введите категорию сайта: ");
        Console.WriteLine("1 - Технологии");
        Console.WriteLine("2 - Кошелек");
        Console.WriteLine("3 - Авто");
        Console.WriteLine("4 - Недвижимость");
        var siteCategory = (SiteCategory)Convert.ToInt32(Console.ReadLine());  //пользователь вводит категорию сайта
        var htmlDocument = web.Load(siteLink[siteCategory-1]); //обращаемся к словарю и передаем енам который ввел пользователь
                                                                //далее загружаем ссылку которая храниться в словаре по заданнаму ключу
                                                                //в переменную htmlDocument получаем код страницы

        //до 15
        Console.WriteLine("Введите сколько заголовков надо найти (до 15): "); 
        Console.WriteLine();
        var countHeader = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Последние " + countHeader + " статей по заданной теме: ");
        for (int i = 1; i <= countHeader; i++)
        {
            count++;
            var node = htmlDocument.DocumentNode
                .SelectSingleNode(
                    $"//div[@class='news-tidings__item news-tidings__item_1of3 news-tidings__item_condensed ']" +
                    $"[{i}]//span[@class='news-helpers_hide_mobile-small']"); //вытягиваем заголовки и выводим их в консоль
            
            Console.WriteLine(count +". "+ node.InnerText);
        }
    }
}