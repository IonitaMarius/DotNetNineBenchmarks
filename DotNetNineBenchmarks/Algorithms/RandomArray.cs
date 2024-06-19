using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class RandomArray
    {
        private static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();
        private static readonly Random random = new Random((int)DateTime.UtcNow.Ticks);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte[] GenerateRandomBytes(long length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be non-negative.");

            byte[] byteArray = new byte[length];
            rng.GetBytes(byteArray);
            return byteArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int[] GenerateRandomInts(long length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be non-negative.");

            int[] intsArray = new int[length];
            for (long i = 0; i < length; i++)
                intsArray[i] = random.Next();

            return intsArray;
        }
    }
}
