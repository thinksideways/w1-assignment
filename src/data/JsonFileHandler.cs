using System.Text.Json;

public class JsonFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath)
    {
        string jsonCharacters = File.ReadAllText(filePath);
        List<Character> characters = JsonSerializer.Deserialize<List<Character>>(jsonCharacters);
        return characters;
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        using (StreamWriter sw = new StreamWriter(filePath, false))
        {
            foreach (Character character in characters)
            {
                sw.WriteLine(JsonSerializer.Serialize(characters, jsonOptions));
            }
        }
    }
}