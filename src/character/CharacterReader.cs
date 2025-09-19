namespace w1_assignment.character;

using System.Text.RegularExpressions;

class CharacterReader
{
    public static void displayCharacters(string context)
    {
        IFileHandler fileHandler = new CsvFileHandler();
        String filePath = "input.csv";

        if (context.Equals("JSON")) {
            fileHandler = new JsonFileHandler();
            filePath = "input.json";
        }

        List<Character> characters = fileHandler.ReadCharacters(filePath);

        Console.WriteLine("*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n");
        foreach (Character character in characters)
        {
            Console.Write(character.ToString());
            Console.WriteLine("\r\n\r\n*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n");
        }
    }

    /** <c>findCharacter</c>
     * <summary>
     * Finds character by name
     * </summary>
     **/
    public static void findCharacter(string context)
    {
        Console.WriteLine("Enter the name of the character you wish to find: ");
        string? characterName = Console.ReadLine() ?? "";

        try
        {
            IFileHandler fileHandler = new CsvFileHandler();
            String filePath = "input.csv";

            if (context.Equals("JSON")) {
                fileHandler = new JsonFileHandler();
                filePath = "input.json";
            }

            List<Character> characters = fileHandler.ReadCharacters(filePath);
            var searchResults = characters.Where(character => character.Name.ToLower().Contains(characterName.ToLower()));

            if (searchResults.Any())
            {
                Console.WriteLine("\r\n*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n\r\n");
                foreach (Character result in searchResults)
                {
                    Console.WriteLine(result.ToString());
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