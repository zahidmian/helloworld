using System;
using Xunit;
using HelloWorld.Controllers;
using HelloWorld.CustomWriters;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace HellowWorld.Tests
{    
    public class TestCustomWriters
    {

        [Fact]
        public void TestDefaultWriter()
        {
            // Arrane
            var to = "";
            var expected = "HelloWorld.CustomWriters.ConsoleWriter";

            // Act
            var writer = WriterFactory.createWriter(to);

            // Assert
            Assert.Equal(expected, writer.GetType().ToString());
        }

        [Fact]
        public void TestConsole()
        {

            // Arrane
            var to = "console";
            var expected = "HelloWorld.CustomWriters.ConsoleWriter";

            // Act
            var writer = WriterFactory.createWriter(to);

            // Assert
            Assert.Equal(expected, writer.GetType().ToString());
        }

        [Fact]
        public void TestConsoleMixCase()
        {

            // Arrane
            var to = "Console"; // Title case
            var expected = "HelloWorld.CustomWriters.ConsoleWriter";

            // Act
            var writer = WriterFactory.createWriter(to);

            // Assert
            Assert.Equal(expected, writer.GetType().ToString());
        }

        [Fact]
        public void TestDatabase()
        {
            // Arrane
            var to = "database";
            var expected = "HelloWorld.CustomWriters.DatabaseWriter";

            // Act
            var writer = WriterFactory.createWriter(to);

            // Assert
            Assert.Equal(expected, writer.GetType().ToString());
        }

        [Fact]
        public void TestFile()
        {
            // Arrane
            var to = "file";
            var expected = "HelloWorld.CustomWriters.FileWriter";

            // Act
            var writer = WriterFactory.createWriter(to);

            // Assert
            Assert.Equal(expected, writer.GetType().ToString());
        }
    }
}
