#pragma warning disable CS8601
#pragma warning disable CS8602
#pragma warning disable CS8618
public class profileManipulation
{
    static string input;
    SYNCORE.parser p = new SYNCORE.parser();
    public static string file;
    public void loadProfile()
    {
        input = "";
        SYNCORE.Globals.SYNPROFILER.profilePath = "";
        SYNCORE.Globals.SYNPROFILER.profileName = "";
        SYNCORE.Globals.SYNPROFILER.profile = [];
        SYNCORE.Globals.SYNPROFILER.manifest = [];
        if (SYNCORE.Globals.SYNPROFILER.profileLoaded)
        {

            Console.Write("A profile is already loaded. Proceed? y/N: ");
            input = Console.ReadLine();
            if (input.Trim().ToUpper() != "Y")
            {
                Console.WriteLine("Y not selected, aborting...");
                return;
            }
            else SYNCORE.Globals.SYNPROFILER.profileLoaded = false;
        }
        Console.WriteLine("Input the absolute path to the profile:");
        input = "";
        while (String.IsNullOrWhiteSpace(input))
        {
            Console.Write("> ");
            input = Console.ReadLine();
        }
        input = input.Replace('"', ' ').Trim();
        SYNCORE.Globals.SYNPROFILER.profileLoaded = true;
        p.parseProfile(input);
    }
}
