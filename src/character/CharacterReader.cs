namespace w1_assignment.character;

using System.Text.RegularExpressions;

class CharacterReader
{
    public static void displayCharacters()
    {
        Console.WriteLine("*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n");

        var count = 0;
        foreach (String line in File.ReadAllLines("input.csv"))
        {
            if (count > 0)
            {
                // Only split on commas that aren't encapsulated in quotes
                // Google/Gemini suggested regex pattern to split on commas that aren't in quotes: ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"
                String[] cols = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                var character = new Character(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]), cols[4].Split("|"));
                Console.Write(character.ToString());
                Console.WriteLine("\r\n\r\n*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n");
            }
            count++;
        }
    }

    /** <c>findCharacter</c>
     * <summary>
     * Finds character by name
     * </summary>
     **/
    public static void findCharacter()
    {
        Console.WriteLine("Enter the name of the character you wish to find: ");
        string? characterName = Console.ReadLine() ?? "";

        try
        {
            List<String> characters = File.ReadAllLines("input.csv").ToList();

            // Google/Gemini suggested regex pattern to split on commas that aren't in quotes: ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"
            var searchResults = characters.Where(character => Regex.Split(character, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)")[0].ToLower().Contains(characterName.ToLower()));

            if (searchResults.Any())
            {
                Console.WriteLine("\r\n*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n\r\n");
                foreach (String result in searchResults)
                {
                    // Google/Gemini suggested regex pattern to split on commas that aren't in quotes: ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"
                    var characterDetails = Regex.Split(result, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    var foundCharacter = new Character(characterDetails[0], characterDetails[1], int.Parse(characterDetails[2]), int.Parse(characterDetails[3]), characterDetails[4].Split("|"));

                    Console.WriteLine(foundCharacter.ToString());
                    Console.WriteLine("\r\n\r\n*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n");
                }
            }
            else
            {
                Console.WriteLine($"Character '{characterName.Replace("\"", "")}' not found.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error finding character: {e.Message}");
        }
    }
}