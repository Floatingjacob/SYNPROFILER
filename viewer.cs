public class viewer
{
    static string t = "";
    public static void displayMenu(List<String> menu)
    {
        while (Globals.displaying)
        {
            List<String> pm = [];
            Console.Clear();
            int n = 1;
            string input = "";
            t = "";
            Console.WriteLine("#### Select an Entry ####\n");

            foreach (string i in menu)
            {
                bool sm = false;
                //Console.WriteLine(i);
                if (i.Split(':')[0].Split('_').Length > 2)
                {
                    //Console.WriteLine($"{i.Split(':')[0]} is a submenu. Hiding..."); // for debug
                    sm = true;
                }
                if (!sm)
                {
                    pm.Add(i);
                    Console.WriteLine($"{n}. {pm[n - 1].Split(':')[1]}");
                    n++;
                }
            }
            Console.WriteLine("0. Back\n");
            Console.WriteLine("#### Select an Entry ####");
            Console.Write("> ");
            //cursor();
            input = Console.ReadLine();
            Globals.displaying = false;
            if (input == "0") { return; }
            t = pm[int.Parse(input) - 1].Split(':')[1].Trim();
            displayMenu(menu, pm[int.Parse(input) - 1].Split(':')[0].Split('_')[1]);
            //Console.WriteLine(pm[int.Parse(input) - 1]); // for debugging
        }
    }
    public static void displayMenu(List<String> menu, string parent)
    {
        Globals.displaying = true; // Set this to true because this is only called when displaying a submenu
        Console.Clear();
        while (Globals.displaying)
        {
            List<String> tc = [];
            int n = 1;
            
            Console.WriteLine($"#### Select an Entry ({t}) ####\n");
            foreach (string i in menu)
            {
                bool v = true;
                if (i.Split(':')[0].Split('_', 2)[1].Split('_')[0] != parent || i.Split(':')[0].Split('_', 2)[1] == parent) // Filters children.
                {
                    v = false;
                }
                if (v)
                {
                    tc.Add(i);
                    Console.WriteLine($"{n}. {i.Split(':')[1]}");
                    n++;
                }
            }
            Console.WriteLine("0. Back\n");
            Console.WriteLine($"#### Select an Entry ({t}) ####\n");
            Console.Write("> ");
            string input = Console.ReadLine();
        //    Console.WriteLine(tc[int.Parse(input) - 1].Split(':')[0]); // for debugging
            if(input == "0")
            {
                displayMenu(menu);
                break;
            }
            Console.Clear();
            string o = parser.parseSubmenu(File.ReadAllLines(Path.Combine(Globals.tempPath, tc[int.Parse(input) - 1].Split(':')[0]))).Result;
            if (o.Split(':')[0] == "ERROR") Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(o);
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
    public static async void cursor()
    {
        // Work in progress cursor. super crappy. probably wont be used even if it is finished
        int p = 0;

        while (true)
        {
            ConsoleKey k = Console.ReadKey().Key;
            if (k == ConsoleKey.DownArrow && p < Console.WindowHeight)
            {
                p++;
                Console.SetCursorPosition(0, p);

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    if (p > 0) Console.SetCursorPosition(i, p - 1);
                    else Console.SetCursorPosition(i, p);
                    Console.Write(' ');
                }
                Console.WriteLine();

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                for (int i = 0; i < Console.WindowWidth - 1; i++)
                {

                    Console.SetCursorPosition(i, p);
                    Console.Write(' ');
                }
                Console.SetCursorPosition(0, p);
                Console.Write("> ");
            }
            else if (k == ConsoleKey.UpArrow && p > 1)
            {
                p--;
                Console.SetCursorPosition(0, p);
                Console.BackgroundColor = ConsoleColor.Black;
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    if (p > 0) Console.SetCursorPosition(i, p + 1);
                    else Console.SetCursorPosition(i, p);
                    Console.Write(' ');
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                for (int i = 0; i < Console.WindowWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, p);
                    Console.Write(' ');
                }
                Console.SetCursorPosition(0, p);
                Console.Write("> ");
            }
        }
    }
}

