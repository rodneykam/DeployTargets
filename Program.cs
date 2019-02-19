using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DeployCenter
{
    public class Program
    {
        public class DeployServer
        {
            public string Name {get; set;}
        }
        
        public class DeployTarget
        {
            public string Domain {get; set;}
            public List<DeployServer> Servers {get; set;}
        }

        public class DeployTargetList
        {
            public List<DeployTarget> DeployTargets {get; set;}
        }

        public static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\rokam\Documents\projects\DeployCenter\DeployTarget.json");

            var dt = JsonConvert.DeserializeObject<DeployTargetList>(text);

            var dict = new Dictionary<string, List<DeployServer>>();
            for(var i = 0; i < dt.DeployTargets.Count; i++ )
            {
                dict.Add(dt.DeployTargets[i].Domain,dt.DeployTargets[i].Servers);
            }
            dt = null;  // 

            var servers = dict["Demo"];
            foreach(var s in servers)
            {
                Console.WriteLine(s.Name);
            }
        }
    }
}
