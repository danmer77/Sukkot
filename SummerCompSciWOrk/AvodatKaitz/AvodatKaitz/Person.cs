namespace AvodatKaitz
{
    public class Person
    {
        public string name { get; set; }
        public string phoneNum { get; set; }

        public Person(string name, string phoneNum)
        {
            this.name = name;
            this.phoneNum = phoneNum;
        }

        public string PhoneBookToString()
        {
            return $"{this.name} {this.phoneNum}\n";
        }

//        public bool (Person p)
//        {
//            return this.name == p
//        }
    }
}