using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class BinarySearch
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Search(Span<int> list, int target, int prevIndex = 0)
        {
            int num = prevIndex;
            int num2 = list.Length - 1;

            while (num <= num2)
            {
                int num3 = num + num2 >> 1;
                if (list[num3] == target)
                    return num3;

                if (list[num3] < target)
                    num = num3 + 1;
                else
                    num2 = num3 - 1;
            }
            return -1;
        }
    }
}
