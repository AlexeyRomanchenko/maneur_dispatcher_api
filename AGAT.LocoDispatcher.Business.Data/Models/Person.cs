using System;
using System.Collections.Generic;

namespace AGAT.LocoDispatcher.Data.Models
{
    delegate void Message();
    public static class Main
    {
        public static void MainMethod()
        {
            Action message;
            Developer dev = new Developer();
            Person person = dev;

            Developer developer = (Developer)person;
            string result = developer.Hire();
            message = developer.LayOff;
            Person user = dev as Person;

            Person alex = new Developer();
            string res = alex.Hire();
            message();
        }
    }
    internal abstract class Person
    {
        internal int Age { get; set; }
        internal int Name { get; set; }
        internal virtual string Hire()
        {
            return "Hired";
        }
    }

    internal class Developer : Person
    {
        event Message SendMessage;
        internal string Position { get; set; }
        internal IEnumerable<string> Skills { get; set; }
        internal new string Hire()
        {
            string baseResult = base.Hire();
            return $"Lucky {baseResult}";
        }
        internal string GetCurrentProject()
        {
            return "some app";
        }
        internal void LayOff()
        {
            SendMessage();
            Console.WriteLine("was fired");
        }
    }
}
