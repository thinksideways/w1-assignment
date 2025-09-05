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
}
