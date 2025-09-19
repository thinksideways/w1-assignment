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
                case "1": CharacterReader.displayCharacters(contexts[0]); break;
                case "2": CharacterWriter.addCharacter(contexts[0]); break; //TODO: change from static void to static Character method
                case "3": CharacterWriter.levelCharacter(contexts[0]); break;
                case "4": CharacterReader.findCharacter(contexts[0]); break;
                case "5": Array.Reverse(contexts); Console.WriteLine($"\r\nNow Reading and Writing to: {contexts[0]}\r\n"); break;
                case "6": appRunning = false; break;
                case "q": appRunning = false; break;
                default: Console.WriteLine("Please choose a valid option from the list."); break;
            }
        } while (appRunning);
    }
}
