using System;
using System.Linq;

namespace AvodatKaitz
{
    class Program
    {
        static void Main(string[] args)
        {
//            //Testing the class, page 27 דף עבודה 2
//            Rectangle r = new Rectangle(new Point(1,1), 2, 1);
//            Console.WriteLine(r);
//            Console.WriteLine(r.Move(1,1));
//            Console.WriteLine(r.GetArea());
//            Console.WriteLine(r.GetPerimeter());

//            //Testing the classes, page 29 דף עבודה 3
//            Traveler[] ts = new Traveler[3]
//            {
//                new Traveler(new Passport("yair kob", 1, new Date(1,2,2008)), true),
//                new Traveler(new Passport("kek", 2, new Date(31,12,2007)), false),
//                new Traveler(new Passport("baba", 3, new Date(12,3,2006)), true)
//            };
//            Console.WriteLine(PrintAll(ts));
//            Console.WriteLine(IsValidFor1StJan2008(ts));

            //Phonebook

            PhoneBook pb = new PhoneBook();

            pb.AddContact(new Person("Galit Israel", "03-9089730"));
            pb.AddContact(new Person("Avner Cohen", "02-7474747"));
            pb.AddContact(new Person("Gershon Avraham", "02-8900011"));
            pb.AddContact(new Person("Daniela Yariv", "04-5677708"));
            pb.AddContact(new Person("Alice Marlo", "04-5699300"));
            pb.AddContact(new Person("Bob Denver", "04-5699300"));
            pb.AddContact(new Person("Galit Israel", "02-6412222"));

            string theAskString = "**********************************************************************\n" +
                                  "\n" +
                                  "Do you wish to add or update a person? Please enter 0.\n" +
                                  "Do you wish to delete a person? Please enter 1.\n" +
                                  "Do you wish to get a contact's phone number? Please enter 2.\n" +
                                  "Do you wish to print the whole phone book? Please enter 3.\n" +
                                  "Do you wish to get the number of contacts? Please enter 4.\n\n" +
                                  "*********************************************************************";
            while (true)
            {
                Console.WriteLine(theAskString);
                string input = Console.ReadLine();
                switch (input) //switch for the selection
                {
                    case "0": //add or update
                        Console.WriteLine("Please enter the person's name.");
                        string name0 = Console.ReadLine();
                        Console.WriteLine("Please enter the person's phone number.");
                        string phoneNumber = Console.ReadLine();
                        pb.AddContact(new Person(name0, phoneNumber));
                        break;
                    case "1": //deleting a person
                        Console.WriteLine("Please enter the person's name.");
                        string name1 = Console.ReadLine();
                        pb.DelContact(name1);
                        break;
                    case "2":
                        Console.WriteLine("Please enter the contact's name.");
                        string name2 = Console.ReadLine();
                        pb.GetPhone(name2);
                        break;
                    case "4":
                        Console.WriteLine(pb.GetNoContacts());
                        break;
                    default:
                        break;
                }

                Console.Clear();
                Console.WriteLine(pb);
            }
        }


        public static string IsValidFor1StJan2008(Traveler[] travelers)
        {
            string theValids = ""; //The string we return, with the valid travelers
            Date firstJan2008 = new Date(1,1,2008);
            foreach (Traveler t in travelers)
            {
                if (t.CheckTravel(firstJan2008))
                    theValids += t.ToString();
            }
            
            return theValids;
        }

        public static string PrintAll<T>(T[] arr)
        {
            string theString = "";
            foreach (var VARIABLE in arr)
            {
                theString += VARIABLE.ToString();
            }

            return theString;
        } 
    }
}