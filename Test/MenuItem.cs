using System;

namespace Test
{
    public class MenuItem
    {
        public string Label { get; set; }
        public Func<bool> Action { get => action; set => action = value; }

        private Func<bool> action;

        public MenuItem(string Label, Func<bool> Action)
        {
            this.Label = Label;
            this.Action = Action;
        }
    }
}
