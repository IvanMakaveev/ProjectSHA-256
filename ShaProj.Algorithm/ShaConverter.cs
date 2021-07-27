using System;
using System.Linq;

namespace ShaProj.Algorithm
{
    public static class ShaConverter
    {
        private const byte DEFAULT_SIZE_BITS = 64;
        private const short DEFAULT_MESSAGE_BLOCK_SIZE = 512;

        public static void Hash(byte[] data)
        {
            var message = PrepareBaseMessage(data);
            var paddingZeros = GetPaddingZeros(message.Length);
            var lengthBits = GetLengthBits(message.Length);

            message = string.Concat(message + '1' + new string('0', paddingZeros) + lengthBits);
            Console.WriteLine(message);
        }

        private static string PrepareBaseMessage(byte[] data)
        {
            return string.Join("", data.Select(x => Convert.ToString(x, toBase:2).PadLeft(8, '0')));
        }

        private static int GetPaddingZeros(int length)
        {
            var symbols = length + DEFAULT_SIZE_BITS + 1;
            return DEFAULT_MESSAGE_BLOCK_SIZE - symbols % DEFAULT_MESSAGE_BLOCK_SIZE;
        }

        private static string GetLengthBits(int length)
        {
            return Convert.ToString(length, toBase: 2).PadLeft(DEFAULT_SIZE_BITS, '0');
        }
    }
}
