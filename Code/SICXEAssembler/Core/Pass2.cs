using System;
using System.Collections.Generic;
using System.IO;

namespace SICAssembler.Core
{
    public class Pass2
    {
        private List<Line> SourceLines = new List<Line>();
        private Dictionary<string, int> SymbolTable = new Dictionary<string, int>();
        private List<string> LOCCTRs = new List<string>();
        private int? BaseAddress = null;
        private HashSet<string> MRecords = new HashSet<string>();
        private Dictionary<string, int> RegisterTable = new Dictionary<string, int>
        {
            { "A", 0 }, { "X", 1 }, { "L", 2 },
            { "B", 3 }, { "S", 4 }, { "T", 5 },
            { "F", 6 }, { "PC", 8 }, { "SW", 9 }
        };
        private Dictionary<string, string> OpcodeTable = new Dictionary<string, string>
        {
            { "ADD", "18" },    { "ADDF", "58" },  { "ADDR", "90" },
            { "AND", "40" },    { "CLEAR", "B4" }, { "COMP", "28" },
            { "COMPF", "88" },  { "COMPR", "A0" }, { "DIV", "24" },
            { "DIVF", "64" },   { "DIVR", "9C" },  { "FIX", "C4" },
            { "FLOAT", "C0" },  { "HIO", "F4" },   { "J", "3C" },
            { "JEQ", "30" },    { "JGT", "34" },   { "JLT", "38" },
            { "JSUB", "48" },   { "LDA", "00" },   { "LDB", "68" },
            { "LDCH", "50" },   { "LDF", "70" },   { "LDL", "08" },
            { "LDS", "6C" },    { "LDT", "74" },   { "LDX", "04" },
            { "LPS", "D0" },    { "MUL", "20" },   { "MULF", "60" },
            { "MULR", "98" },   { "NORM", "C8" },  { "OR", "44" },
            { "RD", "D8" },     { "RMO", "AC" },   { "RSUB", "4C" },
            { "SHIFTL", "A4" }, { "SHIFTR", "A8" },{ "SIO", "F0" },
            { "SSK", "EC" },    { "STA", "0C" },   { "STB", "78" },
            { "STCH", "54" },   { "STF", "80" },   { "STI", "D4" },
            { "STL", "14" },    { "STS", "7C" },   { "STSW", "E8" },
            { "STT", "84" },    { "STX", "10" },   { "SUB", "1C" },
            { "SUBF", "5C" },   { "SUBR", "94" },  { "SVC", "B0" },
            { "TD", "E0" },     { "TIO", "F8" },   { "TIX", "2C" },
            { "TIXR", "B8" },   { "WD", "DC" },
            { "LITAD", "BC" }, { "LITSB", "8C" }, { "LITLD", "E4" }, { "LITCMP", "FC" }
        };

        public void Run()
        {
            LoadIntermediate();
            LoadSymTable();
            LoadLocctr();
            WriteOutPass2();
            WriteHTME();
        }

        private void LoadIntermediate()
        {
            var lines = File.ReadAllLines(Paths.Intermediate);
            foreach (var rawLine in lines)
            {
                var parts = rawLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Line line = new Line();
                if (parts.Length == 3)
                {
                    line.Label = parts[0];
                    line.Opcode = parts[1];
                    line.Operand = parts[2];
                }
                else if (parts.Length == 2)
                {
                    line.Label = "";
                    line.Opcode = parts[0];
                    line.Operand = parts[1];
                }
                else if (parts.Length == 1)
                {
                    line.Label = "";
                    line.Opcode = parts[0];
                    line.Operand = "";
                }

                SourceLines.Add(line);
            }
        }

        private void LoadSymTable()
        {
            var lines = File.ReadAllLines(Paths.symbTable);
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                SymbolTable[parts[0]] = Convert.ToInt32(parts[1], 16);
            }
        }

        private void LoadLocctr()
        {
            var lines = File.ReadAllLines(Paths.OutPass1);
            LOCCTRs.AddRange(lines);
        }
        private void WriteOutPass2()
        {
            using (StreamWriter writer = new StreamWriter(Paths.OutPass2))
            {
                for (int i = 0; i < SourceLines.Count; i++)
                {
                    var line = SourceLines[i];
                    string fullLine = LOCCTRs[i];
                    string loc = fullLine.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    line.LOCCTR = Convert.ToInt32(loc, 16);
                    string upperOpcode = line.Opcode.ToUpper();

                    // Set BaseAddress
                    if (upperOpcode == "BASE" && SymbolTable.ContainsKey(line.Operand))
                    {
                        BaseAddress = SymbolTable[line.Operand];
                        writer.WriteLine($"{loc,-8}{line.Label,-10}{line.Opcode,-10}{line.Operand,-10}");
                        continue;
                    }
                    // Reset BaseAddress
                    else if (upperOpcode == "NOBASE")
                    {
                        BaseAddress = null;
                        writer.WriteLine($"{loc,-8}{line.Label,-10}{line.Opcode,-10}{line.Operand,-10}");
                        continue;
                    }

                    // Set BaseAddress
                    if (upperOpcode == "LDB")
                    {
                        string operand = line.Operand.StartsWith("#") ? line.Operand.Substring(1) : line.Operand;
                        if (SymbolTable.ContainsKey(operand))
                        {
                            BaseAddress = SymbolTable[operand];
                        }
                    }

                    string objCode = GenerateObjectCode(line);
                    writer.WriteLine($"{loc,-8}{line.Label,-10}{line.Opcode,-10}{line.Operand,-10}{objCode}");
                }
            }
        }
        private string GenerateObjectCode(Line line)
        {
            string opcode = line.Opcode.ToUpper();
            string operand = line.Operand;
            string objCode = "";

            // === Format 4L ===
            if ((opcode == "LITAD" || opcode == "LITSB" || opcode == "LITLD" || opcode == "LITCMP") &&
     operand.Contains(",") && (operand.Contains("=X'") || operand.Contains("=C'")))
            {
                var parts = operand.Split(',');
                string reg = parts[0].Trim();
                string literal = parts[1].Trim();

                if (!RegisterTable.ContainsKey(reg))
                    return "??????";

                int regVal = RegisterTable[reg];
                string litHex = "";

                if (literal.StartsWith("=X'") && literal.EndsWith("'"))
                {
                    litHex = literal.Substring(3, literal.Length - 4);
                }
                else if (literal.StartsWith("=C'") && literal.EndsWith("'"))
                {
                    string chars = literal.Substring(3, literal.Length - 4);
                    foreach (char c in chars)
                        litHex += ((int)c).ToString("X2");
                }
                else
                {
                    return "??????"; // invalid literal
                }

                if (litHex.Length > 5 * 2)
                    return "??????"; 

                string opcode8 = OpcodeTable[opcode];
                return $"{opcode8}{regVal:X1}{litHex.PadLeft(5, '0')}";
            }


            // RSUB
            if (opcode == "RSUB") return "4F0000";

            // BYTE
            if (opcode == "BYTE")
            {
                if (operand.StartsWith("C'") && operand.EndsWith("'"))
                {
                    string chars = operand.Substring(2, operand.Length - 3);
                    foreach (char c in chars) objCode += ((int)c).ToString("X2");
                }
                else if (operand.StartsWith("X'") && operand.EndsWith("'"))
                {
                    objCode = operand.Substring(2, operand.Length - 3).ToUpper();
                }
                return objCode;
            }

            // WORD
            if (opcode == "WORD")
            {
                int value = int.Parse(operand);
                return value.ToString("X6");
            }

            if (opcode == "RESW" || opcode == "RESB" || opcode == "START" || opcode == "END") return "";

            // Format 1
            if (OpcodeTable.ContainsKey(opcode) && operand == "" && OpcodeTable[opcode].Length == 2)
                return OpcodeTable[opcode];

            // Format 2
            if (OpcodeTable.ContainsKey(opcode) && OpcodeTable[opcode].Length == 2 && operand.Contains(","))
            {
                var regs = operand.Split(',');
                if (RegisterTable.ContainsKey(regs[0]) && RegisterTable.ContainsKey(regs[1]))
                {
                    string op = OpcodeTable[opcode];
                    int r1 = RegisterTable[regs[0]];
                    int r2 = RegisterTable[regs[1]];
                    return $"{op}{r1:X1}{r2:X1}";
                }
            }

            if (OpcodeTable.ContainsKey(opcode) && OpcodeTable[opcode].Length == 2 && RegisterTable.ContainsKey(operand))
            {
                string op = OpcodeTable[opcode];
                int r1 = RegisterTable[operand];
                return $"{op}{r1:X1}0";
            }

            // Format 3 & 4
            bool isFormat4 = opcode.StartsWith("+");
            string baseOpcode = opcode.Replace("+", "");
            if (!OpcodeTable.ContainsKey(baseOpcode)) return "";

            string opHex = OpcodeTable[baseOpcode];
            int opCodeValue = Convert.ToInt32(opHex, 16);

            bool immediate = operand.StartsWith("#");
            bool indirect = operand.StartsWith("@");
            bool indexed = operand.EndsWith(",X");

            if (immediate || indirect) operand = operand.Substring(1);
            if (indexed) operand = operand.Replace(",X", "");

            int n = indirect ? 1 : immediate ? 0 : 1;
            int i = immediate ? 1 : indirect ? 0 : 1;
            int x = indexed ? 1 : 0;
            int b = 0, p = isFormat4 ? 0 : 1, e = isFormat4 ? 1 : 0;

            int currentLOC = line.LOCCTR.Value;
            int nextLOC = currentLOC + (e == 1 ? 4 : 3);
            int disp = 0;

            if (immediate && int.TryParse(operand, out int constVal))
            {
                int firstByte = (opCodeValue & 0xFC) | (n << 1) | i;
                return $"{firstByte:X2}00{constVal:X3}";
            }

            if (!SymbolTable.ContainsKey(operand)) return "??????";
            int addr = SymbolTable[operand];

            if (e == 1)
            {
                int firstByte = (opCodeValue & 0xFC) | (n << 1) | i;
                int niFlags = (x << 3 | b << 2 | p << 1 | e);
                string obj = $"{firstByte:X2}{niFlags:X1}{addr:X5}";
                if (!immediate || !int.TryParse(operand, out _))
                    MRecords.Add($"M.{(line.LOCCTR.Value + 1):X6}.05");
                return obj;
            }
            else
            {
                int offset = addr - nextLOC;
                if (offset >= -2048 && offset <= 2047)
                {
                    p = 1;
                    disp = offset & 0xFFF;
                }
                else if (BaseAddress != null)
                {
                    int baseOffset = addr - BaseAddress.Value;
                    if (baseOffset >= 0 && baseOffset <= 4095)
                    {
                        b = 1; p = 0;
                        disp = baseOffset;
                    }
                    else return "??????";
                }
                else return "??????";

                int firstByte = (opCodeValue & 0xFC) | (n << 1) | i;
                int niFlags = (x << 3 | b << 2 | p << 1 | e);
                return $"{firstByte:X2}{niFlags:X1}{disp:X3}";
            }
        }
        private void WriteHTME()
        {
            using (StreamWriter writer = new StreamWriter(Paths.HTME))
            {
                // --- Header Record ---
                string progName = (SourceLines[0].Label ?? "PROG").PadRight(6, 'X');
                string startAddr = LOCCTRs[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string endAddr = LOCCTRs[LOCCTRs.Count - 1].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0];
                int start = Convert.ToInt32(startAddr, 16);
                int end = Convert.ToInt32(endAddr, 16);
                int progLength = end - start;

                writer.WriteLine($"H.{progName}.{startAddr.PadLeft(6, '0')}.{progLength:X6}");

                // --- Text Records ---
                string currentRecord = "";
                string recordStart = "";
                int recordLength = 0;

                for (int i = 0; i < SourceLines.Count; i++)
                {
                    var line = SourceLines[i];
                    string loc = LOCCTRs[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    line.LOCCTR = Convert.ToInt32(loc, 16);

                    string objCode = GenerateObjectCode(line);
                    if (string.IsNullOrWhiteSpace(objCode))
                    {
                        // Only break the T record if it's RESW or RESB
                        string upperOpcode = line.Opcode.ToUpper();
                        if (upperOpcode == "RESW" || upperOpcode == "RESB")
                        {
                            if (recordLength > 0)
                            {
                                writer.WriteLine($"T.{recordStart.PadLeft(6, '0')}.{(recordLength):X2}.{currentRecord.Trim()}");
                                currentRecord = "";
                                recordLength = 0;
                            }
                        }

                        continue; // skip all non-object-code lines
                    }

                    if (recordLength == 0)
                        recordStart = loc;

                    // Limit to 30 Digits/15 Bytes
                    if ((recordLength + objCode.Length / 2) > 30)
                    {
                        writer.WriteLine($"T.{recordStart.PadLeft(6, '0')}.{(recordLength):X2}.{currentRecord.Trim()}");
                        recordStart = loc;
                        currentRecord = "";
                        recordLength = 0;
                    }

                    currentRecord += objCode + " ";
                    recordLength += objCode.Length / 2;
                }

                if (recordLength > 0)
                {
                    writer.WriteLine($"T.{recordStart.PadLeft(6, '0')}.{(recordLength):X2}.{currentRecord.Trim()}");
                }

                // --- M Records ---
                foreach (var mRecord in MRecords)
                {
                    writer.WriteLine(mRecord);
                }

                // --- End Record ---
                writer.WriteLine($"E.{startAddr.PadLeft(6, '0')}");
            }
        }
    }
}