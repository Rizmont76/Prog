using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo read about list var list = new List<>()
            var dict = new Dictionary<string, long>();
          

            ShowContent(@"F:\Games", dict);
            var result = dict.OrderByDescending(i => i.Value);

            foreach (KeyValuePair<string, long> kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            } 

            Console.Read();
        }

        public static void ShowContent(string path, Dictionary<string, long> extensionsDictionary)
        {
            var dir = new DirectoryInfo(path);

            foreach (var item in dir.GetFiles())
            {
                if (extensionsDictionary.ContainsKey(item.Extension))
                {
                    extensionsDictionary[item.Extension] += item.Length;
                }
                else
                {
                    extensionsDictionary.Add(item.Extension, item.Length);
                }

                //Console.WriteLine("-ITEM: " + item.Name);
            }

            foreach (var directory in dir.GetDirectories())
            {
                //Console.WriteLine("==========DIR========== " + directory.Name);

                ShowContent(directory.FullName, extensionsDictionary);
            }
            

        }

        
    }
}