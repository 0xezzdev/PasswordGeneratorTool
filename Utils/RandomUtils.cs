using System;
using System.Security.Cryptography;

namespace PasswordGen.Utils
{
    public static class RandomUtils
    {
        public static char RandomChar(string set)
        {
            byte[] rb = new byte[4];
            int max = int.MaxValue - (int.MaxValue % set.Length);

            while (true)
            {
                RandomNumberGenerator.Fill(rb);
                int val = BitConverter.ToInt32(rb, 0) & int.MaxValue;
                if (val < max) return set[val % set.Length];
            }
        }

        public static void Shuffle(char[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = GetRandomInt(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }

        private static int GetRandomInt(int exclusiveMax)
        {
            byte[] rb = new byte[4];
            int max = int.MaxValue - (int.MaxValue % exclusiveMax);

            while (true)
            {
                RandomNumberGenerator.Fill(rb);
                int val = BitConverter.ToInt32(rb, 0) & int.MaxValue;
                if (val < max) return val % exclusiveMax;
            }
        }
    }
}