using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    public class ToDoList
    {
        public List<Task> Tasks { get; private set; }

        public ToDoList()
        {
            Tasks = new List<Task>();
        }

        public bool AddTask()
        {
            Console.WriteLine("New task:");

            var reader = new ToDoListReader();
            var task = new Task(reader.ReadTitle(), reader.ReadDesc(), reader.ReadDate(), reader.ReadTags());

            Tasks.Add(task);

            return true;
        }

        public bool Find()
        {
            Console.WriteLine("Search tasks by tag:");
            string tags = Console.ReadLine();
            int count = 0;

            foreach(Task item in Tasks)
            {
                foreach(string current in item.Tags)
                {
                    if (current.Equals(tags))
                    {
                        PrintTask(item);
                        count++;
                    }
                }
            }

            if (count.Equals(0))
            {
                Console.WriteLine("No such tasks.");
            }

            return true;
        }

        public void PrintTask(Task item)
        {
            Console.WriteLine($"\tTitle: {item.Title}");
            Console.WriteLine($"\tDescription: {item.Description}");
            Console.WriteLine($"\tDeadline: {item.Deadline.ToShortDateString()}");
            int count = 1;
            Console.WriteLine("\tTags:");
            foreach (string tag in item.Tags)
            {
                Console.WriteLine($"\t\t{count}. {tag}");
                count++;
            }
            Console.WriteLine();
        }

        public bool PrintLastTasks()
        {
            if (Tasks != null && Tasks.Count != 0)
            {
                Tasks.Sort((Task x, Task y) => x.Deadline.CompareTo(y.Deadline));

                int count = 1;

                Console.WriteLine("Last tasks:");
                foreach(Task current in Tasks)
                {
                    Console.Write($"{count}. ");
                    PrintTask(current);
                    count++;
                }
            }
            else
            {
                Console.WriteLine("No tasks.");
            }

            return true;
        }

        public bool DownloadFromFile()
        {
            string path = @"";
            var parser = new Parser();
            var item = new Task();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while(reader.ReadLine() != null)
                    {
                        item = new Task(parser.TitleParse(reader.ReadLine()), parser.DescParse(reader.ReadLine()), parser.DateParse(reader.ReadLine()), parser.TagsParse(reader.ReadLine()));
                        Tasks.Add(item);
                    }
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return true;
        }

        public bool SaveToFile()
        {
            string path = @"";
            Task[] arrTasks = Tasks.ToArray();

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    for(int i = 0; i <= arrTasks.Length; i++)
                    {
                        writer.WriteLine($"{i + 1}.\tTitle: {arrTasks[i].Title}");
                        writer.WriteLine($"\tDescription: {arrTasks[i].Description}");
                        writer.WriteLine($"\tDeadline: {arrTasks[i].Deadline}");
                        Console.WriteLine("Tags:");
                        foreach(string tag in arrTasks[i].Tags)
                        {
                            int count = 1;
                            writer.WriteLine($"\t{count}. {tag}");
                        }
                    }
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return true;
        }

        public bool Exit()
        {
            return false;
        }
    }
}
