using lab_1.ex;
using lab_1.lab_2;

namespace lab4.Models
{
    class RomanNumberExtend : RomanNumber
    {


        private static short[] Values = new short[]
        { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };


        private static string[] Numerals = new string[]
        { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public RomanNumberExtend(string number) : base(ToUShort(number)) {  }
        private static ushort ToUShort(string x)
        {
            short t = 0;
            string t2 = x;
            for (int i = 0; i < Numerals.Length;)
            {
                if (t2.Contains(Numerals[i]))
                {
                    int t1 = t2.IndexOf(Numerals[i][0]);
                    t2 = t2.Remove(t1, Numerals[i].Length);
                    t += Values[i];
                }
                else
                {
                    ++i;
                }
            }
            return ((ushort)t);
        }
    }
}
