using System;

namespace HelloWorld.CustomWriters
{
    internal class FileWriter : ICustomWriter
    {
        public void WriteLine(string text)
        {
            // assume this method writes to a file
            Console.WriteLine($"writing {text} to file");            
        }
    }
}