using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class MergeSort 
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
                        MSort(listPtr, tempPtr, length);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe void MSort(int* listPtr, int* tempPtr, int length)
        {
            for (int currSize = 1; currSize <= length - 1; currSize *= 2)
            {
                for (int leftStart = 0; leftStart < length - 1; leftStart += 2 * currSize)
                {
                    int mid = Math.Min(leftStart + currSize - 1, length - 1);
                    int rightEnd = Math.Min(leftStart + 2 * currSize - 1, length - 1);
                    Merge(listPtr, tempPtr, leftStart, mid, rightEnd);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe void Merge(int* listPtr, int* tempPtr, int left, int middle, int right)
        {
            int leftEnd = middle - left + 1;
            int rightEnd = right - middle;

            Buffer.MemoryCopy(listPtr + left, tempPtr + left, (leftEnd + rightEnd) * sizeof(int), (leftEnd + rightEnd) * sizeof(int));

            int i = left;
            int j = middle + 1;
            int k = left;

            // Merging the two halves
            while (i <= middle && j <= right)
            {
                if (tempPtr[i] <= tempPtr[j])
                {
                    listPtr[k++] = tempPtr[i++];
                }
                else
                {
                    listPtr[k++] = tempPtr[j++];
                }
            }

            // Copy remaining elements of left half, if any
            while (i <= middle)
            {
                listPtr[k++] = tempPtr[i++];
            }

            // Copy remaining elements of right half, if any
            while (j <= right)
            {
                listPtr[k++] = tempPtr[j++];
            }
        }
    }
}
