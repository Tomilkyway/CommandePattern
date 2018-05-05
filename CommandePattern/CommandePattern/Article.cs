using System;
namespace CommandePattern
{
    public class Article {

        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }

        public Article(){
            
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

		public override string ToString() {
            return "[*** Article *** ] {id : " + id + "} \n {title : " + title + "} \n {content: " + content +"} \n\n";
		}

	}
}
