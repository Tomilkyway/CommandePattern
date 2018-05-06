using System;
using System.Collections.Generic;

namespace CommandePattern
{
    public class DBManageWithCommand {
        public DataBaseContext dataBaseContext = new DataBaseContext();
        public List<Command> commandList = new List<Command>();
        public int current = 0;

        public void Redo(int levels) {
            Console.WriteLine("\n-------- Redo " + levels + " levels --------");
            for (int i = 0; i < levels; i++) {
                if (current < commandList.Count) {
                    Command command = commandList[current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels) {
            Console.WriteLine("\n-------- Undo " + levels + " levels --------");
            for (int i = 0; i < levels; i++) {
                if (current > 0) {
                    Command command = commandList[--current] as Command;
                    command.UnExecute();
                }
            }
        }

        public void CalculateCommand(Command command) {
            command.Execute();
            commandList.Add(command);
            current++;
            for (int i = commandList.Count - 1; i >= current; i--) {
                commandList.RemoveAt(i);
            }
        }

    }
}
