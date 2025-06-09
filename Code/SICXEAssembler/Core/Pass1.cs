using System;
using System.Collections.Generic;
using System.IO;

namespace SICAssembler.Core
{
    public class Pass1
    {
        public List<Line> SourceLines = new List<Line>();
        public SymbolTable SymTable = new SymbolTable();

        public Dictionary<string,int> LiteralTable = new Dictionary<string, int>();
        public List<string> Literals = new List<string>();

        private int startAddress = 0;
        private int LOCCTR = 0;

        public void Run(string inputPath)
        {
            ReadSourceFile(inputPath ?? Paths.InputFile);
            ProcessLines();
            WriteIntermediateFile();
            WriteOutPass1File();
            WriteSymTableFile();
        }

        private void ReadSourceFile(string filePath)
        {
            var lines = File.ReadAllLines(Paths.InputFile);
            foreach (var rawLine in lines)
            {
                if (string.IsNullOrWhiteSpace(rawLine)) continue;
                Line line = ParseLine(rawLine.Trim());
                SourceLines.Add(line);
            }
        }
        private Line ParseLine(string rawLine)
        {
            Line line = new Line();

            int commentIndex = rawLine.IndexOf('.'); // comment starts with a dot
            if (commentIndex != -1)
                rawLine = rawLine.Substring(0, commentIndex).Trim();

            string[] parts = rawLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int index = 0;
            if (parts.Length > 0 && int.TryParse(parts[0], out _))
                index = 1; // skip line number

            int count = parts.Length - index;

            if (count == 3)
            {
                line.Label = parts[index];
                line.Opcode = parts[index + 1];
                line.Operand = parts[index + 2];
            }
            else if (count == 2)
            {
                string first = parts[index];
                string second = parts[index + 1];

                if (IsOpcodeOrDirective(first)) // ex.LDA NUM1
                {
                    line.Label = "";
                    line.Opcode = first;
                    line.Operand = second;
                }
                else // first is the label ex.EXit RSUB
                {
                    line.Label = first;
                    line.Opcode = second;
                    line.Operand = "";
                }
            }
            else if (count == 1)
            {
                line.Label = "";
                line.Opcode = parts[index];
                line.Operand = "";
            }

            return line;
        }

        private bool IsOpcodeOrDirective(string x)
        {
            x = x.ToUpper();
            return x == "START" || x == "END" || x == "BYTE" || x == "WORD" ||
                   x == "RESW" || x == "RESB" || x.StartsWith("+") ||
                   x == "ADD" || x == "ADDF" || x == "AND" || x == "COMP" ||
                   x == "COMPF" || x == "DIV" || x == "DIVF" || x == "J" ||
                   x == "JEQ" || x == "JGT" || x == "JLT" || x == "JSUB" ||
                   x == "LDA" || x == "LDB" || x == "LDCH" || x == "LDF" ||
                   x == "LDL" || x == "LDS" || x == "LDT" || x == "LDX" ||
                   x == "LPS" || x == "MUL" || x == "MULF" || x == "OR" ||
                   x == "RD" || x == "RSUB" || x == "SSK" || x == "STA" ||
                   x == "STB" || x == "STCH" || x == "STF" || x == "STI" ||
                   x == "STL" || x == "STS" || x == "STSW" || x == "STT" ||
                   x == "STX" || x == "SUB" || x == "SUBF" || x == "TD" || x == "BASE" || x == "NOBASE" ||
                   x == "TIX" || x == "WD" || IsFormat1Instruction(x) || IsFormat2Instruction(x) ||
                   x == "LITAD" || x == "LITLD" || x == "LITSB" || x == "LITCMP";
        }

        private void ProcessLines()
        {
            if (SourceLines.Count == 0) return;

            // START
            if (SourceLines[0].Opcode == "START")
            {
                startAddress = Convert.ToInt32(SourceLines[0].Operand, 16);
                LOCCTR = startAddress;
                SourceLines[0].LOCCTR = LOCCTR;
            }

            for (int i = (SourceLines[0].Opcode == "START") ? 1 : 0; i < SourceLines.Count; i++)
            {
                var line = SourceLines[i];

                line.LOCCTR = LOCCTR;

                // Add to symbol table
                if (!string.IsNullOrEmpty(line.Label))
                {
                    bool added = SymTable.Add(line.Label, LOCCTR);
                    if (!added)
                        Console.WriteLine($"Error: Duplicate symbol '{line.Label}'");
                }

                // Add to literal table
                if (!string.IsNullOrEmpty(line.Operand) && line.Operand.StartsWith("="))
                {
                    if (!LiteralTable.ContainsKey(line.Operand))  
                        Literals.Add(line.Operand);
                }

                //  LOCCTR calculation
                if (line.Opcode == "WORD") LOCCTR += 3;
                else if (line.Opcode == "RESW") LOCCTR += 3 * int.Parse(line.Operand);
                else if (line.Opcode == "RESB")
                {
                    if (int.TryParse(line.Operand, out int bytes))
                    {
                        LOCCTR += bytes;
                    }
                    else if (line.Operand.ToUpper() == "4096" || line.Label.ToUpper().Contains("BUFFER"))
                    {
                        LOCCTR += 0x1000;
                    }
                }
                else if (line.Opcode == "BYTE")
                {
                    if (line.Operand.StartsWith("X'") && line.Operand.EndsWith("'"))
                    {
                        // Each 2 hex digits = 1 byte
                        LOCCTR += (line.Operand.Length - 3) / 2;
                    }
                    else if (line.Operand.StartsWith("C'") && line.Operand.EndsWith("'"))
                    {
                        // Each character = 1 byte
                        LOCCTR += line.Operand.Length - 3;
                    }
                }
                else if (line.Opcode.StartsWith("+") || IsFormat4Instruction(line.Opcode)) LOCCTR += 4; // Format 4/4L
                else if (IsFormat2Instruction(line.Opcode)) LOCCTR += 2; // Format 2
                else if (IsFormat1Instruction(line.Opcode)) LOCCTR += 1; // Format 1
                else if (line.Opcode == "BASE" || line.Opcode == "NOBASE")
                {   // directives
                }
                else LOCCTR += 3; // Default Format 3
            }
            // Assign Literal addresses
            foreach (var lit in Literals)
            {
                if (!LiteralTable.ContainsKey(lit))
                {
                    LiteralTable[lit] = LOCCTR;

                    if (lit.StartsWith("=X'"))
                        LOCCTR += (lit.Length - 4) / 2;
                    else if (lit.StartsWith("=C'"))
                        LOCCTR += lit.Length - 4;
                    else
                        LOCCTR += 3; // default
                }
            }

        }

        private bool IsFormat2Instruction(string opcode)
        {
            string[] format2 = { "TIXR", "SVC", "SUBR", "SHIFTL", "SHIFTR", "RMO", "MULR", "DIVR", "CLEAR", "COMPR", "ADDR" };
            return Array.Exists(format2, op => op == opcode);
        }

        private bool IsFormat1Instruction(string opcode)
        {
            string[] format1 = { "FIX", "FLOAT", "SIO", "HIO", "NORM", "TIO" };
            return Array.Exists(format1, op => op == opcode);
        }

        private bool IsFormat4Instruction(string opcode)
        {
            string[] format4L = { "LITAD", "LITLD", "LITSB", "LITCMP" };
            return Array.Exists(format4L, op => op == opcode);
        }

        private void WriteIntermediateFile()
        {
            using (StreamWriter writer = new StreamWriter(Paths.Intermediate))
            {
                foreach (var line in SourceLines)
                {
                    writer.WriteLine($"{line.Label,-10}{line.Opcode,-10}{line.Operand}");
                }
            }
        }

        private void WriteOutPass1File()
        {
            using (StreamWriter writer = new StreamWriter(Paths.OutPass1))
            {
                foreach (var line in SourceLines)
                {
                    string loc = line.LOCCTR.HasValue ? $"{line.LOCCTR:X4}" : "    ";
                    writer.WriteLine($"{loc,-8}{line.Label,-10}{line.Opcode,-10}{line.Operand}");
                }
            }
        }

        private void WriteSymTableFile()
        {
            using (StreamWriter writer = new StreamWriter(Paths.symbTable))
            {
                foreach (var entry in SymTable.GetAll())
                    writer.WriteLine($"{entry.Key}\t{entry.Value:X4}");
            }
        }
    }
}
