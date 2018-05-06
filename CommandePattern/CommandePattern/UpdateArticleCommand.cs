using System;
namespace CommandePattern
{
    public class UpdateArticleCommand : Command
    {

        private Article article;
        private Article newArticle;
        private DataBaseContext dataBaseContext;

        public UpdateArticleCommand(Article article, Article newArticle, DataBaseContext dataBaseContext) {
            this.dataBaseContext = dataBaseContext;
            this.article = article;
            this.newArticle = newArticle;
        }

        // Update an article. This function works in both ways
        public override void Execute() {
            Console.WriteLine("\n" + this + "\n");
            var temporaryArticle = new Article(article);
            var dataBaseArticle = dataBaseContext.Articles.Find(article.id);
            dataBaseArticle.title = newArticle.title;
            dataBaseArticle.content = newArticle.content;
            dataBaseContext.SaveChanges();
            newArticle = temporaryArticle;
        }

        // Call the Execute function because it works in both ways
        public override void UnExecute() {
            Execute();
        }

		public override string ToString() {
            return "[*** Update ***]\n This article : " + article + "\n Into this new article : " + newArticle + "";
		}
	}
}
