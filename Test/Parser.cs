using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Parser
    {
        public string TitleParse(string line)
        {
            line = line.Replace(" ", string.Empty);
            line = line.Replace("Title:", string.Empty);
            return line;
        }

        public string DescParse(string line)
        {
            line = line.Replace(" ", string.Empty);
            line = line.Replace("Description:", string.Empty);
            return line;
        }

        public DateTime DateParse(string line)
        {
            line = line.Replace(" ", string.Empty);

            try
            {
                DateTime.Parse(line);
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            return DateTime.Parse(line);
        }

        public List<string> TagsParse(string line)
        {
            List<string> tags = new List<string>();

            foreach(char current in line)
            {
                
            }

            return tags;
        }
    }
}
