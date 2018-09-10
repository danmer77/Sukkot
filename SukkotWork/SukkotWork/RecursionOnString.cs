namespace SukkotWork
{
    public class RecursionOnString
    {
        /// <summary>
        /// returns the number of lowercase a b c letters in the inputted string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Ex21(string str)
        {
            return Ex21(str, 0);
        }

        /// <summary>
        /// The actual function, just so we start at index 0
        /// </summary>
        /// <param name="str"></param>
        /// <param name="noABC"></param>
        /// <returns></returns>
        private int Ex21(string str, int noABC)
        {
            //incrementing the number of abc letters we found
            if (str[0] == 'a' || str[0] == 'b' || str[0] == 'c')
            {
                noABC++;
            }
            //repeating it until we got to the end
            return (str.Length != 1) ? Ex21(str.Substring(1), noABC) : /*base case */noABC;
        }

        /// <summary>
        /// returns the string, but with a '*' after every 3 chars
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Ex22(string str)
        {
            return Ex22(str, 3);
        }

        /// <summary>
        /// the actual function
        /// </summary>
        /// <param name="str"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        private string Ex22(string str, int i)
        {
            return (i >= str.Length) ? /* base case */ str : /* the recursive call with insert */ Ex22(str.Insert(i, "*"), i + 4);
        }

        /// <summary>
        /// returns the string backwards
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Ex23(string str)
        {
            return Ex23(str, str.Length-1);
        }

        /// <summary>
        /// returns the string backwards. the encapsulated function
        /// </summary>
        /// <param name="str"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private string Ex23(string str, int index)
        {
            return (index != -1) ?/* start from end to beginning */ str[index] + Ex23(str, index - 1) :/* base case */ "";
        }
    }
}