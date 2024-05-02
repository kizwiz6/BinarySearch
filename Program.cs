using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = { 2, 4, 5, 6, 7, 10, 13, 21, 20 };

            // Prompt user to enter the target value

            int target = GetValidIntegerInput("What's your target?");

            // Perform binary search
            int index = BinarySearch(numbers, target);

            // Print search result
            PrintSearchResult(target, index);

            // Keep the console open
            Console.ReadLine();
        }

        /// <summary>
        /// Method to get valid integer input from user
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static int GetValidIntegerInput(string message)
        {
            int input;
            do
            {
                // Display prompt message
                Console.WriteLine(message);
                // Read user input and attempt to parse it into an integer
            } while (!int.TryParse(Console.ReadLine(), out input)); // Repeat until valid integer input is provided
            return input;
        }

        /// <summary>
        /// Method to print search result.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="index"></param>
        private static void PrintSearchResult(int target, int index)
        {
            if (index != -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The value of {target}  was found at index {index}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Value not found.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Checks if the method is sorted.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    return false; // Array is not sorted
                }
            }
            return true; // Array is sorted
        }

        /// <summary>
        /// Method to perform binary search.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] array, int target)
        {
            int left = 0; // left most index of search range
            int right = array.Length - 1; // whatever length of array is minus 1 - right most index of search range

            // Continues as long as the left index is less than or equal to the right index. It ensures that the search continues within the valid range of indices.
            while (left <= right)
            {
                int mid = (left + right) / 2; // takes average - rounds down to nearest integer

                // If element at middle index is equal to target, return index
                if (array[mid] == target)
                {
                    return mid;
                }
                // If element at middle index is less than target, search right half of array
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                // If element at middle index is greater than target, search left half of array
                else
                {
                    right = mid - 1;
                }
            }
            // Executed if the target value is not found in the array
            return -1;
        }
    }
}
