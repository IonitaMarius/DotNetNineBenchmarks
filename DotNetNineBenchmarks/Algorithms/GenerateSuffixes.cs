using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class GenerateSuffixes
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe string[] UnsafeWhileFromSpan(ReadOnlySpan<char> input)
        {
            int length = input.Length;
            string[] array = new string[length];
            fixed (char* inputPtr = input)
            {
                for (int i = 0; i < length; i++)
                    array[i] = new string(inputPtr + i, 0, length - i);
            }

            return array;
        }
    }
}
