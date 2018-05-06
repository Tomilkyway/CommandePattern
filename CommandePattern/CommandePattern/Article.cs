using System;
namespace CommandePattern
{
    public class Article {

        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }

        public Article() {
            
        }

        public Article(Article article) {
            this.id = article.id;
            this.title = article.title;
            this.content = article.content;
        }

        public Article(String title, String content) {
            this.title = title;
            this.content = content;
        }

        public Article(Boolean boolean) {
            Console.Write("Write a title for your new article : ");
            this.title = Console.ReadLine();
            Console.Write("Write a content for your new article : ");
            this.content = Console.ReadLine();
        }

		public override string ToString() {
            return "[*** Article " + id + " ***]    [title : " + title + "] [content: " + content +"]";
		}

	}
}
