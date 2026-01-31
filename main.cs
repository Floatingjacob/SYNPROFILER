public class main
{
    static string input;
    static string Greeting = $"Welcome to SYNPROFILER\nStalk With Style\nv{Globals.version}\n";
    static string mainMenu = @"#### Main Menu ####

1. Load Profile
2. Create Profile
3. Edit Profile
4. View Profile
5. Delete Profile
0. Exit Program
";
    static string createMenu = @"

";
    public static void Main(string[] args)
    {
        profileManipulation pm = new profileManipulation();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(Greeting);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(mainMenu);
        while (true)
        {
            Console.Write("> ");
            switch (input = Console.ReadLine())
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    pm.loadProfile();
                    break;
            }
        }

    }
}