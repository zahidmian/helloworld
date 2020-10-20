using System;
using Xunit;
using HelloWorld.Controllers;
using HelloWorld.CustomWriters;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace HellowWorld.Tests
{    
    public class TestWeatherForecastController2
    {
        [Fact]
        public void TestWithoutConfig()
        {
            // Arrange
            var controller = new HelloController(configuration: null);
            Assert.Equal(1, 1);
            var sampleText = "Hello World";
            var writeTo = "console";

            var body = $"{{\"text\": \"{sampleText}\",\"writeTo\": \"{writeTo}\"}}";

            var elem = JsonDocument.Parse(body);
            var result = controller.Post(elem.RootElement);

            // Act
            var s = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;

            // Assert
            Assert.Equal($"\"{sampleText}\" was written to HelloWorld.CustomWriters.ConsoleWriter", s);
        }

        [Fact]
        public void TestWithConfig()
        {
            // Arange
            var config = new Dictionary<string, string>();
            config.Add("DefaultWriter", "console");
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(config).Build();
            var controller = new HelloController(configuration: configuration);

            var sampleText = "Hello World";
            var writeTo = "console";
            var body = $"{{\"text\": \"{sampleText}\",\"writeTo\": \"{writeTo}\"}}";
            var elem = JsonDocument.Parse(body);
            var result = controller.Post(elem.RootElement);

            // Act
            var s = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;

            // Assert
            Assert.Equal($"\"{sampleText}\" was written to HelloWorld.CustomWriters.ConsoleWriter", s);
        }

        [Fact]
        public void TestWithoutText()
        {
            // Arange
            var config = new Dictionary<string, string>();
            config.Add("DefaultWriter", "console");
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(config).Build();
            var controller = new HelloController(configuration: configuration);

            var sampleText = "Hello World";
            var writeTo = "console";
            var body = $"{{\"textkeyiswrong\": \"{sampleText}\",\"writeTo\": \"{writeTo}\"}}";
            var elem = JsonDocument.Parse(body);
            var result = controller.Post(elem.RootElement);

            // Act
            var r = ((Microsoft.AspNetCore.Mvc.BadRequestObjectResult)result);

            // Assert
            Assert.Equal(400, r.StatusCode);
            Assert.Equal("text is required", r.Value);

        }

        [Fact]
        public void TestWithConfigFile()
        {
            // Arange
            var config = new Dictionary<string, string>();
            config.Add("DefaultWriter", "file");
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(config).Build();
            var controller = new HelloController(configuration: configuration);

            var sampleText = "Hello World";
            var body = $"{{\"text\": \"{sampleText}\"}}";
            var elem = JsonDocument.Parse(body);
            var result = controller.Post(elem.RootElement);

            // Act
            var s = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;

            // Assert
            Assert.Equal($"\"{sampleText}\" was written to HelloWorld.CustomWriters.FileWriter", s);
        }

        [Fact]
        public void TestWithApiOverride()
        {
            // the config setting is file, but the client wants to write to console
         
            // Arange
            var config = new Dictionary<string, string>();
            config.Add("DefaultWriter", "file");
            var configuration = new ConfigurationBuilder().AddInMemoryCollection(config).Build();
            var controller = new HelloController(configuration: configuration);

            var sampleText = "Hello World";
            var writeTo = "console";
            var body = $"{{\"text\": \"{sampleText}\",\"writeTo\": \"{writeTo}\"}}";
            var elem = JsonDocument.Parse(body);
            var result = controller.Post(elem.RootElement);

            // Act
            var s = ((Microsoft.AspNetCore.Mvc.OkObjectResult)result).Value;

            // Assert
            Assert.Equal($"\"{sampleText}\" was written to HelloWorld.CustomWriters.ConsoleWriter", s);
        }
    }
}
