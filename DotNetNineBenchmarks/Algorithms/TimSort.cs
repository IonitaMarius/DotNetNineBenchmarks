using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class TimSort
    {
        private const int RUN = 32;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sort(string[] list)
        {
            int length = list.Length;

            // Sort individual subarrays of size RUN
            for (int i = 0; i < length; i += RUN)
            {
                int end = Math.Min(i + RUN - 1, length - 1);
                InsertionSort(list, i, end);
            }

            // Start merging from size RUN
            for (int size = RUN; size < length; size = 2 * size)
            {
                for (int left = 0; left < length; left += 2 * size)
                {
                    int mid = Math.Min(left + size - 1, length - 1);
                    int right = Math.Min(left + 2 * size - 1, length - 1);

                    if (mid < right)
                    {
                        Merge(list, left, mid, right);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void InsertionSort(string[] list, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                string temp = list[i];
                int j = i - 1;
                while (j >= left && string.Compare(list[j], temp, StringComparison.Ordinal) > 0)
                {
                    list[j + 1] = list[j];
                    j--;
                }
                list[j + 1] = temp;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Merge(string[] list, int left, int mid, int right)
        {
            int len1 = mid - left + 1;
            int len2 = right - mid;

            Span<string> leftArr = new Span<string>(list, left, len1);
            Span<string> rightArr = new Span<string>(list, mid + 1, len2);

            int iLeft = 0, iRight = 0, iMerged = left;

            while (iLeft < len1 && iRight < len2)
            {
                if (string.Compare(leftArr[iLeft], rightArr[iRight], StringComparison.Ordinal) <= 0)
                {
                    list[iMerged] = leftArr[iLeft];
                    iLeft++;
                }
                else
                {
                    list[iMerged] = rightArr[iRight];
                    iRight++;
                }
                iMerged++;
            }

            while (iLeft < len1)
            {
                list[iMerged] = leftArr[iLeft];
                iLeft++;
                iMerged++;
            }

            while (iRight < len2)
            {
                list[iMerged] = rightArr[iRight];
                iRight++;
                iMerged++;
            }
        }
    }
}
