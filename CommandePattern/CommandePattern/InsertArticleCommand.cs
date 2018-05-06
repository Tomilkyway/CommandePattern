using System;
namespace CommandePattern
{
    public class InsertArticleCommand : Command {
        private Article article;
        private String type;
        private DataBaseContext dataBaseContext = new DataBaseContext();

        public InsertArticleCommand(Article article) {
            this.article = article;
        }

        // Insert and display article
        public override void Execute() {
            type = "Insert";
            dataBaseContext.Articles.Add(article);
            dataBaseContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

        // Delete and display article, which is the opposite of the instruction in the Execute() function
        public override void UnExecute() {
            type = "Delete";
            dataBaseContext.Articles.Remove(article);
            dataBaseContext.SaveChanges();
            Console.WriteLine("\n" + this + "\n");
        }

		public override string ToString() {
            return "[****** " + type + " Article ******] ===> " + article + "]";
		}
	}
}
