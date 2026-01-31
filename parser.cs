using System.IO.Compression;

public class parser
{
    public void parseProfile(string file)
    {
        Console.WriteLine("Parsing...");
        Console.WriteLine("Removing old files...");
        try
        {
            Directory.Delete(Globals.tempPath, true);
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("Nothing to remove, proceeding...");
        }
        Console.WriteLine("Extracting profile...");
        ZipFile.ExtractToDirectory(file, Globals.tempPath);
        Console.WriteLine("Scanning files...");
        foreach (String f in Directory.EnumerateFiles(Globals.tempPath))
        {

            //  Console.WriteLine(f); // for debug
            if (Path.GetFileName(f) == "MF")
            {
                Console.WriteLine("Manifest found!\nParsing...");
                Globals.manifest = File.ReadAllLines(f);
            }
            if (Path.GetFileName(f).StartsWith("MU_")) // Might need to wrestle with regex so submenus aren't snorted by this
            {
                string n = Path.GetFileName(f);
                string l = lookup(n).Result;
                Console.WriteLine($"\"{l}\" found!");
                Globals.profile.Add(($"{n}:{l}"));

            }
        }
    }
    public static Task<string> lookup(string lookup)
    {
        string t = null;
        foreach (string l in Globals.manifest)
        {
            if (l.Split(':')[0] == lookup)
            {
                t = l.Split(':')[1].Trim(); // If a translation exists, temporarily assign it to 't'
            }
        }
        if (String.IsNullOrWhiteSpace(t))
        {
            t = lookup; // Return the lookup if it can't find a translation
        }
        return Task.FromResult(t); // Return the translation
    }
}

