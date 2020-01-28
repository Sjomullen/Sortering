using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sortering_Algortimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose sorting algorithm");
            Console.WriteLine("1.Bubblesorting");
            Console.WriteLine("2.Insertionsorting");
            Console.WriteLine("3.Mergesorting");
            int choice = 0;

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Not an acceptable character");
                System.Environment.Exit(0);
            }
 
            int length = 100000;
            int[] Bubbel = new int[length];
            int x = 0;
            Random random = new Random();


            while (x < length)
            {
                Bubbel[x] = random.Next(1, 100);
                Console.Write(Bubbel[x] + " ");
                x++;
            }

            var watch = Stopwatch.StartNew();

            switch (choice)
            {
                case 1:
                    BubbleSort(Bubbel);
                    for (int y = 0; y < Bubbel.Length; y++)
                    {
                        Console.Write(Bubbel[y] + " ");
                    }
                    break;
                case 2:
                    InsertionSort(Bubbel);
                    for (int y = 0; y < Bubbel.Length; y++)
                    {
                        Console.Write(Bubbel[y] + " ");
                    }
                    break;
                case 3:
                    List<int> unsorted = new List<int>(Bubbel);
                    List<int> sorted;
                    sorted = MergeSort(unsorted);

                    for(int m = 0; m < sorted.Count; m++)
                    {
                        Console.Write(sorted[m] + " ");
                    }

                    
                    break;
                default:
                    Console.WriteLine("Not available");
                    System.Environment.Exit(0);
                    break;
            }

            watch.Stop();

            Console.WriteLine();
            Console.WriteLine();
            
            

            Console.WriteLine();
            Console.WriteLine($"Execution Time: {watch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Ready! Hit enter to exit");
            Console.ReadLine();
        }

        static public void BubbleSort(int[] Bubbel)
        {
            if (Bubbel.Length < 2) return;
            int temp;
            for (int i = 0; i < Bubbel.Length; i++)
            {
                for (int j = 0; j < Bubbel.Length - 1 - i; j++)
                {
                    if (Bubbel[j] > Bubbel[j + 1])
                    {
                        temp = Bubbel[j + 1];

                        Bubbel[j + 1] = Bubbel[j];

                        Bubbel[j] = temp;
                    }
                }
            }
        }

        static void InsertionSort(int[] Insertion)
        {
            int i, j;

            int length = Insertion.Length;

            if (length < 2) return;

            int temp;

            for (j = 1; j < length; j++)
            {
                temp = Insertion[j];

                i = j - 1;

                while(i >= 0 && Insertion[i] > temp)
                {
                    Insertion[i + 1] = Insertion[i];
                    i--;
                }

                Insertion[i + 1] = temp;
            }
        }

        static List<int> MergeSort(List<int> unsorted)
        {
            if(unsorted.Count <= 1)
            {
                return unsorted;
            }
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for(int i = 0; i < middle; i++)
            {
                left.Add(unsorted[i]);
            }
            for(int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count > 0)
            {
                if(left.Count > 0 && right.Count > 0)
                {
                    if(left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if(left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }
}   }   
