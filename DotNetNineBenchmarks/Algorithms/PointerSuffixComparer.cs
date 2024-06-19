using System.Runtime.CompilerServices;

namespace DotNetNineBenchmarks.Algorithms
{
    public class PointerSuffixComparer
    {
        private unsafe readonly char* _p;
        private readonly int _length;

        public unsafe PointerSuffixComparer(char* p, int length)
        {
            _p = p;
            _length = length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe int Compare(int a, int b)
        {
            int length = _length;
            char* ptr = _p + a;
            char* ptr2 = _p + b;
            char* ptr3 = _p + length;
            while (ptr + 4 <= ptr3 && ptr2 + 4 <= ptr3)
            {
                long num = *(long*)ptr;
                long num2 = *(long*)ptr2;
                if (num != num2)
                {
                    if (*ptr != *ptr2)
                        return *ptr - *ptr2;

                    if (ptr[1] != ptr2[1])
                        return ptr[1] - ptr2[1];

                    if (ptr[2] != ptr2[2])
                        return ptr[2] - ptr2[2];

                    if (ptr[3] != ptr2[3])
                        return ptr[3] - ptr2[3];
                }
                ptr += 4;
                ptr2 += 4;
            }

            while (ptr < ptr3 && ptr2 < ptr3)
            {
                int num3 = *ptr - *ptr2;
                if (num3 != 0)
                    return num3;

                ptr++;
                ptr2++;
            }

            return ((ptr < ptr3) ? 1 : 0) - ((ptr2 < ptr3) ? 1 : 0);
        }
    }
}
