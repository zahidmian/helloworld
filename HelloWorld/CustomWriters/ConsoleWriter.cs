using System;

namespace HelloWorld.CustomWriters
{
    public class ConsoleWriter : ICustomWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}