using System;
using UnityEngine;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public int LCT01_SequentialSearch1DArray()
        {
            int[] array = new int[] { 34, 21, 56, 12, 78, 90, 11, 23 };
            int target = 90;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }
            if(index == -1)
            {
                Console.WriteLine("Find not Found!");
            }

            return index;
        }

        public int[] LCT02_SequentialSearch2DArray()
        {
            int[,] array = new int[,]
            {
                { 34, 21, 56 },
                { 12, 78, 90 },
                { 11, 23, 45 }
            };
            int target = 23;
            int row = -1;
            int col = -1;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == target)
                    {
                        row = i;
                        col = j;
                        break;
                    }
                }
                if (row != -1 && col != -1)
                {
                    break;
                }
            }

            return new[] { row, col };
        }

        public int LCT03_BinarySearch()
        {
            int[] array = new int[] { 11, 12, 21, 23, 34, 45, 56, 78, 90 };
            int target = 23;
            int index = -1;

            int left = 0;
            int right = array.Length - 1;

            // Your code here ...
            while (left <= right)
            {
                // 2,147,483,647
                int mid = left + (right - left) / 2;

                if (array[mid] == target)
                {
                    index = mid;
                    break;
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else if (array[mid] > target)
                {
                    right = mid - 1;
                }
            }

            return index;

        }

        #endregion

        #region Assignment

        public int[] AS01_FindFirstAndLastElementOfArray(int[] array, int target)
        {
            int first = -1;
            int last = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    if (first == -1)
                    {
                        first = i;
                    }

                    last = i;
                }
            }

            if (first == -1)
            {
                return new int[] { -1 };
            }

            return new int[] { first, last };
        }

        public int AS02_FindMaxLessThan(int[] array, int target)
        {
            int max = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < target && array[i] > max)
                {
                    max = array[i];
                }
            }

            if (max == int.MinValue)
            {
                return -1;
            }

            return max;
        }

        public int[] AS03_FindRange(int[] array, int min, int max)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= min && array[i] <= max)
                {
                    result[index] = array[i];
                    index++;
                }
            }

            return result;
        }

        #endregion

        #region Extra

        public int[] EX01_FindTargetEnemies(int[] enemyHPs, int mana)
        {
            int[] sortedHPs = (int[])enemyHPs.Clone();

            for (int i = 0; i < sortedHPs.Length - 1; i++)
            {
                for (int j = 0; j < sortedHPs.Length - 1 - i; j++)
                {
                    if (sortedHPs[j] > sortedHPs[j + 1])
                    {
                        int temp = sortedHPs[j];
                        sortedHPs[j] = sortedHPs[j + 1];
                        sortedHPs[j + 1] = temp;
                    }
                }
            }

            int count = 0;
            int totalMana = 0;

            for (int i = 0; i < sortedHPs.Length; i++)
            {
                if (totalMana + sortedHPs[i] <= mana)
                {
                    totalMana += sortedHPs[i];
                    count++;
                }
            }

            int[] result = new int[count];
            int index = 0;
            totalMana = 0;

            for (int i = 0; i < sortedHPs.Length; i++)
            {
                if (totalMana + sortedHPs[i] <= mana)
                {
                    result[index] = sortedHPs[i];
                    totalMana += sortedHPs[i];
                    index++;
                }
            }

            return result;
        }

        #endregion
    }
}
