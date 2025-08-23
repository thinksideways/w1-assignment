namespace w1_assignment;

class Program
{
    static void Main(string[] args)
    {
        bool appRunning = true;

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
                case "1": displayCharacters(); break;
                case "2": addCharacter(); break; //TODO: change from static void to static Character method
                case "3": levelCharacter(); break;
                case "4": appRunning = false; break;
                case "q": appRunning = false; break;
                default: break;
            }
        } while (appRunning);
    }

    static void displayCharacters()
    {
        Console.WriteLine("*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n");
        foreach (String line in File.ReadAllLines("input.csv"))
        {
            var cols = line.Split(",");

            Console.WriteLine($"Name: {cols[0]}");
            Console.WriteLine($"Class: {cols[1]}");
            Console.WriteLine($"Level: {cols[2]}");
            Console.WriteLine($"Hitpoints: {cols[3]}");
            Console.WriteLine($"Equipment: {cols[4].Replace("|", ", ")}\r\n");

            Console.WriteLine("*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*!*\r\n");
        }
    }

    static void addCharacter()
    {
    }

    static void levelCharacter()
    {
    }
}
