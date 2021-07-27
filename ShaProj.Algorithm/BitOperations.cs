using System;
using System.Collections.Generic;
using System.Text;

namespace ShaProj.Algorithm
{
    public static class BitOperations
    {
        private const byte DEFAULT_WORD_SIZE = 32;

        // Adds all words (32 bit values) and returns the sum without the overflowing bits
        public static uint Add(params uint[] words)
        {
            uint memory = 0;

            for (int i = 0; i < words.Length; i++)
            {
                memory += words[i];
            }

            return memory;
        }

        // Rotates a word (32 bit value) to the right
        public static uint Rotate(uint word, int positions)
        {
            positions = ValidatePositions(positions);
            var mask = (uint)Math.Pow(2, DEFAULT_WORD_SIZE) - 1;

            var primaryShift = (word >> positions) & mask;
            var excessShift = (word << DEFAULT_WORD_SIZE - positions) & mask;

            return primaryShift | excessShift;
        }

        // Shifts a word (32 bit value) to the right
        public static uint Shift(uint word, int positions)
        {
            positions = ValidatePositions(positions);

            return word >> positions;
        }

        // Validates given positions to be under 32 bits
        private static int ValidatePositions(int positions)
        {
            return positions % DEFAULT_WORD_SIZE;
        }
    }
}
