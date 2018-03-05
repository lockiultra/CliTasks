using System;
using System.Collections.Generic;

namespace Test
{
    public class Task
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Deadline { get; private set; }
        public List<string> Tags { get; private set; }

        public Task()
        {

        }

        public Task(string Title, string Description, DateTime Deadline, List<string> Tags)
        {
            this.Title = Title;
            this.Description = Description;
            this.Deadline = Deadline;
            this.Tags = Tags;
        }
    }
}
