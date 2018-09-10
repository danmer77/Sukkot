namespace AvodatKaitz
{
    public class Passport
    {
        public string name { get; set; } //Passport holder name
        public int number { get; set; } //Passport number
        private Date expiryDate { get; set; } //The expiry date of the passport

        public Passport(string name, int number, Date expiryDate) //Regular constructor
        {
            this.name = name;
            this.number = number;
            this.expiryDate = expiryDate;
        }

        public Passport(Passport p) //Copy constructor
        {
            this.name = p.name;
            this.number = p.number;
            this.expiryDate = p.expiryDate;
        }

        /// <summary>
        /// Returns the string, with newline at the end
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name: {this.name}.\nPassport number: {this.number}.\nExpiry Date: {this.expiryDate}.\n";
        }

        /// <summary>
        /// Checks if the date is valid, true if valid, false if not
        /// </summary>
        /// <param name="currDate"></param>
        /// <returns></returns>
        public bool IsValid(Date currDate)
        {
            return this.expiryDate.Older(currDate) != this.expiryDate; //If this.expiryDate is older, it's valid
        }

        /// <summary>
        /// Sets this's expirydate's reference to the inputted date
        /// </summary>
        /// <param name="d"></param>
        public void SetExpiryDate(Date d)
        {
            this.expiryDate = d;
        }
    }
}