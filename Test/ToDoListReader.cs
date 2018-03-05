using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    class ToDoListReader
    {
        public ToDoListReader()
        {

        }

        public string ReadTitle()
        {
            Console.Write("\tTitle:");
            return Console.ReadLine();
        }

        public string ReadDesc()
        {
            Console.Write("\tDescription:");
            return Console.ReadLine();
        }

        public DateTime ReadDate()
        {
            bool InputDone = false;
            DateTime deadline = new DateTime();
            string line = null;
            while (!InputDone)
            {
                Console.Write("\tInput date of deadline(dd.mm.yyyy):");
                line = Console.ReadLine();

                try
                {
                    if (!DateTime.TryParse(line, out deadline))
                    {
                        throw new FormatException("\t'" + line + "' isn't date.");
                    }

                    if (deadline <= DateTime.Now)
                    {
                        throw new Exception("\tSorry, the time for this deadline has already expired.");
                    }
                    else
                    {
                        InputDone = true;
                    }
                }
                catch(FormatException Exp)
                {
                    Console.WriteLine(Exp.Message);
                }
                catch(Exception Exp)
                {
                    Console.WriteLine(Exp.Message);
                }
            }

            return deadline;
        }

        public List<string> ReadTags()
        {
            List<string> tags = new List<string>();

            int count = 0;
            string tag = null;
            bool InputDone = false;
            Console.WriteLine("\tInput tags(finish on empty line):\n");

            while(!InputDone)
            {
                Console.Write("\t\t{0}. ", count + 1);
                tag = Console.ReadLine();
                if (tag != "")
                {
                    tags.Add(tag);
                    count++;
                }
                else
                {
                    InputDone = true;
                }
            }

            return tags;
        }

        private bool isFileNameValid(string fileName)
        {
            if ((fileName == null) || (fileName.LastIndexOfAny(Path.GetInvalidPathChars()) != -1))
            {
                return false;
            }

            try
            {
                var tempFileInfo = new FileInfo(fileName);
                return true;
            }
            catch(NotSupportedException)
            {
                return false;
            }
        }

        public void ReadFromFile()
        {
            List<Task> value = new List<Task>();
            string path = @"";

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    //code here...
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
