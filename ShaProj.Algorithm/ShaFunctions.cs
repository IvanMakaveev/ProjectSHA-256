using System.Collections.Generic;

namespace ShaProj.Algorithm
{
    public static class ShaFunctions
    {
        // Constant input values for each operation in the sigma functions
        private static IList<byte> LOWER_SIGMA_ZERO = new byte[] { 7, 18, 3 };
        private static IList<byte> LOWER_SIGMA_ONE = new byte[] { 17, 19, 10 };
        private static IList<byte> UPPER_SIGMA_ZERO = new byte[] { 2, 13, 22 };
        private static IList<byte> UPPER_SIGMA_ONE = new byte[] { 6, 11, 25 };

        public static uint LowerSigmaZero(uint word) => LowerSigma(word, LOWER_SIGMA_ZERO);
        public static uint LowerSigmaOne(uint word) => LowerSigma(word, LOWER_SIGMA_ONE);
        public static uint UpperSigmaZero(uint word) => UpperSigma(word, UPPER_SIGMA_ZERO);
        public static uint UpperSigmaOne(uint word) => UpperSigma(word, UPPER_SIGMA_ONE);

        private static uint LowerSigma(uint word, IList<byte> shifts)
        {
            var result = 
                BitOperations.Rotate(word, shifts[0]) ^ 
                BitOperations.Rotate(word, shifts[1]) ^
                BitOperations.Shift(word, shifts[2]);

            return result;
        }

        private static uint UpperSigma(uint word, IList<byte> shifts)
        {
            var result =
                BitOperations.Rotate(word, shifts[0]) ^
                BitOperations.Rotate(word, shifts[1]) ^
                BitOperations.Rotate(word, shifts[2]);

            return result;
        }
    }
}
