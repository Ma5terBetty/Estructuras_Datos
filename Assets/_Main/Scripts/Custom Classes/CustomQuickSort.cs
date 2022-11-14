using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public struct CustomQuickSort
{
    public static ISortable[] Sort(ISortable[] array, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = array[leftIndex];

        while (i <= j)
        {
            while (array[i].SortValue < pivot.SortValue)
            {
                i++;
            }

            while (array[j].SortValue > pivot.SortValue)
            {
                j--;
            }

            if (i <= j)
            {
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            Sort(array, leftIndex, j);
        if (i < rightIndex)
            Sort(array, i, rightIndex);
            
        return array;
    }
    
    public static List<ISortable> Sort(List<ISortable> list, int leftIndex, int rightIndex)
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = list[leftIndex];

        while (i <= j)
        {
            while (list[i].SortValue < pivot.SortValue)
            {
                i++;
            }

            while (list[j].SortValue > pivot.SortValue)
            {
                j--;
            }

            if (i <= j)
            {
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                i++;
                j--;
            }
        }

        if (leftIndex < j)
            Sort(list, leftIndex, j);
        if (i < rightIndex)
            Sort(list, i, rightIndex);
            
        return list;
    }
}