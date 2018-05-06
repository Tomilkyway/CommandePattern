using System;

namespace CommandePattern
{
    class Program {
        
        static void Main(string[] args) {
            DBManageWithCommand dBManageWithCommand = new DBManageWithCommand();

            Menu menu = new Menu(dBManageWithCommand, dBManageWithCommand.dataBaseContext);
            menu.displayMenu();
        }
    }
}
