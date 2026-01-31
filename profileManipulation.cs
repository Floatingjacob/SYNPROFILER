using System;
using System.Collections.Generic;
using System.Text;


public class profileManipulation
{
    static string input;
    parser p = new parser();
    public static string file;
    public void loadProfile()
    {
        if (Globals.profileLoaded)
        {

            Console.Write("A profile is already loaded. Proceed? y/N: ");
            input = Console.ReadKey().ToString();
            if (input.ToUpper() == "Y")
            {
                Console.WriteLine("Y not selected, aborting...");
                return;
            }
        }
        Console.WriteLine("Input the absolute path to the profile:");

        while (String.IsNullOrWhiteSpace(input))
        {
            Console.Write("> ");
            input = Console.ReadLine();
        }
        input.Replace('"', ' ').Trim();
        p.parseProfile(input);

    }
}
