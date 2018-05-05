using System;
namespace CommandePattern
{
    public class UpdateArticleCommand : Command
    {

        private Article article;
        private Article newArticle;
        private DataBaseContext dataBaseContext = new DataBaseContext();

        public UpdateArticleCommand(Article article, Article newArticle) {
            this.article = article;
            this.newArticle = newArticle;
        }

        public UpdateArticleCommand(Article article, String title = null, String content = null) {
            this.article = article;
            newArticle = new Article(article);
            newArticle.id = article.id;
            if (title != null) {
                newArticle.title = article.title;
            }
            if (content != null) {
                newArticle.content = article.content;
            }
        }

        public override void Execute() {
            Console.WriteLine("\n [*** " + this + " ***] \n");
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
