namespace PasswordGen.Services
{
    public class EntropyCalculator
    {
        public double CalculateEntropy(int length, bool lower, bool upper, bool digits, bool symbols, bool excludeSimilar)
        {
            int pool = 0;
            int lowerCount = 26, upperCount = 26, digitCount = 10, symbolCount = 28;

            if (excludeSimilar)
            {
                lowerCount -= 2;
                upperCount -= 2;
                digitCount -= 2;
            }

            if (lower) pool += lowerCount;
            if (upper) pool += upperCount;
            if (digits) pool += digitCount;
            if (symbols) pool += symbolCount;

            return length * Math.Log2(pool);
        }
    }
}