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

        public override void Execute() {
            type = "Delete";
            dataBaseContext.Articles.Add(article);
            dataBaseContext.SaveChanges();
            Console.WriteLine("\n [*** " + this + " ***] \n");
        }

        public override void UnExecute() {
            type = "Insert";
            dataBaseContext.Articles.Add(article);
            dataBaseContext.SaveChanges();
            Console.WriteLine("\n [*** " + this + " ***] \n");
        }

		public override string ToString() {
            return "[*** " + type + " Article : " + article + " ***]";
		}
	}
}
