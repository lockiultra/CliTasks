using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class QuickSort
    {
        public int Partition(int[] Array, int Start, int End)
        {
            int Temp;
            int Marker = Start;
            for (int i = Start; i <= End; i++)
            {
                if (Array[i] < Array[End])
                {
                    Temp = Array[Marker];
                    Array[Marker] = Array[i];
                    Array[i] = Temp;
                    Marker++;
                }
            }

            Temp = Array[Marker];
            Array[Marker] = Array[End];
            Array[End] = Temp;
            return Marker;
        }

        public void quickSort(int[] Array, int Start, int End)
        {
            if (Start >= End)
            {
                return;
            }
            int Pivot = Partition(Array, Start, End);
            quickSort(Array, Start, Pivot-1);
            quickSort(Array, Pivot+1, End);
        }

        /***********************************************************************************************/
    }

    public static class Qsort
    {
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            if (!list.Any())
            {
                return Enumerable.Empty<T>();
            }
            var pivot = list.First();
            var smaller = list.Skip(1).Where(item => item.CompareTo(pivot) <= 0).QuickSort();
            var larger = list.Skip(1).Where(item => item.CompareTo(pivot) > 0).QuickSort();

            return smaller.Concat(new[] { pivot }).Concat(larger);
        }

        public static IEnumerable<T> shortQuickSort<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            return !list.Any() ? Enumerable.Empty<T>() : list.Skip(1).Where(
                item => item.CompareTo(list.First()) <= 0).shortQuickSort().Concat(new[] { list.First() })
                    .Concat(list.Skip(1).Where(item => item.CompareTo(list.First()) > 0).shortQuickSort());
        }
    }
}
