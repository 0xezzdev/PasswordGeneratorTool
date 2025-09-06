using PasswordGen.Utils;
using System;
using System.Linq;

namespace PasswordGen.Services
{
    public class PasswordGenerator
    {
        private readonly int _length;
        private readonly bool _useLower, _useUpper, _useDigits, _useSymbols, _excludeSimilar;

        private readonly string _lowerSet = "abcdefghijklmnopqrstuvwxyz";
        private readonly string _upperSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string _digitSet = "0123456789";
        private readonly string _symbolSet = "!@#$%^&*()-=+[]{};:,.<>/?";
        private readonly string _similar = "O0oIl1|";

        public PasswordGenerator(int length, bool useLower, bool useUpper, bool useDigits, bool useSymbols, bool excludeSimilar)
        {
            _length = length;
            _useLower = useLower;
            _useUpper = useUpper;
            _useDigits = useDigits;
            _useSymbols = useSymbols;
            _excludeSimilar = excludeSimilar;
        }

        public string Generate()
        {
            var pools = BuildPools();

            if (pools.Length == 0)
                throw new InvalidOperationException("No characters to choose from.");

            var chars = new char[_length];
            int idx = 0;

            foreach (var pool in pools)
                chars[idx++] = RandomUtils.RandomChar(pool.set);

            string all = string.Concat(pools.Select(p => p.set).Distinct());
            for (; idx < _length; idx++)
                chars[idx] = RandomUtils.RandomChar(all);

            RandomUtils.Shuffle(chars);
            return new string(chars);
        }

        private (bool use, string set)[] BuildPools()
        {
            string lower = _lowerSet, upper = _upperSet, digits = _digitSet, symbols = _symbolSet;

            if (_excludeSimilar)
            {
                foreach (var ch in _similar)
                {
                    lower = lower.Replace(ch.ToString(), "", StringComparison.OrdinalIgnoreCase);
                    upper = upper.Replace(ch.ToString(), "", StringComparison.OrdinalIgnoreCase);
                    digits = digits.Replace(ch.ToString(), "", StringComparison.OrdinalIgnoreCase);
                }
            }

            return new (bool, string)[] {
                (_useLower, lower),
                (_useUpper, upper),
                (_useDigits, digits),
                (_useSymbols, symbols)
            }.Where(p => p.Item1 && p.Item2.Length > 0).ToArray();
        }
    }
}