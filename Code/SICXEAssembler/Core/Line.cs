namespace SICAssembler.Core
{
    public class Line
    {
        public int LineNumber { get; set; }
        public string Label { get; set; } = "";
        public string Opcode { get; set; } = "";
        public string Operand { get; set; } = "";
        public string Comment { get; set; } = "";
        public int? LOCCTR { get; set; } = null;
        public bool IsIndexed { get; set; } = false;
        public override string ToString()
        {
            return $"{Label,-10}{Opcode,-10}{Operand,-10}{Comment}";
        }
    }
}