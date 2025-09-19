namespace w1_assignment;

using System.IO;
using System.Linq;

using character;

class Program
{
    static void Main(string[] args)
    {
        bool appRunning = true;

        // Whichever one is first is the currently selected context
        String[] contexts = [
            "CSV",
            "JSON"
        ];

        do
        {
            int i = 0;

            // Moved to app loop so we can update the current context dynamically
            String[] menuOptions = [
                "Display Characters",
                "Add Character",
                "Level Up Character",
                "Find Character",
                $"Toggle context to {contexts[1]} (Current: {contexts[0]})",
                "Quit (or q)" //always last
            ];

            foreach (String option in menuOptions)
            {
                i++;
                Console.WriteLine($"{i}. {option}");
            }

            var response = Console.ReadLine();

            Console.WriteLine($"You chose: {response}");

            switch (response)
            {
                case "1": CharacterReader.displayCharacters(); break;
                case "2": CharacterWriter.addCharacter(); break; //TODO: change from static void to static Character method
                case "3": CharacterWriter.levelCharacter(); break;
                case "4": CharacterReader.findCharacter(); break;
                case "5": Array.Reverse(contexts); Console.WriteLine($"Now Reading and Writing to: {contexts[0]}"); break;
                case "6": appRunning = false; break;
                case "q": appRunning = false; break;
            }
        } while (appRunning);
    }
}
