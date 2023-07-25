using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15
{
    internal class Program
    {
        public static void QuickSort(int[] quickie,int low,int high)
        {
            if (low < high)
            {
                int pivot = quickie[low];
                int i = low, j = high;
                while (i < j)
                {
                    i = i + 1;
                    while (i <= high && quickie[i] < pivot)
                        i++;
                    while (j >= low && quickie[j] > pivot)
                        j--;
                    if (i < j && i <= high)
                        Swap(quickie, i, j);
                }
                Swap(quickie, low, j);
                QuickSort(quickie, low, j - 1);
                QuickSort(quickie, j + 1, high);
            }
        }
        public static void MergeSort(int[] merger)
        {
            MergeSort(merger, 0, merger.Length - 1);
        }
        public static void MergeSort(int[] merger,int low,int high)
        {
            if (low < high)
            {
                int mid = low+(high - low) / 2;
                MergeSort(merger, low, mid);
                MergeSort(merger, mid + 1, high);
                MergeSort(merger, low, mid, high);
            }
        }
        public static void MergeSort(int[] merger,int low,int mid,int high)
        {
            int m = mid - low+1;
            int n = high - mid;
            int[] arr1 = new int[m];
            int[] arr2 = new int[n];
            for (int x = 0; x < m; x++)
                arr1[x] = merger[x + low];
            for (int y = 0; y < n; y++)
                arr2[y] = merger[y + mid + 1];
            int i = 0, j = 0, k = low;
            while(i<m && j < n)
            {
                if (arr1[i] < arr2[j])
                    merger[k++] = arr1[i++];
                else
                    merger[k++] = arr2[j++];
            }
            while (i < m)
                merger[k++] = arr1[i++];
            while (j < n)
                merger[k++] = arr2[j++];
        }
        public static void Swap(int[] quickie,int i,int j)
        {
            int temp = quickie[i];
            quickie[i] = quickie[j];
            quickie[j] = temp;
        }
        public static bool Validation(int[] quickie)
        {
            for(int i = 0; i < quickie.Length-1; i++)
            {
                if (quickie[i] > quickie[i + 1])
                    return false;
            }
            return true;
        }
        public static void Sorting(int[] quickie)
        {
            Stopwatch watch = new Stopwatch();
            Generator(quickie);
            //Print(quickie);
            watch.Start();
            QuickSort(quickie, 0, quickie.Length - 1);
            watch.Stop();
            if(Validation(quickie))
                Console.WriteLine($"Array of Length {quickie.Length} is sorted in {watch.Elapsed.TotalMilliseconds} milliseconds");
            else
                Console.WriteLine("Array is not Sorted correctly");
            //Print(quickie);
            Console.WriteLine();
        }
        public static double quickSorting(int[] quickie)
        {
            Stopwatch watch = new Stopwatch();
            Generator(quickie);
            watch.Start();
            QuickSort(quickie, 0, quickie.Length - 1);
            watch.Stop();
            double timing = 0;
            if (Validation(quickie))
                timing = watch.Elapsed.TotalMilliseconds;
            return timing;
        }
        public static double mergeSorting(int[] quickie)
        {
            Stopwatch watch = new Stopwatch();
            Generator(quickie);
            watch.Start();
            MergeSort(quickie, 0, quickie.Length - 1);
            watch.Stop();
            double timing = 0;
            if (Validation(quickie))
                timing = watch.Elapsed.TotalMilliseconds;
            return timing;
        }
        public static void Generator(int[] quickie)
        {
            Random rand = new Random();
            for (int i = 0; i < quickie.Length; i++)
                quickie[i] = rand.Next(100);
        }
        public static void Print(int[] quickie)
        {
            for(int i = 0; i < quickie.Length;i++)
                Console.Write(quickie[i]+" ");
            Console.WriteLine();
        }
        public static void Analysis()
        {
            int[] quick = new int[15];
            int[] merge = new int[15];
            double quickTime = quickSorting(quick);
            double mergeTime = mergeSorting(merge);
            if(quickTime<mergeTime)
                Console.WriteLine($"Quick Sorting of Array of Length {quick.Length} is faster than Merge Sorting of Array of Length of {merge.Length}\n   QuickSort : {quickTime}\t MergeSort : {mergeTime}");
            else
                Console.WriteLine($"Merge Sorting of Array of Length {merge.Length} is faster than Quick Sorting of Array of Length of {quick.Length}\n   MergeSort : {mergeTime}\t QuickSort : {quickTime}");
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Array of 20 Elements");
                int[] quickie1 = new int[20];
                Sorting(quickie1);
                Console.WriteLine("Array of 30 Elements");
                int[] quickie2 = new int[30];
                Sorting(quickie2);
                Console.WriteLine("Array of 50 Elements");
                int[] quickie3 = new int[50];
                Sorting(quickie3);
                Analysis();
            }
            catch(Exception ec)
            {
                Console.WriteLine(ec.Message);
            }
        }
    }
}
