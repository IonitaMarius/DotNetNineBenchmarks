using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public static class BubbleSort
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void Sort(string[] list)
        {
            int num = list.Length;
            if (num <= 1)
                return;

            fixed (string* ptr = &list[0])
            {
                for (int i = 0; i < num - 1; i++)
                {
                    bool flag = false;
                    string* ptr2 = ptr;
                    string* ptr3 = ptr + 1;
                    for (int j = 0; j < num - i - 1; j++)
                    {
                        if (string.CompareOrdinal(*ptr2, *ptr3) > 0)
                        {
                            string text = *ptr2;
                            *ptr2 = *ptr3;
                            *ptr3 = text;
                            flag = true;
                        }
                        ptr2++;
                        ptr3++;
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
        }
    }
}
