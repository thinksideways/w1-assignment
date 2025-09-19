using System.Text.RegularExpressions;

public class CsvFileHandler : IFileHandler
{
    public List<Character> ReadCharacters(string filePath) {
        List<String> characterCsvData = File.ReadAllLines(filePath).ToList();
        characterCsvData.RemoveAt(0); // Remove header row before creating Character objects

        List<Character> characters = new List<Character>();

        foreach (string line in characterCsvData) {
            var characterDetails = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            characters.Add(new Character(characterDetails[0], characterDetails[1], int.Parse(characterDetails[2]), int.Parse(characterDetails[3]), characterDetails[4].Split("|")));
        }

        return characters;
    }
    
    public void WriteCharacters(string filePath, List<Character> characters) { 
        
    }
}