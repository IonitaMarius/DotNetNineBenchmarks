using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class BWT
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe string Transform(string input)
        {
            int length = input.Length;
            var suffixes = new int[length];
            var result = new char[length];
            int lastCharIndex = length - 1;

            for (int i = 0; i < length; i++)
                suffixes[i] = i;

            fixed (char* p = input)
            {
                var comparer = new PointerSuffixComparer(p, length);
                Array.Sort(suffixes, comparer.Compare);
            }

            for (int i = 0; i < length; i++)
            {
                int tempIndex = suffixes[i] + lastCharIndex;
                if (tempIndex >= length)
                    tempIndex -= length;
                result[i] = input[tempIndex];
            }

            return new string(result);
        }
    }
}
