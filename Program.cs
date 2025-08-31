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

        // Manual registration
        pluginManager.Register(new ResizePlugin());
        pluginManager.Register(new BlurPlugin());

        Console.WriteLine("Registered plugins: Resize, Blur\n");

        var image1 = new Image("1", "Image#1");
        var task1 = new ImageTask(image1, new List<PluginCall>
        {
            new PluginCall { PluginId = "resize", Parameter = new PluginParameter { Name = "width", Value = 100 } },
            new PluginCall { PluginId = "blur", Parameter = new PluginParameter { Name = "radius", Value = 5 } }
        });

        var processor = new ImageProcessor(pluginManager);

        Console.WriteLine("Processing task with all plugins:");
        processor.Process(new[] { task1 });

        Console.WriteLine("\nRemoving 'blur' plugin...");
        pluginManager.Remove("blur");

        Console.WriteLine("\nProcessing task after removing 'blur':");
        processor.Process(new[] { task1 });

        try
        {
            var json = System.IO.File.ReadAllText("./Config/plugins.json");
            var enabledPluginIds = PluginManager.LoadFromJson(json);

            foreach (var id in enabledPluginIds)
            {
                if (id == "resize") pluginManager.Register(new ResizePlugin());
                if (id == "blur") pluginManager.Register(new BlurPlugin());
                if (id == "grayscale") pluginManager.Register(new GrayscalePlugin());
            }

            var image2 = new Image("2", "Image#2"); 
            var task2 = new ImageTask(image2, new List<PluginCall>
            {
                new PluginCall { PluginId = "resize", Parameter = new PluginParameter { Name = "width", Value = 100 } },
                new PluginCall { PluginId = "blur", Parameter = new PluginParameter { Name = "radius", Value = 5 } },
                new PluginCall { PluginId = "grayscale" }
            });

            Console.WriteLine("\nProcessing task with all plugins (from JSON):");
            processor.Process(new[] { task2 });

            Console.WriteLine("\nRemoving 'resize' plugin...");
            pluginManager.Remove("resize");

            Console.WriteLine("\nProcessing task after removing 'resize':");
            processor.Process(new[] { task2 });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load plugins from JSON: " + ex.Message);
        }

        Console.WriteLine("\nTask processed. Press any key to exit...");
        Console.ReadKey();
    }
}
