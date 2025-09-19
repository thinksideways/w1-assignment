using System.Text.RegularExpressions;

class CharacterWriter
{
    /** <c>addCharacter</c>
     * <summary>
     * Adds new characters to csv.
     * </summary>
     **/
    public static void addCharacter()
    {
        Console.WriteLine(("Character's name?: "));
        var characterName = Console.ReadLine();

        // automatically add quotations to character names that contain commas
        if (characterName.Contains(","))
        {
            characterName = $"\"{characterName}\"";
        }

        Console.WriteLine("Character's class?: ");
        var characterClass = Console.ReadLine();

        // Only accept integers for level and hitpoints
        var characterLevel = "";
        do
        {
            Console.WriteLine("Character's level?:");
            characterLevel = Console.ReadLine();
        } while (!int.TryParse(characterLevel, out int level));

        var characterHitpoints = "";
        do
        {
            Console.WriteLine("Character's hitpoints?:");
            characterHitpoints = Console.ReadLine();
        } while (!int.TryParse(characterHitpoints, out int hp));

        // Allow user to add multiple pieces of equipment
        bool stillAddingEquipment = true;
        List<string> equipment = [];
        do
        {
            Console.WriteLine("Enter equipment (or 'done' to finish): ");
            String item = Console.ReadLine() ?? "";

            if (!String.IsNullOrEmpty(item) && !item.Equals("done"))
            {
                equipment.Add(item);
            }
            else
            {
                stillAddingEquipment = false;
            }
        } while (stillAddingEquipment);

        // Have user verify character details:
        Console.WriteLine($"\nName: {characterName}");
        Console.WriteLine($"Class: {characterClass}");
        Console.WriteLine($"Level: {characterLevel}");
        Console.WriteLine($"Hitpoints: {characterHitpoints}");
        Console.WriteLine($"Equpment: {string.Join("|", equipment).Replace("|", ", ")}\r\n");

        String confirmation = "";
        do
        {
            Console.WriteLine($"Does this look correct? (y/n)");
            confirmation = Console.ReadLine() ?? "";
        } while (!confirmation.Equals("y") && !confirmation.Equals("n"));

        if (confirmation.Equals("y"))
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("input.csv", true))
                {
                    sw.WriteLine($"{characterName},{characterClass},{characterLevel},{characterHitpoints},{string.Join("|", equipment)}");
                    Console.WriteLine($"Character added to game: {characterName}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to write to file: {e.Message}");
            }
        }
        else // Recurse and allow user to re-add character
        {
            addCharacter();
        }
    }

    /** <c>levelCharacter</c>
     * <summary>
     * Levels the chosen character and increases their hitpoints by 15%.
     * </summary>
     **/
    public static void levelCharacter(string context)
    {
        bool stillLeveling = true;

        do
        {
            Console.WriteLine("Enter the name of the character you wish to level up (or q to return to main menu): ");
            string? characterName = Console.ReadLine() ?? "";

            if (characterName.Equals("q"))
            {
                stillLeveling = false;
            }
            else
            {
                try
                {
                    String filePath = "input.csv";
                    IFileHandler fileHandler = new CsvFileHandler();

                    if (context.Equals("JSON")) {
                        filePath = "input.json";
                        fileHandler = new JsonFileHandler();
                    }

                    List<Character> characters = fileHandler.ReadCharacters(filePath);
                    Character character = characters.FirstOrDefault(ch => ch.Name.Equals(characterName));
                    character.Level = character.Level + 1;
                    character.Hitpoints = (int)(character.Hitpoints * 1.15);
                    int characterIndex = characters.FindIndex(ch => ch.Name.Equals(characterName));
                    characters[characterIndex] = character;

                    fileHandler.WriteCharacters(filePath, characters);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error finding or updating character: {e.Message}");
                }
            }
        } while (stillLeveling);
    }
}