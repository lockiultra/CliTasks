using System;
using System.Collections.Generic;

namespace Test
{
    public class Menu
    {
        public List<MenuItem> menuItem { get; private set; }
        public Menu Main { get; private set; }

        public Menu(ToDoList toDo)
        {
            menuItem = new List<MenuItem>();

            menuItem.Add(new MenuItem("1. Add task", toDo.AddTask));
            menuItem.Add(new MenuItem("2. Search tasks", toDo.Find));
            menuItem.Add(new MenuItem("3. Last tasks", toDo.PrintLastTasks));
            menuItem.Add(new MenuItem("4. Download from file", toDo.DownloadFromFile));
            menuItem.Add(new MenuItem("5. Save to file", toDo.SaveToFile));
            menuItem.Add(new MenuItem("6. Exit", toDo.Exit));
        }

        private void Print()
        {
            Console.Write("To continue press Enter");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine();
            foreach (MenuItem item in menuItem)
            {
                Console.WriteLine(item.Label);
            }
            Console.Write("> ");
        }

        public void Work()
        {
            bool run = true;

            while (run)
            {
                Print();
                if (!char.TryParse(Console.ReadLine(), out char chosenOption))
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }
                foreach (MenuItem item in menuItem)
                {
                    if (chosenOption == item.Label[0])
                    {
                        run = item.Action();
                    }
                }
            }
        }
    }
}
