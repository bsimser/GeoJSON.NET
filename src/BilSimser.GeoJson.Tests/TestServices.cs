using System;
using System.IO;
using System.Reflection;

namespace BilSimser.GeoJson.Tests
{
    public class TestServices
    {
        public static void CreateTextFile(string resourceName, string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) return;

            using (var reader = new StreamReader(stream))
            {
                using (var writer = File.CreateText(fileName))
                {
                    writer.Write(reader.ReadToEnd());
                }
            }   
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static string ReadFile(string path)
        {
            var output = string.Empty;

            try
            {
                using (var reader = new StreamReader(path))
                {
                    output = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }
    }
}