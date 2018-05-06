using System;
namespace CommandePattern
{
    public class DeleteArticleCommand : Command {

        private Article article;
        private String type;
        private DataBaseContext dataBaseContext = new DataBaseContext();

        public DeleteArticleCommand(Article article) {
            this.article = article;
        }

        // Delete and display an article
        public override void Execute() {
            type = "Delete";
            dataBaseContext.Articles.Remove(article);
            dataBaseContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

        // Insert and display article, which is the opposite of the instruction in the Execute() function
        public override void UnExecute() {
            type = "Insert";
            dataBaseContext.Articles.Add(article);
            dataBaseContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

		public override string ToString() {
            return "[****** " + type + " Article ******] ===> " + article + "]";
		}
	}
}
