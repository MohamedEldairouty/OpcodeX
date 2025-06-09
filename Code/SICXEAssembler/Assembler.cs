using SICAssembler.Core;
using System;

class Assembler
{
    static void Main(string[] args)
    {
        Pass1 pass1 = new Pass1();
        pass1.Run(Paths.InputFile);
        Console.WriteLine("Pass 1 completed. Output files generated.");

        Pass2 pass2 = new Pass2();
        pass2.Run();
        Console.WriteLine("Pass 2 completed. Object code generated.");
    }
}