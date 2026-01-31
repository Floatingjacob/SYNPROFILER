public class Globals
{
    public static string version = "0.1";
    public static bool profileLoaded = false;
    public static string profilePath;
    public static string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SYNPROFILER/tmp");
    public static string[] manifest;
    public static string profileName;
    public static List<String> profile = [];
}