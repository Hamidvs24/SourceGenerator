using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeneratorApp.Structure
{
    public class FileHelper
    {
        public static async Task<Entity> ReadJson()
        {
            Entity entity;

            using (var r = new StreamReader(
                       "C:\\Users\\Hamid\\RiderProjects\\SourceGenerator\\GeneratorApp\\data.json"))
            {
                var json = await r.ReadToEndAsync();
                entity = JsonSerializer.Deserialize<Entity>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return entity;
        }

        public async void WriteJson(string destination)
        {
            var jsonString = JsonSerializer.Serialize(destination, new JsonSerializerOptions { WriteIndented = true });
            using (var outputFile = new StreamWriter("dataReady.json"))
            {
                await outputFile.WriteLineAsync(jsonString);
            }
        }
    }
}