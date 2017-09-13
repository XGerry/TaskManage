using System.Collections.Generic;
using System.IO;

namespace TaskManage.Client
{
    public class AssemblyRepository
    {
        public static void AddAssembly(string assembly)
        {
            if (string.IsNullOrEmpty(assembly))
            {
                return;
            }
            var assemblies = GetAssemblies();
            assemblies.Add(assembly);
            using (StreamWriter stream = File.CreateText("../../JobAssemblies.txt"))
            {
                foreach (var assemblyName in assemblies)
                {
                    if (string.IsNullOrEmpty(assemblyName)) 
                        continue;
                    stream.WriteLine(assemblyName);
                }
            }
        }

        public static HashSet<string> GetAssemblies()
        {
            HashSet<string> assemblies = new HashSet<string>();
            using (FileStream stream = File.OpenRead("../../JobAssemblies.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        assemblies.Add(line);
                    }
                }
            }
            return assemblies;
        }

        public static void DeleteAssembly(string assembly)
        {
            var assemblies = GetAssemblies();
            assemblies.Remove(assembly);
            using (StreamWriter stream = File.CreateText("../../JobAssemblies.txt"))
            {
                foreach (var assemblyName in assemblies)
                {
                    stream.WriteLine(assemblyName);
                }
            }
        }
    }
}
