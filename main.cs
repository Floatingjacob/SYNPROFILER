public class main
{
    static string input;
    static string Greeting = $"Welcome to SYNPROFILER: The Overengineered Dossier Program\nStalk With Style!\nv{Globals.version}\n";
    
    static string createMenu = @"

";
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            string mainMenu = Globals.profileLoaded ? @"#### Main Menu ####

1. Load Profile (Loaded)
2. Create Profile
3. Edit Profile
4. View Profile
0. Exit Program

#### Main Menu ####
" :
    @"#### Main Menu ####

1. Load Profile 
2. Create Profile
3. Edit Profile
4. View Profile
0. Exit Program

#### Main Menu ####
";
            Console.Title = "SYNPROFILER: The Overengineered Dossier Program";
            profileManipulation pm = new profileManipulation();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Greeting);
            if (!String.IsNullOrWhiteSpace(Globals.profileName))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Profile \"{Globals.profileName}\" Loaded!\n");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(mainMenu);

            Console.Write("> ");
            switch (input = Console.ReadLine())
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    pm.loadProfile();
                    break;
                case "4":
                    Globals.displaying = true;
                    viewer.displayMenu(Globals.profile);
                    break;
            }
        }

    }
}