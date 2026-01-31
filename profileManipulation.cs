public class profileManipulation
{
    static string input;
    parser p = new parser();
    public static string file;
    public void loadProfile()
    {
        input = "";
        Globals.profilePath = "";
        if (Globals.profileLoaded)
        {

            Console.Write("A profile is already loaded. Proceed? y/N: ");
            input = Console.ReadLine();
            if (input.Trim().ToUpper() != "Y")
            {
                Console.WriteLine("Y not selected, aborting...");
                return;
            }
            else Globals.profileLoaded = false;
        }
        Console.WriteLine("Input the absolute path to the profile:");
        input = "";
        while (String.IsNullOrWhiteSpace(input))
        {
            Console.Write("> ");
            input = Console.ReadLine();
        }
        input = input.Replace('"', ' ').Trim();
        Globals.profileLoaded = true;
        p.parseProfile(input);
    }
}
