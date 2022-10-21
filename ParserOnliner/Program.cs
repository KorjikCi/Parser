using HtmlAgilityPack;

public enum SiteCategory
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
        int count = 0;
        var siteLink = new Dictionary<SiteCategory, string>
        {
            {SiteCategory.It, "https://tech.onliner.by/"},
            {SiteCategory.Money, "https://money.onliner.by/"},
            {SiteCategory.Auto, "https://auto.onliner.by/"},
            {SiteCategory.House, "https://realt.onliner.by/"}
        };
        var web = new HtmlWeb();
        
        Console.WriteLine("Введите категорию сайта: ");
        Console.WriteLine("1 - Технологии");
        Console.WriteLine("2 - Кошелек");
        Console.WriteLine("3 - Авто");
        Console.WriteLine("4 - Недвижимость");
        var siteCategory = (SiteCategory)Convert.ToInt32(Console.ReadLine());
        var htmlDocument = web.Load(siteLink[siteCategory-1]);

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
                    $"//div[@class='news-tidings__item news-tidings__item_1of3 news-tidings__item_condensed '][{i}]//span[@class='news-helpers_hide_mobile-small']");
            
            Console.WriteLine(count +". "+ node.InnerText);
        }
    }
}