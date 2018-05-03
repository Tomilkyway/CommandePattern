using System;

namespace CommandePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBaseContext dataBaseContext = new DataBaseContext();
            Article article = new Article();
            article.title = "First Title";
            dataBaseContext.Articles.Add(article);
            dataBaseContext.SaveChanges();
        }
    }
}
