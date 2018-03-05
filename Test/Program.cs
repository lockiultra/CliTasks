using System;
using System.IO;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var toDoList = new ToDoList();
            Menu main = new Menu(toDoList);
            main.Work();

            Console.ReadKey(true);
        }
    }
}
