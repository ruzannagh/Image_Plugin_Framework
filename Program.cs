using System;
using System.Collections.Generic;
using ImagePluginFramework.Models;
using ImagePluginFramework.Plugins;
using ImagePluginFramework.Services;

class Program
{
    static void Main()
    {
        var pluginManager = new PluginManager();
        pluginManager.Register(new ResizePlugin());

        var image = new Image("1", "Image#1");

        var task = new ImageTask(image, new List<PluginCall>
        {
            new PluginCall 
            { 
                PluginId = "resize", 
                Parameter = new PluginParameter { Name = "width", Value = 100 } 
            }
        });

        var processor = new ImageProcessor(pluginManager);
        processor.Process(new[] { task });

        Console.WriteLine("Task processed. Press any key to exit...");
        Console.ReadKey();
    }
}
