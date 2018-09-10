namespace AvodatKaitz
{
    public class Traveler
    {
        private Passport _passport; //The traveler's passport
        private bool _hasPaid; //if the traveler has paid for his flight

        public Traveler(Passport passport, bool hasPaid)
        {
            this._passport = passport;
            this._hasPaid = hasPaid;
        }

        /// <summary>
        /// Pay the sum needed to be paid
        /// </summary>
        public void Pay()
        {
            this._hasPaid = true;
        }

        public bool HasPaid => _hasPaid;

        public bool CheckTravel(Date travelDate)
        {
            return this._passport.IsValid(travelDate) && HasPaid;
        }

        public override string ToString()
        {
            return this._passport.ToString() + $"Has paid: {this._hasPaid}.\n";
        }
    }
}