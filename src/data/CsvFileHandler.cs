using System.Text.RegularExpressions;

public class CsvFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath) {
        List<String> characterCsvData = File.ReadAllLines(filePath).ToList();
        characterCsvData.RemoveAt(0); // Remove header row before creating Character objects

        List<Character> characters = new List<Character>();

        foreach (string line in characterCsvData) {
            try
            {
                var characterDetails = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                characters.Add(new Character(characterDetails[0], characterDetails[1], int.Parse(characterDetails[2]), int.Parse(characterDetails[3]), characterDetails[4].Split("|")));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown: {e}");
            }
        }

        return characters;
    }
    
    public void WriteCharacters(string filePath, List<Character> characters) { 
        using (StreamWriter sw = new StreamWriter("input.csv", false))
        {
            // Add header row before adding character rows
            sw.WriteLine(string.Join(',', Character.GetHeaders()));
            foreach (Character character in characters)
            {
                sw.WriteLine($"{character.Name},{character.Class},{character.Level},{character.Hitpoints},{string.Join("|", character.Equipment)}");
            }
        }
    }
}