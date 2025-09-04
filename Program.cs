namespace w1_assignment;
using System.IO;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        bool appRunning = true;

        // TODO: Brainstorm only having to add a menu to a list and not have to change the switch statement
        String[] menuOptions = [
            "Display Characters",
            "Add Character",
            "Level Up Character",
            "Quit (or q)" //always last
        ];

        do
        {
            int i = 0;

            foreach (String option in menuOptions)
            {
                i++;
                Console.WriteLine($"{i}. {option}");
            }

            var response = Console.ReadLine();

            Console.WriteLine($"You chose: {response}");

            switch (response)
            {
                case "1": Character.displayCharacters(); break;
                case "2": Character.addCharacter(); break; //TODO: change from static void to static Character method
                case "3": Character.levelCharacter(); break;
                case "4": appRunning = false; break;
                case "q": appRunning = false; break;
            }
        } while (appRunning);
    }

    /** <c>addCharacter</c>
     * <summary>
     * Adds new characters to csv.
     * </summary>
     **/
    static void addCharacter()
    {
        Console.WriteLine(("Character's name?: "));
        var characterName = Console.ReadLine();

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
}
