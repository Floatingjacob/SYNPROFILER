public class main
{
    static string input;
    static string Greeting = $"Welcome to SYNPROFILER: The Overengineered Dossier Program\nStalk With Style!\nSYNPROFILER v{SYNCORE.Globals.SYNPROFILER.version}\nSYNCORE v{SYNCORE.Globals.coreVersion}\n"; // Lazy mode enabled...
    
    static string createMenu = @"

";
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            string mainMenu = SYNCORE.Globals.SYNPROFILER.profileLoaded ? @"#### Main Menu ####

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
            Console.Title = "SYNPROFILER: The Overengineered Dossier Program"; // bc why not?
            profileManipulation pm = new profileManipulation();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Greeting);
            if (!String.IsNullOrWhiteSpace(SYNCORE.Globals.SYNPROFILER.profileName))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Profile \"{SYNCORE.Globals.SYNPROFILER.profileName}\" Loaded!\n"); // ooh, shiny
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(mainMenu); // wheeeeee (translation: let's get this show on the road)

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
                    
                    SYNCORE.Globals.SYNPROFILER.displaying = true;
                    SYNCORE.viewer.displayMenu(SYNCORE.Globals.SYNPROFILER.profile);
                    break;
            }
        }

    }
}