// System Libraries
using System;

// Downloaded Libraries
using Figgle;

// Project Libraries
using ShaProj.Algorithm;

namespace ShaProj
{
    class Program
    {
        // A SandBox for testing methods
        static uint SandBox()
        {
            return BitOperations.Shift(0b00000000111111110000000011111111, 8);
        }

        // Format the output of the SandBox
        static void Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Hello Sandbox!"));
            Console.WriteLine(new string('=', 120));
            Console.WriteLine();

            var res = SandBox();
            Console.WriteLine(GetBinaryValue(res));

            Console.WriteLine();
            Console.WriteLine(new string('=', 120));
        }

        // Turns a 32 bit value into a string in binary format
        static string GetBinaryValue(uint number)
        {
            return Convert.ToString(number, toBase: 2).PadLeft(32, '0');
        }
    }
}
