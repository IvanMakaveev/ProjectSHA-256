using System;
using System.Linq;
using System.Collections.Generic;

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

        // This converts the fractional part of each cubic root of the prime numbers to a 32 bit numeric value
        public static IList<uint> Constants
            => PRIME_NUMBERS.Select(x => {
                var fractional = Math.Round(Math.Pow(x, 1.0 / 3) - Math.Floor(Math.Pow(x, 1.0 / 3)), 12);
                return (uint)Math.Floor(fractional * Math.Pow(2, 32));
            }).ToList();


        // This converts the fractional part of each square root of the first 8 prime numbers to a 32 bit numeric value
        public static IList<uint> InitialStateRegisters
            => PRIME_NUMBERS.Take(8).Select(x => {
                var fractional = Math.Round(Math.Sqrt(x) - Math.Floor(Math.Sqrt(x)), 12);
                return (uint)Math.Floor(fractional * Math.Pow(2, 32));
            }).ToList();
    }
}
