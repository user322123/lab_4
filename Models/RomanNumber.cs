using System;
using System.Text;
using lab_1.ex;

namespace lab_1.lab_2
{
    class RomanNumber : ICloneable, IComparable
    {
        private ushort Number;

        private static short[] Values = new short[]
        { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        private static string[] Numerals = new string[]
        { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        private short ToShort()
        {
            short res = ((short)Number);
            return res;
        }

        public RomanNumber(ushort n)
        {
            short CheckException = ((short)n);
            if (n <= 0)
            {
                throw new RomanNumberException("InvalidValueException: Ожидалось, что число > 0");
            }
            Number = n;
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            ushort result = 0;
            short t1 = n1.ToShort();
            short t2 = n2.ToShort();
            short t3 = ((short)(t2 + t1));
            result = ((ushort)t3);
            RomanNumber res = new RomanNumber(result);
            return res;
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            ushort result = 0;
            short t1 = n1.ToShort();
            short t2 = n2.ToShort();
            short t3 = ((short)(t1 - t2));
            if (t3 <= 0)
            {
                throw new RomanNumberException("\nInvalidValueException: Ожидалось, что значение выражения (" + t3.ToString() + ") будет больше 0");
            }
            else
            {
                result = ((ushort)t3);
                RomanNumber res = new RomanNumber(result);
                return res;
            }
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            ushort result = 0;
            short t1 = n1.ToShort();
            short t2 = n2.ToShort();
            short t3 = ((short)(t2 * t1));
            result = ((ushort)t3);
            RomanNumber res = new RomanNumber(result);
            return res;
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            ushort result = 0;
            short t1 = n1.ToShort();
            short t2 = n2.ToShort();
            short t3 = ((short)(t1 / t2));
            if (t3 <= 0)
            {
                throw new RomanNumberException("InvalidValueException: Ожидалось, что результат выражение будет больше 0 (" + t3.ToString() + ")");
            }
            else
            {
                result = ((ushort)(t3));
                RomanNumber res = new RomanNumber(result);
                return res;
            }
        }

        public override string ToString()
        {
            StringBuilder NumberInRomanSystem = new StringBuilder();

            int Range = 13;

            short Temp = ((short)Number);

            for (int i = 0; i < Range; ++i)
            {
                while (Temp >= Values[i])
                {
                    Temp -= Values[i];
                    NumberInRomanSystem.Append(Numerals[i]);
                }
            }

            return NumberInRomanSystem.ToString();
        }

        public object Clone()
        {
            return new RomanNumber(Number);
        }

        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber rom) return ((short)Number).CompareTo(rom.ToShort());
            else throw new RomanNumberException("InvaludValueException: Некорректное значение параметра");
        }
    }
}