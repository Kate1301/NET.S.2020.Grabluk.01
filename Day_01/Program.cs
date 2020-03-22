using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_01
{
        class Program
        {
            //The function of quick sort
            static void Quick(int[] array, int left, int right)
            {
                int resolving;
                int number_left = left;
                int numbrer_right = right;
                resolving = array[left];
                while (left < right)
                {
                    while ((array[right] >= resolving) && (left < right))
                        right--;
                    if (left != right)
                    {
                        array[left] = array[right];
                        left++;
                    }
                    while ((array[left] <= resolving) && (left < right))
                    {
                        left++;
                    }
                    if (left != right)
                    {
                        array[right] = array[left];
                        right--;
                    }
                }
                array[left] = resolving;
                resolving = left;
                left = number_left;
                right = numbrer_right;
                if (left < resolving)
                {
                    Quick(array, left, resolving - 1);
                }
                if (right > resolving)
                {
                    Quick(array, resolving + 1, right);
                }
            }
            //method for merging arrays
            static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
            {
                var left = lowIndex;
                var right = middleIndex + 1;
                var tempArray = new int[highIndex - lowIndex + 1];
                var index = 0;

                while ((left <= middleIndex) && (right <= highIndex))
                {
                    if (array[left] < array[right])
                    {
                        tempArray[index] = array[left];
                        left++;
                    }
                    else
                    {
                        tempArray[index] = array[right];
                        right++;
                    }

                    index++;
                }

                for (var i = left; i <= middleIndex; i++)
                {
                    tempArray[index] = array[i];
                    index++;
                }

                for (var i = right; i <= highIndex; i++)
                {
                    tempArray[index] = array[i];
                    index++;
                }

                for (var i = 0; i < tempArray.Length; i++)
                {
                    array[lowIndex + i] = tempArray[i];
                }
            }
            //Merge sorting
            static int[] MergeSort(int[] array, int lowIndex, int highIndex)
            {
                if (lowIndex < highIndex)
                {
                    var middleIndex = (lowIndex + highIndex) / 2;
                    MergeSort(array, lowIndex, middleIndex);
                    MergeSort(array, middleIndex + 1, highIndex);
                    Merge(array, lowIndex, middleIndex, highIndex);
                }

                return array;
            }
            static int[] MergeSort(int[] array)
            {
                return MergeSort(array, 0, array.Length - 1);
            }
            static void Main(string[] args)
            {
                int[] array = new int[] { 12, 3, 43, 11, 429, 0, -1, 11 };
                for (int i = 0; i < array.Length; i++)
                    Console.Write(array[i] + " ");//Output array elements before sorting
                Quick(array, 0, array.Length - 1);//calling the quick sort function
                Console.WriteLine();
                for (int i = 0; i < array.Length; i++)
                    Console.Write(array[i] + " ");//The output of the array elements after quick sort
                Console.WriteLine();
                int[] array1 = new int[] { 12, 3, 43, 311, 429, 0, -1, 11, 102, 01 };
                for (int i = 0; i < array1.Length; i++)
                    Console.Write(array1[i] + " ");
                Console.WriteLine();
                MergeSort(array1);//calling the merge sorting function
                for (int i = 0; i < array1.Length; i++)
                    Console.Write(array1[i] + " ");//The output of the array elements after merge sorting
                Console.ReadKey();
            }
        }
    }
