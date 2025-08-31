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
        pluginManager.Register(new BlurPlugin());

        Console.WriteLine("Registered plugins: Resize, Blur\n");

        var image = new Image("1", "Image#1");

        var task = new ImageTask(image, new List<PluginCall>
        {
            new PluginCall 
            { 
                PluginId = "resize", 
                Parameter = new PluginParameter { Name = "width", Value = 100 } 
            },
            new PluginCall 
            { 
                PluginId = "blur", 
                Parameter = new PluginParameter { Name = "radius", Value = 5 } 
            }
        });

        var processor = new ImageProcessor(pluginManager);

        Console.WriteLine("Processing task with all plugins:");
        processor.Process(new[] { task });

        Console.WriteLine("\nRemoving 'blur' plugin...");
        pluginManager.Remove("blur");

        Console.WriteLine("\nProcessing task after removing 'blur':");
        processor.Process(new[] { task });

        Console.WriteLine("\nTask processed. Press any key to exit...");
        Console.ReadKey();
    }
}
