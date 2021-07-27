// System Libraries
using System;
using System.Collections.Generic;

// Downloaded Libraries
using Figgle;

// Project Libraries
using ShaProj.Algorithm;

namespace ShaProj
{
    class Program
    {
        // A SandBox for testing methods
        static IList<uint> SandBox()
        {
            // Expected output: 0b11110001111111111100011110000000
            return ShaConstants.Constants;
        }

        // Format the output of the SandBox
        static void Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Hello Sandbox!"));
            Console.WriteLine(new string('=', 120));
            Console.WriteLine();

            var res = SandBox();
            foreach (var item in res)
            {
                Console.WriteLine(GetBinaryValue(item));
            }

            Console.WriteLine();
            Console.WriteLine(new string('=', 120));
        }

        // Turns a 32 bit value into a string in binary format
        static string GetBinaryValue(uint number)
        {
            return Convert.ToString(number, toBase: 16).PadLeft(8, '0');
        }
    }
}
