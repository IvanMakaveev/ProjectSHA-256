using System;

namespace ShaProj.Algorithm
{
    public static class BitOperations
    {
        private const byte DEFAULT_WORD_SIZE = 32;

        // Creates a new word (32 bit value) based on the majority of values for each bit in the three given words
        public static uint Majority(uint firstWord, uint secondWord, uint thirdWord)
        {
            return (firstWord & secondWord) | (secondWord & thirdWord) | (thirdWord & firstWord);
        }

        // Creates a new word (32 bit value) based on the bits in the first and second word
        // For each bit with a value of 1 in the mask word, it takes a bit from the first word
        // For each bit with a value of 0 in the mask word, it takes a bit from the second word
        public static uint Choose(uint maskWord, uint firstWord, uint secondWord)
        {
            return (maskWord & firstWord) ^ (~maskWord & secondWord);
        }

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
