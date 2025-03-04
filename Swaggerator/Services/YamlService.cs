using System;
using YamlDotNet.Serialization;

namespace Swaggerator.Services
{
    public interface IYamlService
    {
        T? DeserializeYaml<T>(string yamlContent);
    }

    public class YamlService : IYamlService
    {
        private readonly IDeserializer _deserializer;

        public YamlService(IDeserializer deserializer)
        {
            _deserializer = deserializer;
        }

        public T? DeserializeYaml<T>(string yamlContent)
        {
            try 
            {
                return _deserializer.Deserialize<T>(yamlContent);
            }
            catch (Exception ex)
            {
                // In a real-world scenario, you'd use proper logging
                Console.WriteLine($"YAML Deserialization Error: {ex.Message}");
                return default;
            }
        }
    }
}