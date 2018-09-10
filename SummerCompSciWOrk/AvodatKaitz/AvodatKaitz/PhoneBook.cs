using System.Collections.Generic;
using System.Linq;

namespace AvodatKaitz
{
    public class PhoneBook
    {
        private Person[] phoneBook; //Array of the people in the phonebook
        private int position; //The position we are in the array
        

        public PhoneBook()
        {
            this.phoneBook = new Person[1];
            this.position = 0;
        }

        /// <summary>
        /// deleting a contact by the given name
        /// </summary>
        /// <param name="name"></param>
        public void DelContact(string name)
        {
            //finding the contact to delete
            int theIndexOfTheContactToDelete = -1; //if unchanged, it means the person wasn't found
            for (int i = 0; i < this.position; i++)
            {
                if (this.phoneBook[i].name == name)
                {
                    theIndexOfTheContactToDelete = i;
                    break;
                }
            }

            if (theIndexOfTheContactToDelete != -1)
            {
                //deleting the contact
                this.phoneBook[theIndexOfTheContactToDelete] = null;
                //decrementing the position we are in
                this.position--;
                //moving the rest of the contacts left
                for (int i = theIndexOfTheContactToDelete; i < this.position; i++)
                {
                    this.phoneBook[i] = this.phoneBook[i + 1];
                }
            }
        }

        /// <summary>
        /// getting the phone number of the person searched for in the phone book
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetPhone(string name)
        {
            //returning the phone number of the person searched for
            for (int i = 0; i < this.position; i++)
            {
                if (this.phoneBook[i].name == name)
                    return phoneBook[i].phoneNum;
            }

            return ""; //if the person with the name wasn't found, return null
        }

        /// <summary>
        /// returns all the contact names
        /// </summary>
        /// <returns></returns>
        public string[] GetAllContactsNames()
        {
            //straightforward
            string[] theNames = new string[this.position];
            for (int i = 0; i < this.position; i++)
            {
                theNames[i] = this.phoneBook[i].name;
            }

            return theNames;
        }

        /// <summary>
        /// Adding the contact into the phonebook, lexicographically ordered. also updates contact phone number
        /// </summary>
        /// <param name="p"></param>
        public void AddContact(Person p)
        {
            if (GetPhone(p.name) == "") //means there is no person with that name in the phonebook
            {
                if (this.position == this.phoneBook.Length) //if the phonebook is full, make a new phonebook double it's previous size
                {
                    Person[] temp = this.phoneBook; //temporary phonebook
                    Person[] newPhonebook = new Person[temp.Length * 2]; //the new phonebook, twice the size
                    
                    for (int i = 0; i < temp.Length; i++) //entering the people already in the phonebook into the new phone book
                    {
                        newPhonebook[i] = temp[i];
                    }

                    //insert the new person, into lexicographical order
                    bool personInserted = false; //true if the person was inserted lexicographically, false if not
                    for (int i = 0; i < temp.Length && !personInserted; i++)
                    {
                        if (p.name.CompareTo(phoneBook[i].name) < 0) //means name appears before (lexicographically) than the first
                        {
                            //moving the rest
                            for (int j = temp.Length; j > i; j--)
                            {
                                newPhonebook[j] = newPhonebook[j - 1];
                            }
                            //switching the two
                            newPhonebook[i] = p;
                            personInserted = true;
                        }
                    }

                    if (!personInserted) //if the person wasn't inserted lexicographically, it means he was after everyone, so add him at the end
                    {
                        newPhonebook[temp.Length] = p;
                    }
                    this.phoneBook = newPhonebook; //finally switching the phonebooks
                }
                else if (this.position == 0) //the beginning, adding the person
                {
                    this.phoneBook[0] = p;
                }
                else //else, add the new person in it's lexicographically ordered place, without changing the length of the phonebook
                {
                    bool personInserted = false; //changes if the person was inserted
                    for (int i = 0; i < this.position && !personInserted; i++)
                    {
                        if (p.name.CompareTo(this.phoneBook[i].name) < 0) //means name appears before (lexicographically) than the first
                        {
                            //moving the rest
                            for (int j = this.position; j > i; j--)
                            {
                                this.phoneBook[j] = this.phoneBook[j - 1];
                            }
                            //adding the person in it's lexicographically ordered place
                            this.phoneBook[i] = p;
                            personInserted = true;
                        } 
                    }

                    if (!personInserted) //if the person wasn't inserted, it means he's after everyone, so add him at the end
                    {
                        this.phoneBook[this.position] = p;
                    }
                }
                this.position++; //increment the position, for we added a new person
            }
            
            else //the person exists
            {
                for (int i = 0; i < this.position; i++) //finding the person and switching the phone numbers
                {
                    if (this.phoneBook[i].name == p.name)
                    {
                        this.phoneBook[i] = p;
                    }
                }
            }
        }

        /// <summary>
        /// returns the number of contacts
        /// </summary>
        /// <returns></returns>
        public int GetNoContacts()
        {
            return position;
        }
        
        /// <summary>
        /// returns all contacts, the name and phone number
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string theStrings = "";
//            foreach (Person p in this.phoneBook)
//            {
//                theStrings += p.name + "  " + p.phoneNum;
//            }
            for (int i = 0; i < this.position; i++)
            {
                theStrings += this.phoneBook[i].name + " " + this.phoneBook[i].phoneNum + "\n";
            }
            
            return theStrings;
        }
        
        
//        /// <summary>
//        /// Adds the person to the phonebook
//        /// </summary>
//        /// <param name="p"></param>
//        public void AddContact(Person p)
//        {
//            if (this.phoneBook.Exists(x=> x.name == p.name))
//            {
//                this.phoneBook.Remove(this.phoneBook.First(x => x.name == p.name));   
//            }
//            
//            this.phoneBook.Add(p);
//        }
//
//        /// <summary>
//        /// Removes the people with that name
//        /// </summary>
//        /// <param name="name"></param>
//        public void DelContact(string name)
//        {
//            this.phoneBook.RemoveAll(x => x.name == name);
//        }
//
//    /// <summary>
//    /// Returns the phone number of the name
//    /// </summary>
//    /// <param name="name"></param>
//    /// <returns></returns>
//        public string GetPhone(string name)
//        {
//            return this.phoneBook.First(x => x.name == name).phoneNum;
//        }
//
//        /// <summary>
//        /// Returns all the names of the people in the phonebook
//        /// </summary>
//        /// <returns></returns>
//        public string[] GetAllContactsNames()
//        {
//            string[] theNames = new string[this.phoneBook.Count];
//            for (int i = 0; i < theNames.Length; i++)
//            {
//                theNames[i] = this.phoneBook[0].name;
//            }
//
//            return theNames;
//        }
//        
//
//        public List<string> SortArray(List<Person> l)
//        {
//            string[] theStrings = new string[l.Count];
//            for (int i = 0; i < theStrings.Length; i++)
//            {
//                theStrings[i] = l[i].PhoneBookToString();
//            }
//
//            List<string> sorted = theStrings.ToList();
//            sorted.Sort();
//            return sorted;
//        }
    }
}