
 class Word
    {
        public string Text 
        { 
            get; 
            set;
        }
        public bool IsHidden 
        { 
            get; 
            private set; 
        }

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
            return IsHidden ? "[_]" : Text;
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
