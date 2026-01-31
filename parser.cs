using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;

public class parser
{
    public async void parseProfile(string file)
    {
        Console.WriteLine("Parsing...");
        Console.WriteLine("Removing old files...");
        try
        {
            Directory.Delete(Globals.tempPath, true);
        }
        catch(System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("Nothing to remove, proceeding...");
        }
        Console.WriteLine("Extracting profile...");

        ZipFile.ExtractToDirectory(file, Globals.tempPath);
        Console.WriteLine("Scanning files...");
        foreach (String f in Directory.EnumerateFiles(Globals.tempPath)){
          //  Console.WriteLine(f); // for debug
            if (Path.GetFileName(f) == "MF")
            {
                Console.WriteLine("Manifest found!\nParsing...");
                Globals.manifest = File.ReadAllLines(f);
            }
            if (Path.GetFileName(f).StartsWith("MU_"))
            {
                string l = await lookup(Path.GetFileName(f));
                Console.WriteLine($"Menu \"{l}\" found!");
            }
        }
    }
    public static Task<string> lookup(string lookup)
    {
        string r = null;
        foreach(string l in Globals.manifest)
        {
            if (l.Split(':')[0] == lookup)
            {   
                r = l.Split(':')[1].Trim();
            }
        }
        if (String.IsNullOrWhiteSpace(r))
        {
            r = lookup;
        }
        return Task.FromResult(r);
    }
}

