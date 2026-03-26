/*
 TODO: Make program more idiot-proof (the pros call it "input validation", but im not one). 
 wrap everything with try-catch statements. 
 consume less caffine. 
 go to bed earlier.
 stop splitting every string 50 times in the parser
 */

#pragma warning disable CS8601
using SYNCORE;

public class Entry
{
    static string input = "";
    static string Greeting = $"Welcome to SYNPROFILER: The Overengineered Dossier Manager\nStalk With Style!\nSYNPROFILER v{SYNCORE.Globals.SYNPROFILER.version}\nSYNCORE v{SYNCORE.Globals.coreVersion}\n"; // Lazy mode enabled...
    
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
            Console.Title = "SYNPROFILER: The Overengineered Dossier Manager"; // bc why not?
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
            { // only the viewer exists for now
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    pm.loadProfile();
                    break;
                case "4":

                    if (!Globals.SYNPROFILER.profileLoaded)
                    {
                        Console.WriteLine("No profile is loaded, load one first (or don't).\nPress any key to recontemplate your choices...");
                        Console.ReadKey();
                    }
                    else
                    {
                        viewer.sortMenu();
                        SYNCORE.Globals.SYNPROFILER.displaying = true;
                        SYNCORE.viewer.displayMenu(SYNCORE.Globals.SYNPROFILER.profile);
                    }
                        
                    break;
            }
        }

    }
}