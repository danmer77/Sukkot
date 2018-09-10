using System;

namespace SukkotWork
{
    public class RecursionOnMathematicalExpressions
    {
        /// <summary>
        /// Returns the sum according to the question, recursively of course
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Ex10(int n)
        {
            if (n == 1) //the base case
            {
                return 1 * 2;
            }
            //returning the two different expressions if the number is odd or even
            return (n % 2 == 0) ? ((int)Math.Pow(n, 2) + Ex10(n - 1)) : (n * 2 + Ex10(n - 1)); 
        }

        /// <summary>
        /// Returns the sum according to the given parametres, where Ex11(n=1)=1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public double Ex11(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            //Where n is odd, the number is not square rooted, and is positive. n is even, it is square rooted and negative
            return (n % 2 == 1) ? (2*n-1) + Ex11(n - 1) : Ex11(n - 1) - Math.Sqrt(2*n-1);
        }

        /// <summary>
        /// Returns the sum of the multiples of n1 that are smaller than n2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public int Ex12(int n1, int n2)
        {
            return Ex12(n1, n2, 1, 0); //0 to start the sum, 1 to start the n1 * 1 (no need to start with i=0)
        }

        /// <summary>
        /// Returns the sum of the multiples of n1 that are smaller than n2, the encapsulated function
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="i">the multiple we are on, n1 * i</param>
        /// <param name="sum">the sum up until now</param>
        /// <returns></returns>
        private int Ex12(int n1, int n2, int i, int sum)
        {
            //If the multiple of n1 isn't smaller than n, just return the sum, cause we got to the base case
            if (i * n1 >= n2)
            {
                return sum;
            }
            //same two numbers n1 and n2, increment the i for the next multiple to add to the sum
            //add the multiple to the sum
            return Ex12(n1, n2, i + 1, sum + i*n1);
        }

        /// <summary>
        /// Returns a(n), where a(n)=a(n-1)^2 + a(n-2)^2 and a(1)=0 and a(2)=1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Ex13A(int n)
        {
            if (n == 1)
            {
                return 0;
            }
            else if (n == 2)
            {
                return 1;
            }

            return (int)(Math.Pow(Ex13A(n - 1), 2) + Math.Pow(Ex13A(n - 2), 2));
        }
        /// <summary>
        /// Returns the sum of all Ex13A up to and including Ex13A(n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Ex13B(int n)
        {
            return Ex13B(n, 0);
        }

        /// <summary>
        /// the encapsulated function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private int Ex13B(int n, int sum)
        {
            if (n == 1) //Ex13A(1) = 0, so return the sum
            {
                return sum;
            }
            //return the sum of the elements of Ex13A from n ≥ 1 until n = 1
            return Ex13B(n - 1, sum + Ex13A(n));
        }

        /// <summary>
        /// prints the algebraic series with parametres a, d, and how many of them should be printed, n
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="d"></param>
        /// <param name="n"></param>
        public void Ex28(int a1, int d, int n)
        {
            if (n == 1) //base case, print the first element
            {
                Console.Write(a1 + " ");
            }
            else
            {
                Ex28(a1, d, n-1); //the recursive call, we want the first ones in the series first (up to a)
                Console.Write(a1 + d * (n-1) + " "); //last one last, according to the formula for an algebraic series's element
            }
        }

        /// <summary>
        /// prints the first n elements of the series given in the question
        /// </summary>
        /// <param name="n"></param>
        public void Ex29(int n)
        {
            Ex29(1, 0, 1, n);
        }

        /// <summary>
        /// prints the first n elements of the series given in the question, the encapsulated function
        /// </summary>
        /// <param name="a1">the number we are on</param>
        /// <param name="d">the diff between a and the next element</param>
        /// <param name="i">the times we jumped to the next element</param>
        /// <param name="n"></param>
        private void Ex29(int a1, int d, int i, int n)
        {
            if (i == n) //the base case, at the end
            {
                Console.Write(a1 + d);
            }
            else
            {   //print the next element
                Console.Write(a1 + d + ", ");
                Ex29(a1 + d, d+1, i+1, n); //go to the one after that
            }
        }

        /// <summary>
        /// prints the first n elements in the sequence in the question
        /// </summary>
        /// <param name="n"></param>
        public void Ex30(int n)
        {
            Console.Write(4 + " "); //starting with the 4
            Ex30(4, 0, n); //invoking the real function
        }

        /// <summary>
        /// prints the first n elements in the sequence in the question, the encapsulated function
        /// </summary>
        /// <param name="a">the number we are on</param>
        /// <param name="i">the leaps so far</param>
        /// <param name="n">the number of numbers we want to see from the series</param>
        private void Ex30(int a, int i, int n)
        {
            if (i == n - 1) //because we start at i=0, base case
            {}
            else
            {
                if (i % 2 == 0) //if the leap is even
                {
                    Console.Write(a - 1 + " "); //print the next one, which is a-1
                    Ex30(a-1, i+1, n); //go to the next one
                }
                else //else the leap is odd
                {
                    Console.Write(a + 2 + " "); //print the next one, whichi is a+2 
                    Ex30(a+2, i+1, n); //go to the next one in the series
                }
            }
        }
    }
}