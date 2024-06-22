using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class ThreeWayMergeSort
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Sort(ref int[] list)
        {
            if (list != null)
            {
                int length = list.Length;
                if (length > 1)
                {
                    int[] tempArray = new int[length];
                    fixed (int* listPtr = list, tempPtr = tempArray)
                    {
                        TMSort(listPtr, tempPtr, 0, length - 1);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe void TMSort(int* listPtr, int* tempPtr, int left, int right)
        {
            if (left >= right)
                return;

            int third = (right - left + 1) / 3;
            int mid1 = left + third;
            int mid2 = left + 2 * third + 1;

            TMSort(listPtr, tempPtr, left, mid1 - 1);
            TMSort(listPtr, tempPtr, mid1, mid2 - 1);
            TMSort(listPtr, tempPtr, mid2, right);

            Merge(listPtr, tempPtr, left, mid1 - 1, mid2 - 1, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe void Merge(int* listPtr, int* tempPtr, int left, int mid1, int mid2, int right)
        {
            int leftEnd = mid1 - left + 1;
            int middleEnd = mid2 - mid1;
            int rightEnd = right - mid2 + 1;

            Buffer.MemoryCopy(listPtr + left, tempPtr + left, (leftEnd + middleEnd + rightEnd) * sizeof(int), (leftEnd + middleEnd + rightEnd) * sizeof(int));

            int i = left, j = mid1 + 1, k = mid2 + 1, l = left;

            while (i <= mid1 && j <= mid2 && k <= right)
            {
                if (tempPtr[i] <= tempPtr[j] && tempPtr[i] <= tempPtr[k])
                {
                    listPtr[l++] = tempPtr[i++];
                }
                else if (tempPtr[j] <= tempPtr[i] && tempPtr[j] <= tempPtr[k])
                {
                    listPtr[l++] = tempPtr[j++];
                }
                else
                {
                    listPtr[l++] = tempPtr[k++];
                }
            }

            while (i <= mid1 && j <= mid2)
            {
                if (tempPtr[i] <= tempPtr[j])
                {
                    listPtr[l++] = tempPtr[i++];
                }
                else
                {
                    listPtr[l++] = tempPtr[j++];
                }
            }

            while (j <= mid2 && k <= right)
            {
                if (tempPtr[j] <= tempPtr[k])
                {
                    listPtr[l++] = tempPtr[j++];
                }
                else
                {
                    listPtr[l++] = tempPtr[k++];
                }
            }

            while (i <= mid1 && k <= right)
            {
                if (tempPtr[i] <= tempPtr[k])
                {
                    listPtr[l++] = tempPtr[i++];
                }
                else
                {
                    listPtr[l++] = tempPtr[k++];
                }
            }

            while (i <= mid1)
            {
                listPtr[l++] = tempPtr[i++];
            }

            while (j <= mid2)
            {
                listPtr[l++] = tempPtr[j++];
            }

            while (k <= right)
            {
                listPtr[l++] = tempPtr[k++];
            }
        }
    }
}
