using PasswordGen.Services;
using System;
using System.Text;

namespace PasswordGen
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Password Generator");
            Console.Write("Enter the desired password length (e.g., 16): ");

            int length = int.TryParse(Console.ReadLine(), out var len) && len > 0 ? len : 16;

            var generator = new PasswordGenerator(length, true, true, true, true, true);
            string password = generator.Generate();

            Console.WriteLine($"\nGenerated password: {password}");

            var entropyCalc = new EntropyCalculator();
            double entropy = entropyCalc.CalculateEntropy(length, true, true, true, true, true);
            Console.WriteLine($"Entropy: {entropy:F1} bits\n");
        }
    }
}