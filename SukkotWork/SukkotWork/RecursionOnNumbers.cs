using System;

namespace SukkotWork
{
    public class RecursionOnNumbers
    {
        /// <summary>
        /// Returns sum up to and including the number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Ex1(int n)
        {
            return (n == 1) ? 1 : n + Ex1(n - 1); //end at base case 1, and sum up to the number from there
        }

        /// <summary>
        /// Returns the factorial of the number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Ex2(int n)
        {
            return (n == 0) ? 1 : n * Ex2(n - 1); //end at base case 0, and multiply from there
        }

        /// <summary>
        /// Returns the mult of all the odd numbers up to n (including n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Ex3(int n)
        {
            if (n % 2 == 0) //Fixes the number if it is even, so it becomes odd
            {
                return Ex3(n - 1);
            }
            else //When the number is odd
            {
                return (n == 1) ? 1 : n * Ex3(n - 2); //end at base case 1, and multiply all the odd numbers up to and including itself
            }
        }

        /// <summary>
        /// Returns the number of digits of the number
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Ex4(int n)
        {
            return (n < 10) ? 1 : 1 + Ex4(n / 10); //as we did in class, end at base case smaller than 10
        }

        /// <summary>
        /// Returns the integer div of p and q, returns p/q
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public int Ex5(int p, int q)
        {
            //dividing is just repeated subtracting, so it stops when you can't subtract anymore (for natural numbers).
            //each subtraction is by definition adding a 1 to the division
            return (p < q) ? 0 : 1 + Ex5(p - q, q);
        }

        /// <summary>
        /// Returns p%q
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public int Ex6(int p, int q)
        {
            //instead of returning the times we subtracted, we just return the remainder after we can't subtract anymore
            return (p < q) ? p : Ex6(p - q, q);
        }

        /// <summary>
        /// returns true if x is a multiple of y, false otherwise
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Ex7(int x, int y)
        {
            //checking if y is a multiple of x means that if you repeatedly add y to itself, it should become x
            //if repeatedly adding y to itself skips over x, x isn't a multiple of y, so return false
            if (y < x)
            {
                return Ex7(x, y + y);
            }
            if (y==x) //x is a multiple of y
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns true if prime, false if not
        /// </summary>
        /// <param name="maybePrime"></param>
        /// <returns></returns>
        public bool Ex8(int maybePrime)
        {
            return Ex8(maybePrime, 2); //i don't want the user to start from some number other than 2, so this is a dummy method
                                       //the real method is the one below this one, also called Ex8, which has two parametres
        }
        
        /// <summary>
        /// Returns true if prime, false if not. the encapsulated function
        /// </summary>
        /// <param name="maybePrime">the number we check</param>
        /// <param name="numStart"></param>
        /// <returns></returns>
        private bool Ex8(int maybePrime, int numStart)
        {
            while (Math.Sqrt(maybePrime) >= numStart) //It uses Ex7 to check if the number we are checking is a multiple of some number
            {
                if (Ex7(maybePrime, numStart)) //means it's not prime
                    return false; 
                numStart++; //increments to check for the next number
            }

            return true; //means it hasn't found a number that it is a multiple of 
        }


        /// <summary>
        /// Checks if all the digits are either all even or all odd. if they are either of those options, returns true. else, returns false
        /// </summary>
        /// <param name="n">the number to be checked</param>
        /// <returns></returns>
        public bool Ex9(int n)
        {
            if (n < 10) //checks if the number isn't long enough to have more than 1 digit
            {
                return true;
            }
            return Ex9(n / 10, n % 2);
            //if n%2=0, then the last digit is even. i give the number to the recursive function without the last digit
        }

        /// <summary>
        /// the encapsulated function of Ex9
        /// </summary>
        /// <param name="n"></param>
        /// <param name="b">0 for even, 1 for odd</param>
        /// <returns></returns>
        private bool Ex9(int n, int b)
        {
            if (n < 10) //if we got to the last digit, check if it is odd or even (according to b). 
            {
                return n % 2 == b; //returns if the number stands by the condition (it's odd or even according to all the last ones)
            }
            //if the last digit so far isn't up to the condition, return false. else, check the next to last one
            return ((n % 10) % 2 == b) ? Ex9(n / 10, b) : false;
        }
        
        //recursion on numbers/chars

        /// <summary>
        /// prints the characters between the two given characters
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        public void Ex24(char c1, char c2)
        {
            //these are two base cases
            if (c1 < c2 - 1) //when the first character is before the second. -1 so that c2 isn't printed out at the end
            {
                Console.Write((char)(c1+1)); //writing the next character
                Ex24((char)(c1 + 1), c2); //a recursive call
            }
            else if (c1 - 1 > c2) //when the second character is before the first. "" "" "" 
            {
                Console.Write((char)(c2 + 1)); //writing the next character
                Ex24(c1, (char)((c2 + 1))); //a recursive call
            }
        }

        /// <summary>
        /// prints the dividers of the number (including 1 and itself)
        /// </summary>
        /// <param name="n"></param>
        public void Ex25(int n)
        {
           Ex25(n, n); 
        }

        /// <summary>
        /// the encapsulated Ex25 function, which prints the dividers of the given number
        /// </summary>
        /// <param name="n">the given number</param>
        /// <param name="possibleDivider">the possible divider of the number, which should be less than or equal to the number</param>
        private void Ex25(int n, int possibleDivider)
        {
            if (possibleDivider == 1) //base case
            {
                Console.Write(1);
            }
            else
            {
                if (n % possibleDivider == 0) //if it is divisible
                {
                    Console.Write(possibleDivider + " "); //print the number
                    Ex25(n, possibleDivider - 1); //check next one
                }
                else //if it isn't divisible by the number
                {
                    Ex25(n, possibleDivider - 1); //check if the next one is, without printing the current one
                }
            }
        }

        /// <summary>
        /// prints all the even digits of the number
        /// </summary>
        /// <param name="n"></param>
        public void Ex26(int n)
        {
            if (n < 10) //base case, last digit
            {
                if(n%2==0) //print it if it is even
                    Console.Write(n);
            }
            else //else, complex case
            {
                if ((n % 10) % 2 == 0) //check if the last digit is even, if so print it
                {
                    Console.Write(n%10 + " ");
                    Ex26(n/10);
                }
                else //else, check the next digit
                {
                    Ex26(n/10);
                }
            }
        }

        /// <summary>
        /// Encapsulataing the inputted beginning of the multiplication table
        /// </summary>
        public void Ex27()
        {
            Ex27(1,1);
        }
        
        /// <summary>
        /// prints the multiplication table
        /// </summary>
        /// <param name="i1">the indices we are on, both should start at 1</param>
        /// <param name="i2"></param>
        private void Ex27(int i1, int i2)
        {
            //base case, 10*10
            if (i1 == 10 && i2 == 10)
            {
                Console.Write(100);
            }
            //i2 is the index for the column, i1 is the index for the column. each time i2 isn't 10, print and print the next one
            else if (i2 < 10)
            {
                Console.Write(i1 * i2 + " ");
                Ex27(i1, i2 + 1);
            }
            else //when i2 is 10, print the last number, and then go down by a row
            {
                Console.WriteLine(i1 * i2);
                Ex27(i1 + 1, 1);
            }
        }
    }
}