using System;
using System.Collections.Generic;
namespace CommandePattern
{

    public class Menu {

        DBManageWithCommand dBManageWithCommand;
        DataBaseContext dataBaseContext;

        public Menu(DBManageWithCommand dBManageWithCommand, DataBaseContext dataBaseContext) {
            this.dBManageWithCommand = dBManageWithCommand;
            this.dataBaseContext = dataBaseContext;
        }

        // Display menu and allow to enter all the instructions
        public void displayMenu() {
            Console.WriteLine("\n\n******************** MENU ********************");
            Console.WriteLine("1. Display database : b (base)");
            Console.WriteLine("2. Clear database : c (clear)");
            Console.WriteLine("3. Insert article : i (insert)");
            Console.WriteLine("4. Delete article : d (delete)");
            Console.WriteLine("5. Update article : u (update)");
            Console.WriteLine("6. Undo : p (previous)");
            Console.WriteLine("7. Redo : n (next)");
            Console.WriteLine("8. Exit : q (quit)");
            Console.WriteLine("\n\n\n");

            var keyPressed = getKeyPressed();
            switch(keyPressed) {
                case 'b':
                    dBManageWithCommand.dataBaseContext.displayDataBase();
                    break;
                case 'c':
                    clearDatabase();
                    break;
                case 'i':
                    insertArticle();
                    break;
                case 'd':
                    deleteArticle();
                    break;
                case 'u':
                    updateArticle();
                    break;
                case 'p':
                    dBManageWithCommand.Undo(1);
                    break;
                case 'n':
                    dBManageWithCommand.Redo(1);
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown command, try again.");
                    displayMenu();
                    break;
            }

            displayMenu();

        }

        // Allow to get the key pressed by the user in order to launch the instruction which corresponds to it
        public char getKeyPressed() {
            Console.Write("What do you want to do ? ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine("");
            return key.KeyChar;
        }

        // Foreach in the Article table in order to delete all its elements
        public void clearDatabase() {
            foreach (Article article in dataBaseContext.Articles) {
                dataBaseContext.Articles.Remove(article);
            }
            dataBaseContext.SaveChanges();
            dBManageWithCommand.commandList = new List<Command>();
            dBManageWithCommand.current = 0;
        }

        // Insert an article with the DBManageWithCommand class
        public void insertArticle() {
            var article = new Article(true);
            dBManageWithCommand.CalculateCommand(new InsertArticleCommand(article));
        }

        // Delete an article with the DBManageWithCommand class
        public void deleteArticle() {
            dBManageWithCommand.dataBaseContext.displayDataBase();
            Console.Write("What's the id of the article you want to delete ? ");
            int id = -1;
            Int32.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("");
            Article article = dataBaseContext.Articles.Find(id);
            if (article == null) { return; }
            dBManageWithCommand.CalculateCommand(new DeleteArticleCommand(article));
        }

        // Update an article with the DBManageWithCommand class
        public void updateArticle() {
            dBManageWithCommand.dataBaseContext.displayDataBase();
            Console.Write("What's the id of the article you want to update ? ");
            int id = -1;
            Int32.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("");
            Article article = dataBaseContext.Articles.Find(id);
            if (article == null) { return; }
            var newArticle = new Article(true);
            dBManageWithCommand.CalculateCommand(new UpdateArticleCommand(article, newArticle, dataBaseContext));
        }

    }
}
