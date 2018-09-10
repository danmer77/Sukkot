
using System;

namespace SukkotWork
{
    public class RecursionOnArrays
    {
        /// <summary>
        /// Returns the sum of the elements in the array from index to 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="index">is ≤ a.Length-1</param>
        /// <returns></returns>
        public double Ex14(double[] a, int index)
        {
            //Pretty straightforward
            if (index == 0)
            {
                return a[index];
            }
            
            return a[index] + Ex14(a, index - 1);
        }

        /// <summary>
        /// returns the sum of all the positive numbers from index to 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="index">is ≤ a.Length-1</param>
        /// <returns></returns>
        public double Ex15(double[] a, int index)
        {
            if (index == 0) //check the base case, at index 0
            {
                if (a[index] > 0)
                    return a[index];
                return 0;
            }
            //as long as the element at the index is positive, sum it. else don't sum it and go to the next element
            return (a[index] > 0) ? a[index] + Ex15(a, index - 1) : Ex15(a, index - 1);
        }

        /// <summary>
        /// Returns the index of the input in the array, or -1 if not in the array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public int Ex16(int[] a, int num)
        {
            return Ex16(a, num, 0);
        }

        /// <summary>
        /// Returns the index of the input in the array, or -1 if not in the array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="num"></param>
        /// <param name="currPosition">didn't want a user outside the class to play around with the starterposition</param>
        /// <returns></returns>
        private int Ex16(int[] a, int num, int currPosition)
        {
            //base case, end of the array
            if (currPosition == a.Length - 1)
            {
                return (a[currPosition] == num) ? currPosition : -1; //not found until the end, return -1. else return currPosition
            }

            //return the currPosition if the number is in the element at index currPosition, else check the next element
            return (a[currPosition] == num) ? currPosition : Ex16(a, num, currPosition + 1);
        }

        /// <summary>
        /// Returns true if the array is sorted in ascending order, else false
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Ex17(int[] a)
        {
            return Ex17(a, 0);
        }

        /// <summary>
        /// Returns true if the array is sorted in ascending order, else false. Don't want outsider to class to affect where the checking
        /// starts
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i">the starting index, which should always be 0</param>
        /// <returns></returns>
        private bool Ex17(int[] a, int i)
        {
            if (i == a.Length - 2) //if we got to the base case, return if it is true
            {
                return a[i] < a[i+1];
            }
            //recursively check if the next two terms are in ascending order
            return (a[i] < a[i + 1]) ? Ex17(a, i + 1) : false;
        }

        /// <summary>
        /// Returns true if the array contains no prime numbers
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Ex18(int[] a)
        {
            RecursionOnNumbers r = new RecursionOnNumbers();
            return Ex18(a, 0, r);
        }

        /// <summary>
        /// Returns true if the array doesn't contain any prime numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="index">the starting index, which should always be 0</param>
        /// <param name="theExerciseObject">to check if a number is prime</param>
        /// <returns></returns>
        private bool Ex18(int[] a, int index, RecursionOnNumbers theExerciseObject)
        {
            //base case, at the end
            if (index == a.Length - 1)
            {
                return theExerciseObject.Ex8(a[index]);
            }
            //if it isn't a prime number, return if the next number  isn't prime in the array. if it is, return false
            return !theExerciseObject.Ex8(a[index]) && Ex18(a, index + 1, theExerciseObject);
        }

        /// <summary>
        /// Returns in how many of the rows of the matrix (from the input to 0) the inputted number appears
        /// </summary>
        /// <param name="num"></param>
        /// <param name="mat"></param>
        /// <param name="lastRowIndex"></param>
        /// <returns></returns>
        public int Ex19(int num, int[,] mat, int lastRowIndex)
        {
            //making the row we are in from the matrix
            int[] theRow = new int[mat.GetLength(1)];
            for (int i = 0; i < theRow.Length; i++)
            {
                theRow[i] = mat[lastRowIndex, i];
            }
            //base case, first row
            if (lastRowIndex == 0)
            { //returns 1 if the last row contains the number, else it returns 0
                return (Ex16(theRow, num) >= 0) ? 1 : 0;
            }
            //adding 1 for each row which contains the number, recursively
            return (Ex16(theRow, num) >= 0) ? 1 + Ex19(num, mat, lastRowIndex - 1) : Ex19(num, mat, lastRowIndex - 1);
        }

        /// <summary>
        /// takes an array, randomizes two indexes
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool Ex20(int[] a)
        {
            Random r = new Random();
            int i1 = r.Next(0, a.Length); //the two randomized numbers
            int i2 = r.Next(0, a.Length);
            
            return Ex20(a, Math.Min(i1, i2), Math.Max(i1,i2)); //returning the value of the helper method
        }

        /// <summary>
        /// helper to the invoked Ex20 method, which is encapsulated
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        private bool Ex20(int[] a, int i1, int i2)
        {
            //Base cases
            if (i1 == i2)
            {
                return true;
            }

            if (i1 + 1 == i2)
            {
                return a[i1] == a[i2];
            }
            //checking and then moving to the next two numbers to check
            return (a[i1] == a[i2]) ? Ex20(a, i1+1, i2-1): false;
        }

        /// <summary>
        /// printing the elements in the even indices of the array
        /// </summary>
        /// <param name="a"></param>
        public void Ex31(int[] a)
        {
            Ex31(a, 0); //start at index 0, which is even
        }

        /// <summary>
        /// printing the elements in the even indices of the array, the encapsulated function
        /// </summary>
        /// <param name="a">the array inputted</param>
        /// <param name="i">the index of the element we are printing</param>
        private void Ex31(int[] a, int i)
        {
            if (i < a.Length) //as long as i is inside the bounds of the array
            {
                Console.Write(a[i] + " "); //print the element
                Ex31(a, i+2); //increment i by 2, so the next even index is printed
            }
        }

        /// <summary>
        /// prints only the elements which are smaller than the element after them, with the last omitted, since it has no following elements
        /// </summary>
        /// <param name="a"></param>
        public void Ex32(int[] a)
        {
            Ex32(a, 0);
        }

        /// <summary>
        /// prints only the elements which are smaller than the element after them, the encapsulated function
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i">the index we are currently on</param>
        private void Ex32(int[] a, int i)
        {
            if (i < a.Length - 1) //if it is ok to check the elements
            {
                if (a[i] < a[i + 1]) //checking if the elemnt should be printed, according to the condition stated above
                {
                    Console.Write(a[i] + " ");
                }
                Ex32(a, i+1); //checking the next elements
            }
        }

        /// <summary>
        /// prints the elements of the matrix from the two i's
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i1">the row</param>
        /// <param name="i2">the column</param>
        public void Ex33(int[,] a, int i1, int i2)
        {
            Ex33(a, i1, i2, i2); //i2 is the starting column
        }

        /// <summary>
        /// prints the element of the matrix from the two i's, the encapsulated function
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i1">the row</param>
        /// <param name="i2">the column</param>
        /// <param name="start">the starting index to return to after printing a row</param>
        private void Ex33(int[,] a, int i1, int i2, int start)
        {
            if (i1 == a.GetLength(0) - 1 && i2 == a.GetLength(1) - 1) //if both are at the lower right corner of the matrix
            {
                Console.Write(a[i1,i2]); //end the recursive call, and just print the last one
            }
            else if (i2 < a.GetLength(1) - 1) //if we are at some row before the last column
            {
                Console.Write(a[i1,i2] + " "); //print the element
                Ex33(a, i1, i2 + 1, start); //go to the next column, at the same row
            }
            else //else we are at the last column on some row
            {
                Console.WriteLine(a[i1,i2]); //print the element
                Ex33(a, i1 + 1, start, start); //go to the next row, and return to the starting column
            }
        }

        /// <summary>
        /// returns, recursively, the max number in an array, from the index given
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i">starting index</param>
        /// <returns></returns>
        private static int MaxOfArray(int[] a, int i)
        {
            if (i == a.Length - 2) //base case
            {
                return Math.Max(a[i], a[i + 1]); //returns the max of the two last ones
            }

            return Math.Max(a[i], MaxOfArray(a, i + 1)); //recursive call, find the max from this and the next
        }
        
        /// <summary>
        /// returns the max of each row, from the starting row
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i">starting row</param>
        public void Ex34(int[,] a, int i)
        {
            int[] theRow = new int[a.GetLength(1)]; //the row in question
            for (int j = 0; j < theRow.Length; j++) //entering the values of the row
            {
                theRow[j] = a[i, j];
            }

            if (i == a.GetLength(0) - 1) //base case, the last row
            {
                Console.WriteLine(MaxOfArray(theRow, 0)); //printing the max of the last row
            }
            else //else, complex case
            {
                Console.WriteLine(MaxOfArray(theRow, 0)); //print the max of the current row
                Ex34(a, i+1); //go to the next row
            }
        }
    }
}