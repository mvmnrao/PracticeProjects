using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello... This is configuration manager application");

            Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            Console.WriteLine(ConfigurationManager.AppSettings["Name"]);
            var mySection = ConfigurationManager.GetSection("CustomSection") as CustomSection;
            Console.WriteLine(mySection.TestPropertyName);
            Console.WriteLine(mySection.Location);

            var fieldMapping = ConfigurationManager.GetSection("FieldMapping") as FieldMapping;
            foreach(Field f in fieldMapping.xVelocity)
            {
                Console.WriteLine(f.MappedTo);
            }

            var dirPath = Environment.CurrentDirectory;
            ConfigurationFileMap configFileMap = new ConfigurationFileMap(Path.Combine(dirPath, @"..\..\myConfig.config"));
            Configuration myConfig = ConfigurationManager.OpenMappedMachineConfiguration(configFileMap);
            Console.WriteLine(((CustomSection)myConfig.GetSection("myConfig")).Location);
            //Below line doesn't work because, 
            //if we want AppSettings, we should either use from default configuration or we need to map new config in default config file.
            //myConfig.AppSettings["Name"];

            //WebConfigurationManager

            Console.WriteLine("I am done, press any key to exit application");
            Console.ReadKey();
        }
    }
}