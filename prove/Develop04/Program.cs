using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list of scriptures
            List<Scripture> scriptures = new List<Scripture>()
            {
                new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture("Proverbs 3:5-6", "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
            };

            // Select a random scripture
            Random random = new Random();
            int index = random.Next(0, scriptures.Count);
            Scripture selectedScripture = scriptures[index];

            // Create a scripture memorization object
            ScriptureMemorization memorization = new ScriptureMemorization(selectedScripture);

            // Display the complete scripture
            memorization.DisplayScripture();

            // Main loop
            while (!memorization.AllWordsHidden)
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                Console.Clear();
                memorization.HideRandomWords();
                memorization.DisplayScripture();
            }
        }
    }

    class Scripture
    {
        public ScriptureReference Reference { get; }
        private List<Word> words;

        public Scripture(string reference, string text)
        {
            Reference = new ScriptureReference(reference);
            words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public bool AllWordsHidden => words.All(word => word.IsHidden);

        public void HideWord(int index)
        {
            if (index >= 0 && index < words.Count)
                words[index].Hide();
        }

        public void HideRandomWord()
        {
            List<Word> visibleWords = words.Where(word => !word.IsHidden).ToList();
            if (visibleWords.Count > 0)
            {
                Random random = new Random();
                int index = random.Next(0, visibleWords.Count);
                visibleWords[index].Hide();
            }
        }

        public override string ToString()
        {
            return $"{Reference}: {string.Join(" ", words)}";
        }
    }

    class ScriptureReference
    {
        public string Reference { get; }

        public ScriptureReference(string reference)
        {
            Reference = reference;
        }

        public override string ToString()
        {
            return Reference;
        }
    }

    class Word
    {
        public string Text { get; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        public void Hide()
        {
            IsHidden = true;
        }

        public override string ToString()
        {
            return IsHidden ? "[HIDDEN]" : Text;
        }
    }

    class ScriptureMemorization
    {
        private Scripture scripture;

        public ScriptureMemorization(Scripture scripture)
        {
            this.scripture = scripture;
        }

        public void DisplayScripture()
        {
            Console.WriteLine(scripture);
        }

        public void HideWord(int index)
        {
            scripture.HideWord(index);
        }

        public void HideRandomWord()
        {
            scripture.HideRandomWord();
        }

        public void HideRandomWords()
        {
            int wordsToHide = scripture.AllWordsHidden ? 0 : 1;
            for (int i = 0; i < wordsToHide; i++)
            {
                scripture.HideRandomWord();
            }
        }

        public bool AllWordsHidden => scripture.AllWordsHidden;
    }
}