using System.IO;
using System;

public static class Paths
{
    public static string Base = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"OpcodeX");
    public static string InputFile => Path.Combine(Base, "input", "in.txt");
    public static string OutputFolder => Path.Combine(Base, "output");
    public static string Intermediate => Path.Combine(OutputFolder, "intermediate.txt");
    public static string OutPass1 => Path.Combine(OutputFolder, "out_pass1.txt");
    public static string OutPass2 => Path.Combine(OutputFolder, "out_pass2.txt");
    public static string symbTable => Path.Combine(OutputFolder, "symbtable.txt");
    public static string HTME => Path.Combine(OutputFolder, "HTME.txt");
    static Paths()
    {
        Directory.CreateDirectory(Path.Combine(Base, "input"));
        Directory.CreateDirectory(Path.Combine(Base, "output"));

        EnsureFileExists(InputFile);
        EnsureFileExists(OutPass1);
        EnsureFileExists(OutPass2);
        EnsureFileExists(Intermediate);
        EnsureFileExists(symbTable);
        EnsureFileExists(HTME);
    }

    private static void EnsureFileExists(string path)
    {
        if (!File.Exists(path))
            File.WriteAllText(path, ""); 
    }
}