using System;
namespace HelloWorld.CustomWriters
{
    public static class WriterFactory
    {
        public static ICustomWriter createWriter(string type = "console")
        {
            ICustomWriter writer = null;
            type = type.ToLower();
            if (type.Equals("console") | type.Equals(""))
            {
                writer = new ConsoleWriter();
            } else if (type.Equals("database"))
            {
                writer = new DatabaseWriter();
            } else if (type.Equals("file"))
            {
                writer = new FileWriter();
            }

            return writer;
        }
    }
}
