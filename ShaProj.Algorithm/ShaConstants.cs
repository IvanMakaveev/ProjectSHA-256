using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShaProj.Algorithm
{
    public static class ShaConstants
    {
        // The first 64 prime numbers
        private static IList<short> PRIME_NUMBERS =
            new short[] { 
                2, 3, 5, 7, 11, 13, 17, 19, 
                23, 29, 31, 37, 41, 43, 47, 53,
                59, 61, 67, 71, 73, 79, 83, 89,
                97, 101, 103, 107, 109, 113, 127, 131,
                137, 139, 149, 151, 157, 163, 167, 173,
                179, 181, 191, 193, 197, 199, 211, 223,
                227, 229, 233, 239, 241, 251, 257, 263,
                269, 271, 277, 281, 283, 293, 307, 311 };

        // This converts the fractional part of each cubic root of the prime numbers to hex value
        // Each hex value is then returned as a 32 bit numeric value
        public static IList<uint> Constants
            => PRIME_NUMBERS.Select(x => {
                var fractional = Math.Round(Math.Pow(x, 1.0 / 3) - Math.Floor(Math.Pow(x, 1.0 / 3)), 12);

                var hex = new List<string>();

                for (int i = 0; i < 8; i++)
                {
                    var product = fractional * 16;
                    var carry = (int)Math.Floor(product);
                    fractional = product - carry;
                    hex.Add(Convert.ToString(carry, toBase:16));
                }

                return Convert.ToUInt32(string.Join("", hex), 16);
            }).ToList();
    }
}
