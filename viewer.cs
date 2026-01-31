public class viewer
{
    public static void displayMenu(List<String> menu)
    {
        List<String> pm = [];
        // need to make submenus display only their children MU_S_A, MU_S_B, not MU_A_A etc
        Console.Clear();
        int n = 1;
        string input = "";
        Console.WriteLine("#### Select an Entry ####");

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
        Console.Write("> ");
        //cursor();
        input = Console.ReadLine();
        displayMenu(menu, pm[int.Parse(input) - 1].Split(':')[0].Split('_')[1]);
        //Console.WriteLine(pm[int.Parse(input) - 1]); // for debugging
    }
    public static void displayMenu(List<String> menu, string parent)
    {
        int n = 1;
        // Console.WriteLine($"parent is {parent}"); // for debugging
        foreach (string i in menu)
        {
            bool v = true;
            if (i.Split(':')[0].Split('_', 2)[1].Split('_')[0] != parent || i.Split(':')[0].Split('_', 2)[1] == parent) // Filters children.
            {
                v = false;
            }
            if (v)
            {
                Console.WriteLine($"{n}. {i.Split(':')[1]}");
                n++;
            }
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

