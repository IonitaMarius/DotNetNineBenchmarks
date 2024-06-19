using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class ByteToHex
    {
        private static char[] HexAlphabet = new char[] { '0', '1', '2', '3', '4', '5', '6', '7',
                                                         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'
                                                       };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe string UnsafeSpanToHexadecimal(ReadOnlySpan<byte> input)
        {
            int length = input.Length;
            char[] c = new char[length * 2];

            fixed (byte* inputPtr = input)
            fixed (char* cPtr = c)
            fixed (char* hexPtr = HexAlphabet)
            {
                byte* inputBytes = inputPtr;
                char* cChars = cPtr;
                char* hexChars = hexPtr;

                int i = 0;
                for (; i <= length - 8; i += 8)
                {
                    byte b0 = inputBytes[i];
                    byte b1 = inputBytes[i + 1];
                    byte b2 = inputBytes[i + 2];
                    byte b3 = inputBytes[i + 3];
                    byte b4 = inputBytes[i + 4];
                    byte b5 = inputBytes[i + 5];
                    byte b6 = inputBytes[i + 6];
                    byte b7 = inputBytes[i + 7];

                    int index = i << 1;
                    cChars[index] = hexChars[b0 >> 4];
                    cChars[index + 1] = hexChars[b0 & 0xF];

                    cChars[index + 2] = hexChars[b1 >> 4];
                    cChars[index + 3] = hexChars[b1 & 0xF];

                    cChars[index + 4] = hexChars[b2 >> 4];
                    cChars[index + 5] = hexChars[b2 & 0xF];

                    cChars[index + 6] = hexChars[b3 >> 4];
                    cChars[index + 7] = hexChars[b3 & 0xF];

                    cChars[index + 8] = hexChars[b4 >> 4];
                    cChars[index + 9] = hexChars[b4 & 0xF];

                    cChars[index + 10] = hexChars[b5 >> 4];
                    cChars[index + 11] = hexChars[b5 & 0xF];

                    cChars[index + 12] = hexChars[b6 >> 4];
                    cChars[index + 13] = hexChars[b6 & 0xF];

                    cChars[index + 14] = hexChars[b7 >> 4];
                    cChars[index + 15] = hexChars[b7 & 0xF];
                }

                for (; i < length; i++)
                {
                    byte b = inputBytes[i];
                    int index = i << 1;
                    cChars[index] = hexChars[b >> 4];
                    cChars[index + 1] = hexChars[b & 0xF];
                }
            }

            return new string(c);
        }
    }
}
