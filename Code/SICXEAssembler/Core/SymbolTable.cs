using System.Collections.Generic;

namespace SICAssembler.Core
{
    public class SymbolTable
    {
        private Dictionary<string, int> table = new Dictionary<string, int>();

        public bool Add(string label, int address)
        {
            if (!string.IsNullOrEmpty(label) && !table.ContainsKey(label))
            {
                table[label] = address;
                return true;
            }
            return false;
        }

        public int? GetAddress(string label)
        {
            if (table.ContainsKey(label))
                return table[label];
            return null;
        }

        public Dictionary<string, int> GetAll()
        {
            return table;
        }
    }
}