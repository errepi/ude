// Udetect.cs created with MonoDevelop
//
// Author:
//    Rudi Pettazzi <rudi.pettazzi@gmail.com>
//

using System;
using System.Diagnostics;
using System.IO;

namespace Ude.Example {

    public class Udetect {
        /// <summary>
        ///     Command line example: detects the encoding of the given file.
        /// </summary>
        /// <param name="args">a filename</param>
        public static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Usage: udetect <filename>");
                return;
            }

            var filename = args[0];
            using (var fs = File.OpenRead(filename)) {
                ICharsetDetector cdet = new CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();

                Console.WriteLine();
                if (cdet.Charset != null) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Charset: {0}, confidence: {1}", cdet.Charset, cdet.Confidence);
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Detection failed.");
                }
                Console.ResetColor();
            }

            Exit();
        }

        [Conditional("DEBUG")]
        private static void Exit() {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press [ENTER] to exit...");
            Console.ReadLine();
        }
    }

}
