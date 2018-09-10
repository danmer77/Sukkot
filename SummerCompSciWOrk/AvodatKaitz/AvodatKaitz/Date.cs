namespace AvodatKaitz
{
    public class Date
    {
        public int day { get; set; } //Date day
        public int month { get; set; } //Month
        public int year { get; set; } //Year

        public Date(int day, int month, int year) //Regular constructor
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public Date(Date d) //Copy constructor
        {
            this.day = d.day;
            this.month = d.month;
            this.year = d.year;
        }

        /// <summary>
        /// Returns the Date which is older. If equal dates, returns null
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public Date Older(Date d)
        {
            if (this.year == d.year)
            {
                if (this.month == d.month)
                {
                    if (this.day == d.day)
                    {
                        return null;
                    }
                    else if (this.day > d.day)
                    {
                        return d;
                    }
                    else
                    {
                        return this;
                    }
                    
                }
                else if (this.month > d.month)
                {
                    return d;
                }
                else
                {
                    return this;
                }
            }
            else if (this.year > d.year)
            {
                return d;
            }
            else
            {
                return this;
            }
        }

        public override string ToString()
        {
            return $"{this.day}/{this.month}/{this.year}";
        }
    }
}