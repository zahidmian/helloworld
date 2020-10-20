using System;

namespace HelloWorld.CustomWriters
{
    internal class DatabaseWriter : ICustomWriter
    {
        public void WriteLine(string text)
        {
            // assume this method writes to a database
            Console.WriteLine($"writing {text} to database.");
        }
    }
}