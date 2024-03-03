using System;
using System.Data;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int addScripture = 0;
        string referenceComplete;
        string verses;

        Scripture scripture = new Scripture();

        while (addScripture != 5)
        {
            Console.Write("Do you want to add a scripture to the list? Yes = 1, No = 5: ");
            string scriptureAdder = Console.ReadLine();
            addScripture = int.Parse(scriptureAdder);

            if (addScripture == 1)
            {
                Console.Write("Enter the book of scripture: ");
                string book = Console.ReadLine();

                Console.Write("\nEnter the chapter and verse number(s): ");
                string chapter = Console.ReadLine();

                Console.WriteLine("Paste the verses");
                verses = Console.ReadLine();

                Reference _reference1 = new Reference(book, chapter);
                referenceComplete = _reference1.makeReference();

                scripture.AddReference(referenceComplete);
                scripture.AddVerses(verses);
            }

        scripture.AddReference(
            "1 Nephi 1:1");
        scripture.AddVerses(@"I, Nephi, having been born of goodly parents, therefore I was taught somewhat in 
all the learning of my father; and having seen many afflictions in the course of my days, 
nevertheless, having been highly favored of the Lord in all my days; yea, having had a great 
knowledge of the goodness and the mysteries of God, therefore I make a record of my proceedings 
in my days.");
        
        scripture.AddReference("Alma 31:38");
        scripture.AddVerses(@"38 And the Lord provided for them that they should hunger not, neither should 
they thirst; yea, and he also gave them strength, that they should suffer no manner of afflictions, 
save it were swallowed up in the joy of Christ. Now this was according to the prayer of Alma; and this 
because he prayed in faith.");

        }

        while (!scripture.AllWordsHidden)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            Console.Clear();
            scripture.HideRandomWord();
            scripture.Display();

        }
    
    }
}