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

        public override void Execute() {
            Console.WriteLine("\n" + this + "\n");
            var temporaryArticle = new Article(article);
            var dataBaseArticle = dataBaseContext.Articles.Find(article.id);
            dataBaseArticle.title = newArticle.title;
            dataBaseArticle.content = newArticle.content;
            dataBaseContext.SaveChanges();
            newArticle = temporaryArticle;
        }

        public override void UnExecute() {
            Execute();
        }

		public override string ToString() {
            return "[*** Update ***]\n This article : " + article + "\n Into this new article : " + newArticle + "";
		}
	}
}
