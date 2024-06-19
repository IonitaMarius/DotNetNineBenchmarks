using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class InsertionSort
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe void Sort(string[] list)
        {
            int length = list.Length;

            fixed (string* ptr = list)
            {
                for (int i = 1; i < length; i++)
                {
                    string temp = ptr[i];
                    int hash = temp.GetHashCode();
                    int insertionIndex = BinarySearch.Search(new Span<int>((int*)ptr, length), hash, 0);
                    for (int j = i - 1; j >= insertionIndex; j--)
                        ptr[j + 1] = ptr[j];

                    ptr[insertionIndex] = temp;
                }
            }
        }
    }
}
